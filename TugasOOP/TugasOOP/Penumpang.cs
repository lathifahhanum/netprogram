namespace TugasOOP;

public class Penumpang : Bus
{
    public int noKursi { get; set; }
    public string nama { get; set; }

    public Penumpang()
    {

    }

    public Penumpang(string kodeBus, string berangkat, string tujuan, string jam, int noKursi, string nama) 
        : base(kodeBus, berangkat, tujuan, jam)
    {
        this.noKursi = noKursi;
        this.nama = nama;
    }

    public override void JadwalBus()
    {
        base.JadwalBus();
        Console.WriteLine("No Kursi: " + noKursi);
        Console.WriteLine("Nama Penumpang: " + nama);
    }
}