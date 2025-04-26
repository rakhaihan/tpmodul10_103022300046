using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace tpmodul10_103022300046.Controllers
{
    [Route("api/mahasiswa")]
    [ApiController]
    public class MahasiswaController : ControllerBase
    {
        private static List<Mahasiswa> mahasiswaList = new List<Mahasiswa>
        {
            new Mahasiswa("Rakha Raihanurrahman", "103022300046"),
            new Mahasiswa("Anak Agung Aryadipa A. Nugraha", "1302300063"),
            new Mahasiswa("Muhammad Azki Abdul Malik", "1302300131"),
            new Mahasiswa("Jack Kelvin Guevara Rihilo", "1302330167"),
            new Mahasiswa("Muhammad Raihan Hidayatulloh", "13022300024")
        };

        // GET /api/mahasiswa: mengembalikan output berupa list/array dari semua objek mahasiswa yang tersimpan
        [HttpGet]
        public ActionResult<IEnumerable<Mahasiswa>> GetAllMahasiswa()
        {
            return Ok(mahasiswaList);
        }

        // GET /api/mahasiswa/{index}: mengembalikan output berupa objek mahasiswa untuk index ke-‘index'
        [HttpGet("{index}")]
        public ActionResult<Mahasiswa> GetMahasiswaByIndex(int index)
        {
            if (index < 0 || index >= mahasiswaList.Count)
                return NotFound();

            return Ok(mahasiswaList[index]);
        }

        // POST /api/mahasiswa: menambahkan objek mahasiswa baru dengan menyertakan nama dan nim
        [HttpPost]
        public ActionResult AddMahasiswa([FromBody] Mahasiswa newMahasiswa)
        {
            if (newMahasiswa == null)
                return BadRequest("Data mahasiswa tidak boleh kosong.");

            mahasiswaList.Add(newMahasiswa);

            return CreatedAtAction(nameof(GetMahasiswaByIndex), new { index = mahasiswaList.Count - 1 }, newMahasiswa);
        }

        // DELETE /api/mahasiswa/{index}: menghapus objek mahasiswa dengan index ke-‘index’
        [HttpDelete("{index}")]
        public ActionResult DeleteMahasiswa(int index)
        {
            if (index < 0 || index >= mahasiswaList.Count)
                return NotFound();

            mahasiswaList.RemoveAt(index);
            return NoContent();
        }
    }
}
