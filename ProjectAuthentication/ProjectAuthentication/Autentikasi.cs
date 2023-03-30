public class Autentikasi
{
    public string firstname { get; set; }
    public string lastname { get; set; }
    public string username { get; set; }
    public string password { get; set; }

    public int id { get; set; }

    public Autentikasi() { }
    public Autentikasi(int id, string firstname, string lastname, string username, string password)
    {
        this.firstname = firstname;
        this.lastname = lastname;
        this.username = username;
        this.password = password;
        this.id = id;
    }
    

}
