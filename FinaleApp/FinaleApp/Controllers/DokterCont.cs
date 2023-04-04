using FinaleApp.Models;
using FinaleApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinaleApp.Controllers
{
    public class DokterCont
    {
        public void GetDokter()
        {
            DokterCmd dokter = new DokterCmd();
            dokter.read();
        }

        public void GetDokterById() 
        {
            DokterCmd dokter = new DokterCmd();
            Console.Write("Id: "); string id = Console.ReadLine();
            dokter.readById(id);
        }

        public void InsertDokter()
        {
            DokterCmd dokter = new DokterCmd();
            Dokter d = new Dokter();

            Console.Write("Id: "); d.Id = Console.ReadLine();
            Console.Write("Nama: "); d.Nama = Console.ReadLine();
            Console.Write("Alamat: "); d.Alamat = Console.ReadLine();
            Console.Write("Telp: "); d.Telp = Console.ReadLine();
            Console.Write("Gaji: "); d.Gaji = Convert.ToInt32(Console.ReadLine());
            Console.Write("RumahSakit: "); d.Rs = Console.ReadLine();
            Console.Write("Poliklinik: "); d.Poli = Console.ReadLine();
            dokter.create(d);
        }

        public void UpdateDokter()
        {
            DokterCmd dokter = new DokterCmd();
            Dokter d = new Dokter();

            Console.Write("Id: "); string id = Console.ReadLine();
            Console.Write("Nama: "); d.Nama = Console.ReadLine();
            Console.Write("Alamat: "); d.Alamat = Console.ReadLine();
            Console.Write("Telp: "); d.Telp = Console.ReadLine();
            Console.Write("Gaji: "); d.Gaji = Convert.ToInt32(Console.ReadLine());
            Console.Write("RumahSakit: "); d.Rs = Console.ReadLine();
            Console.Write("Poliklinik: "); d.Poli = Console.ReadLine();
            dokter.update(d, id);
        }

        public void DeleteDokter()
        {
            DokterCmd dokter = new DokterCmd();

            Console.Write("Id: "); string id = Console.ReadLine();
            dokter.delete(id);
        }
    }
}
