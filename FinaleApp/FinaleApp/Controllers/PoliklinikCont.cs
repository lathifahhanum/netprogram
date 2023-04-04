using FinaleApp.Models;
using FinaleApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinaleApp.Controllers
{
    public class PoliklinikCont
    {
        public void GetPoli()
        {
            PoliklinikCmd poli = new PoliklinikCmd();
            poli.read();
        }

        public void GetPoliById()
        {
            PoliklinikCmd poli = new PoliklinikCmd();
            Console.Write("Id: "); string id = Console.ReadLine();
            poli.readById(id);
        }

        public void InsertPoli()
        {
            PoliklinikCmd poli = new PoliklinikCmd();
            Poliklinik d = new Poliklinik();

            Console.Write("Id: "); d.Id = Console.ReadLine();
            Console.Write("Nama: "); d.Nama = Console.ReadLine();
            Console.Write("Telp: "); d.Telp = Console.ReadLine();
            Console.Write("Keterangan: "); d.Keterangan = Console.ReadLine();
            poli.create(d);
        }

        public void UpdatePoli()
        {
            PoliklinikCmd poli = new PoliklinikCmd();
            Poliklinik d = new Poliklinik();

            Console.Write("Id: "); string id = Console.ReadLine();
            Console.Write("Nama: "); d.Nama = Console.ReadLine();
            Console.Write("Telp: "); d.Telp = Console.ReadLine();
            Console.Write("Keterangan: "); d.Keterangan = Console.ReadLine();
            poli.update(d, id);
        }

        public void DeletePoli()
        {
            PoliklinikCmd poli = new PoliklinikCmd();

            Console.Write("Id: "); string id = Console.ReadLine();
            poli.delete(id);
        }
    }
}
