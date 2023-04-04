using FinaleApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinaleApp.Views
{
    public class MenuDokter
    {
        public void menudokter()
        {
            DokterCont dc = new DokterCont();

            Console.WriteLine("CRUD DATA Dokter");
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
                        dc.GetDokter();
                        Console.Clear();
                        menudokter();
                        break;

                    case 2:
                        Console.Clear();
                        dc.InsertDokter();
                        Console.Clear();
                        menudokter();
                        break;

                    case 3:
                        Console.Clear();
                        dc.UpdateDokter();
                        Console.Clear();
                        menudokter();
                        break;

                    case 4:
                        Console.Clear();
                        dc.GetDokterById();
                        Console.Clear();
                        menudokter();
                        break;

                    case 5:
                        Console.Clear();
                        dc.DeleteDokter();
                        Console.Clear();
                        menudokter();
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
