﻿using Microsoft.AspNetCore.Mvc;

namespace tpmodul10_103022300046
{
    //membuat class Mahasiswa
    public class Mahasiswa
    {
        public string Nama { get; set; }
        public string Nim { get; set; }

        public Mahasiswa() { }

        public Mahasiswa(string nama, string nim)
        {
            this.Nama = nama;
            this.Nim = nim;
        }
    }

}
