using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace MahasiswaAPI
{
    [ApiController]
    [Route("api/[controller]")]
    public class MahasiswaController : ControllerBase
    {

        private static List<Mahasiswa> _mahasiswa = new List<Mahasiswa>
        {
            new Mahasiswa { Nama = "Rizky Kusuma Nugraha", Nim = "1302220013" },
            new Mahasiswa { Nama = "Caroline Gracia", Nim = "1302220001" },
            new Mahasiswa { Nama = "Widya Lim", Nim = "1302220002" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Mahasiswa>> GetMahasiswa()
        {
            return _mahasiswa;
        }

        [HttpGet("{index}")]
        public ActionResult<Mahasiswa> GetMahasiswaByIndex(int index)
        {
            if (index < 0 || index >= _mahasiswa.Count)
            {
                return NotFound();
            }

            return _mahasiswa[index];
        }

        [HttpPost]
        public ActionResult PostMahasiswa(Mahasiswa mahasiswa)
        {
            _mahasiswa.Add(mahasiswa);
            return CreatedAtAction(nameof(GetMahasiswaByIndex), new { index = _mahasiswa.Count - 1 }, mahasiswa);
        }

        [HttpDelete("{index}")]
        public ActionResult DeleteMahasiswa(int index)
        {
            if (index < 0 || index >= _mahasiswa.Count)
            {
                return NotFound();
            }

            _mahasiswa.RemoveAt(index);
            return NoContent();
        }
    }

    public class Mahasiswa
    {
        public string Nama { get; set; }
        public string Nim { get; set; }
    }
}
