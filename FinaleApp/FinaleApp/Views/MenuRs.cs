using FinaleApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinaleApp.Views
{
    public class MenuRs
    {
        public void menurs()
        {
            RumahsakitCont rsc = new RumahsakitCont();

            Console.WriteLine("CRUD DATA Rumah Sakit");
            Console.WriteLine("1. Tampil Data");
            Console.WriteLine("2. Tambah Data");
            Console.WriteLine("3. Ubah Data");
            Console.WriteLine("4. Cari Data");
            Console.WriteLine("5. Hapus Data");
            Console.WriteLine("6. Kembali");

            int pil = 0;
            while (pil < 6)
            {
                Console.Write("Input: ");
                try
                {
                    pil = Convert.ToInt16(Console.ReadLine());
                }
                catch (IOException ex)
                {
                    Console.WriteLine("Error" + ex.Message);
                }
                switch (pil)
                {
                    case 1:
                        Console.Clear();
                        //RumahsakitCont rsc = new RumahsakitCont();
                        rsc.GetRs();
                        //Console.Clear();
                        menurs();
                        break;

                    case 2:
                        Console.Clear();
                        //RumahsakitCont rsc = new RumahsakitCont();
                        rsc.InsertRs();
                        //Console.Clear();
                        menurs();
                        break;

                    case 3:
                        Console.Clear();
                        //RumahsakitCont rsc = new RumahsakitCont();
                        rsc.UpdateRs();
                        //Console.Clear();
                        menurs();

                        break;

                    case 4:
                        Console.Clear();
                        //RumahsakitCont rsc = new RumahsakitCont();
                        rsc.GetRsById();
                        //Console.Clear();
                        menurs();
                        break;

                    case 5:
                        Console.Clear();
                        //RumahsakitCont rsc = new RumahsakitCont();
                        rsc.DeleteRs();
                        //Console.Clear();
                        menurs();
                        break;

                    case 6:
                        Console.Clear();
                        MenuUtama mu = new MenuUtama();
                        mu.menu();
                        break;
                }
            }
        }
    }
}
