using FinaleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinaleApp.Views
{
    public class MenuUtama
    {
        public void menu()
        {
            Console.WriteLine("CRUD DATA");
            Console.WriteLine("1. Rumah Sakit");
            Console.WriteLine("2. Poliklinik");
            Console.WriteLine("3. Dokter");
            Console.WriteLine("4. Exit");

            int pil = 0;
            while (pil < 4)
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
                        MenuRs mrs = new MenuRs();
                        mrs.menurs();
                        break;

                    case 2:
                        Console.Clear();
                        MenuPoli mp = new MenuPoli();
                        mp.menupoli();
                        break;

                    case 3:
                        Console.Clear();
                        MenuDokter md = new MenuDokter();
                        md.menudokter();

                        break;

                    case 4:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
