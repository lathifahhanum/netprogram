namespace TugasOOP;

public class Bus
{
    public string kodeBus { get; set; }
    public string berangkat { get; set; }
    public string tujuan { get; set; }
    public string jam { get; set; }

    public Bus()
    {
        
    }

    public Bus(string kodeBus, string berangkat, string tujuan, string jam)
    {
        this.kodeBus = kodeBus;
        this.berangkat = berangkat;
        this.tujuan = tujuan;
        this.jam = jam;
    }

    public virtual void JadwalBus()
    {
        Console.WriteLine("No Bus: " + kodeBus);
        Console.WriteLine("Keberangkatan: " + berangkat);
        Console.WriteLine("Tujuan: " + tujuan);
        Console.WriteLine("Jam: " + jam);
    }
}