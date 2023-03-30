namespace TugasOOP;

public class Program
{
    public static void Main(string[] args)
    {
        Penumpang p1 = new Penumpang();

        p1.kodeBus = "PJ-001";
        p1.berangkat = "Padang";
        p1.tujuan = "Batusangkar";
        p1.jam = "10.00";
        p1.noKursi = 12;
        p1.nama = "Hanum";

        Penumpang p2 = new Penumpang("PJ-001", "Padang", "Batusangkar", "10.00", 5, "Lathifah");

        p1.JadwalBus();
        Console.WriteLine("");
        p2.JadwalBus();

    }
}