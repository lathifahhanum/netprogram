using FinaleApp.Models;
using FinaleApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinaleApp.Controllers
{
    public class RumahsakitCont
    {
        public void GetRs()
        {
            RumahsakitCmd rs = new RumahsakitCmd();
            rs.read();
        }

        public void GetRsById()
        {
            RumahsakitCmd rs = new RumahsakitCmd();
            Console.Write("Id: "); string id = Console.ReadLine();
            rs.readById(id);
        }

        public void InsertRs()
        {
            RumahsakitCmd rs = new RumahsakitCmd();
            Rumahsakit d = new Rumahsakit();

            Console.Write("Id: "); d.Id = Console.ReadLine();
            Console.Write("Nama: "); d.Nama = Console.ReadLine();
            Console.Write("Alamat: "); d.Alamat = Console.ReadLine();
            Console.Write("Telp: "); d.Telp = Console.ReadLine();
            rs.create(d);
        }

        public void UpdateRs()
        {
            RumahsakitCmd rs = new RumahsakitCmd();
            Rumahsakit d = new Rumahsakit();

            Console.Write("Id: "); string id = Console.ReadLine();
            Console.Write("Nama: "); d.Nama = Console.ReadLine();
            Console.Write("Alamat: "); d.Alamat = Console.ReadLine();
            Console.Write("Telp: "); d.Telp = Console.ReadLine();
            rs.update(d, id);
        }

        public void DeleteRs()
        {
            RumahsakitCmd rs = new RumahsakitCmd();

            Console.Write("Id: "); string id = Console.ReadLine();
            rs.delete(id);
        }
    }
}
