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

        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT * FROM region WHERE id = @id";

        connection.Open();

        SqlParameter pId = new SqlParameter();
        pId.ParameterName = "@id";
        pId.Value = id;
        pId.SqlDbType = System.Data.SqlDbType.Int;

        command.Parameters.Add(pId);

        using SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while(reader.Read())
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

        connection.Open();
        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            //membuat instance command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "INSERT INTO region (name) VALUES (@name)";
            command.Transaction = transaction;

            //membuat parameter
            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.Value = name;
            pName.SqlDbType = System.Data.SqlDbType.VarChar;

            //menambahkan parameter ke command
            command.Parameters.Add(pName);

            //menjalankan command
            int result = command.ExecuteNonQuery();
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
        connection.Open();
        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "UPDATE region SET name = @name WHERE id = @id";
            command.Transaction = transaction;

            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.Value = id;
            pId.SqlDbType = System.Data.SqlDbType.Int;
            command.Parameters.Add(pId);

            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.Value = name;
            pName.SqlDbType = System.Data.SqlDbType.VarChar;
            command.Parameters.Add(pName);

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
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "DELETE FROM region WHERE id = @id";
            command.Transaction = transaction;

            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.Value = id;
            pId.SqlDbType = System.Data.SqlDbType.Int;
            command.Parameters.Add(pId);

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