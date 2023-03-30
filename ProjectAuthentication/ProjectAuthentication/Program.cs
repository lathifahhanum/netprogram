using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ProjectAuthentication;
public class Program
{

    public static List<Autentikasi> autentikasi = new List<Autentikasi>(); 
    public static void Main(string[] args)
    {
        Program program = new Program();

        Console.WriteLine("== Basic Authentication ==");
        Console.WriteLine("1. Create User");
        Console.WriteLine("2. Show USer");
        Console.WriteLine("3. Search User");
        Console.WriteLine("4. Login User");
        Console.WriteLine("5. Exit");

        int pil = 0;
        while (pil < 5)
        {
            Console.Write("Input: ");
            try
            {
                pil = Convert.ToInt16(Console.ReadLine());
            } catch (IOException ex){
                Console.WriteLine("Error" + ex.Message);
            }

            switch (pil)
            {
                case 1:
                    program.addUser(autentikasi);
                    break;

                case 2:
                    program.showUser(autentikasi);
                    break;

                case 3:
                    Console.WriteLine("----------------Search User---------------------");
                    Console.Write("Masukkan nama: ");
                    string search = Console.ReadLine();
                    Autentikasi cari = program.searchUser(autentikasi, search);
                    if (cari != null)
                    {
                        Console.WriteLine("ID \t\t: {0}", cari.id+1);
                        Console.WriteLine("Name \t\t: {0}", cari.firstname + " " + cari.lastname);
                        Console.WriteLine("Username \t: {0}", cari.username);
                        Console.WriteLine("Password \t: {0}\n", cari.password);
                        Console.WriteLine("------------------------------------------------------------");
                        Console.WriteLine();
                    }else
                    {
                        Console.WriteLine("Data tidak ditemukan");
                    }

                    break;

                case 4:
                    Console.WriteLine("====================LOGIN=====================");
                    Console.Write("Username\t: "); string u = Console.ReadLine();
                    Console.Write("Password\t: "); string p = Console.ReadLine();
                    Autentikasi au = program.loginUser(autentikasi, u, p);
                    if (au.username == u && au.password == p)
                    {
                        Console.WriteLine("Login berhasil!");
                        Console.WriteLine("--------------------------------------------------");
                        Console.WriteLine();
                    }
                    else { 
                        Console.WriteLine("Login gagal!");
                        Console.WriteLine("------------------------------------------------"); 
                        Console.WriteLine();
                    }
                    break;

                case 5:
                    Environment.Exit(0);
                    break;
            }
        }
        
    }

    public void addUser(List<Autentikasi> autentikasi)
    {
        Autentikasi auten = new Autentikasi();
        Console.WriteLine("");
        Console.WriteLine("================CreateUser======================");
        Console.Write("First name: "); auten.firstname = Console.ReadLine();
        Console.Write("Last name: "); auten.lastname = Console.ReadLine();
        Console.Write("Password: "); auten.password = Console.ReadLine();
        Console.WriteLine("=================================================");
        Console.WriteLine() ;

        string uname = auten.firstname.Substring(0, 2) + auten.lastname.Substring(0, 2);
        auten.username = uname;

        if (autentikasi.Count() > 0)
        {
            for (int i = 0; i < autentikasi.Count(); i++)
            {
                if (autentikasi[i].username == uname)
                {
                    uname = auten.firstname.Substring(0, 2) + auten.lastname.Substring(0, 3);
                    auten.username = uname;
                }
            }
        }

        autentikasi.Add(auten);
    }

    public void showUser(List<Autentikasi> autentikasi)
    {
        Console.WriteLine("----------------Show User---------------------");
        if(autentikasi.Count() > 0)
        {
            for(int i=0; i<autentikasi.Count(); i++)
            {
                int no = i + 1;
                Console.WriteLine("ID\t\t: " + no + "\nName\t\t: " + autentikasi[i].firstname + " " + autentikasi[i].lastname + "\nUsername\t: " + autentikasi[i].username + "\nPassword\t: " + autentikasi[i].password);
                Console.WriteLine("============================================================================");
                Console.WriteLine();
            }
        }
    }

    public Autentikasi searchUser(List<Autentikasi> autentikasi, string search)
    {
        return autentikasi.Find(name => name.firstname.Contains(search) || name.lastname.Contains(search));
    }

    public Autentikasi loginUser(List<Autentikasi> autentikasi, string u, string p)
    {
        return autentikasi.Find(un => un.username == u);  
        return autentikasi.Find(pas => pas.password == p);
    }
}
