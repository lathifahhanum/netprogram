using System.Data.SqlClient;
using System.Xml.Linq;

namespace DatabaseConnectivity;
class Program
{
    static string ConnectionString = "Data Source=DESKTOP-V4L94VN;Database=db_hr_dts;" +
            "Integrated Security=True;Connect Timeout=30;";
    static SqlConnection connection;
    static void Main(string[] args)
    {
        /*try
        {
            connection.Open();
            Console.WriteLine("Koneksi berhasil!");
            connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }*/

        //GetAllRegion();
        //InsertRegion("Africa");
        //GetById(3);
        //UpdateRegion(5, "North Africa");
        DeleteRegion(5);
        GetAllRegion();
    }

    //GETALL: REGION (command) -> menampilkan semua data region.
    public static void GetAllRegion()
    {
        connection = new SqlConnection(ConnectionString);

        //membuat instance untuk command
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT * FROM region";

        //membuka koneksi
        connection.Open();

        using SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while(reader.Read())
            {
                Console.WriteLine("Id: " + reader[0]);
                Console.WriteLine("Name: " + reader[1]);
                Console.WriteLine("-------------------------------");
            }
        }
        else
        {
            Console.WriteLine("Data tidak ditemukan!");
        }
        reader.Close();
        connection.Close();
    }

    //GETBYID: REGION (command) -> menampilkan data berdasarkan ID.
    public static void GetById(int id)
    {
        connection = new SqlConnection(ConnectionString);

        //membuat command
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT * FROM region WHERE id = @id";

        //membuka koneksi
        connection.Open();

        //membuat parameter untuk @id untuk memanggil id region pada database.
        SqlParameter pId = new SqlParameter();
        pId.ParameterName = "@id";
        pId.Value = id; //=@id = parameter id pada GetById(int id). =id yang akan dibaca untuk @id.
        pId.SqlDbType = System.Data.SqlDbType.Int; //menyesuaikan tipe data dengan yang ada pada database.

        //menambahkan parameter ke command untuk diexecute.
        command.Parameters.Add(pId);

        //membaca apakah data ada.
        using SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            //menampilkan data yang ditemukan.
            while (reader.Read())
            {
                Console.WriteLine("Id: " + reader[0]);
                Console.WriteLine("Name: " + reader[1]);
                Console.WriteLine("----------------------------------");
            }
        }
        else
        {
            Console.WriteLine("Data tidak ditemukan!");
        }
        reader.Close();
        connection.Close();
    }

    //INSERT: REGION (transaction) -> menambahkan data.
    public static void InsertRegion(string name)
    {
        connection = new SqlConnection(ConnectionString);

        //membuka koneksi.
        connection.Open();

        //memulai database transaction; berlaku untuk insert, update, delete.
        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            //membuat instance command sql insert.
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "INSERT INTO region (name) VALUES (@name)";
            command.Transaction = transaction;

            //membuat parameter @name untuk field name pada region database.
            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.Value = name; //=@name.
            pName.SqlDbType = System.Data.SqlDbType.VarChar;

            //menambahkan parameter ke command.
            command.Parameters.Add(pName);

            //menjalankan command(query).
            int result = command.ExecuteNonQuery();

            //melakukan transaction.
            transaction.Commit();

            if (result > 0)
            {
                Console.WriteLine("Data berhasil ditambahkan!");
            }
            else
            {
                Console.WriteLine("Data gagal ditambahkan!");
            }

            connection.Close();
        } catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            try
            {
                transaction.Rollback();
            } catch (Exception ex2)
            {
                Console.WriteLine(ex2.Message);
            }
        }
    }

    //UPDATE: REGION (transaction)
    public static void UpdateRegion(int id, string name)
    {
        connection = new SqlConnection(ConnectionString);
        //membuka koneksi db.
        connection.Open();

        //memulai transaction.
        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            //membuat command untuk update data di database.
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "UPDATE region SET name = @name WHERE id = @id"; //terdapat @name dan @id.
            command.Transaction = transaction;

            //membuat parameter untuk membaca @id.
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.Value = id; //=@id.
            pId.SqlDbType = System.Data.SqlDbType.Int;
            command.Parameters.Add(pId); //menambahkan ke command @id.

            //membuat parameter untuk @name.
            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.Value = name; //=@name.
            pName.SqlDbType = System.Data.SqlDbType.VarChar;
            command.Parameters.Add(pName); //menambahkan ke command @name.

            //execute command.
            int result = command.ExecuteNonQuery();
            transaction.Commit();

            if (result > 0)
            {
                Console.WriteLine("Data berhasil diubah!");
            }
            else
            {
                Console.WriteLine("Data gagal diubah!");
            }

            connection.Close();
        } catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            try
            {
                transaction.Rollback();
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
    public static void DeleteRegion(int id)
    {
        connection = new SqlConnection(ConnectionString);
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();
        try
        {
            //membuat command untuk delete.
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "DELETE FROM region WHERE id = @id"; //dibutuhkan @id.
            command.Transaction = transaction;

            //membuat parameter untuk @id.
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.Value = id; //=@id.
            pId.SqlDbType = System.Data.SqlDbType.Int;
            command.Parameters.Add(pId); //menambahkan id ke command @id.

            //execute command.
            int result = command.ExecuteNonQuery();
            transaction.Commit();

            if (result > 0)
            {
                Console.WriteLine("Data berhasil dihapus!");
            }
            else
            {
                Console.WriteLine("Data gagal dihapus!");
            }

            connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}