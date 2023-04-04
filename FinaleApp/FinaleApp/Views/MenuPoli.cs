using FinaleApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinaleApp.Views
{
    public class MenuPoli
    {
        public void menupoli()
        {
            PoliklinikCont pc = new PoliklinikCont();

            Console.WriteLine("CRUD DATA Poliklinik");
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
                        pc.GetPoli();
                        //Console.Clear();
                        menupoli();
                        break;

                    case 2:
                        Console.Clear();
                        pc.InsertPoli();
                        //Console.Clear();
                        menupoli();
                        break;

                    case 3:
                        Console.Clear();
                        pc.UpdatePoli();
                        //Console.Clear();
                        menupoli();
                        break;

                    case 4:
                        Console.Clear();
                        pc.GetPoliById();
                        //Console.Clear();
                        menupoli();
                        break;

                    case 5:
                        Console.Clear();
                        pc.DeletePoli();
                        //Console.Clear();
                        menupoli();
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
