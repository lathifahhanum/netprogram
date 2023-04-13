using FinaleApp.Interfaces;
using FinaleApp.Models;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinaleApp.Repositories
{
    public class PoliklinikCmd: ICRUD<Poliklinik>
    {
        string ConnectionString = "Data Source=DESKTOP-V4L94VN;Database=db_rs;" +
            "Integrated Security=True;Connect Timeout=30;";
        SqlConnection connection;

        public void read()
        {
            connection = new SqlConnection(ConnectionString);

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM poliklinik";

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Id: " + reader[0]);
                    Console.WriteLine("Nama: " + reader[1]);
                    Console.WriteLine("Telp: " + reader[2]);
                    Console.WriteLine("Keterangan: " + reader[3]);
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

        public void readById(string id)
        {
            connection = new SqlConnection(ConnectionString);

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM poliklinik WHERE id = @id";

            connection.Open();

            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.Value = id;
            pId.SqlDbType = System.Data.SqlDbType.VarChar;

            command.Parameters.Add(pId);

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Id: " + reader[0]);
                    Console.WriteLine("Nama: " + reader[1]);
                    Console.WriteLine("Telp: " + reader[2]);
                    Console.WriteLine("Keterangan: " + reader[3]);
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

        public void create(Poliklinik obj)
        {
            connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO poliklinik (id, nama, telp, ket) VALUES (@id, @nama, @telp, @ket)";
                command.Transaction = transaction;

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.Value = obj.Id;
                pId.SqlDbType = System.Data.SqlDbType.VarChar;
                command.Parameters.Add(pId);

                SqlParameter pNama = new SqlParameter();
                pNama.ParameterName = "@nama";
                pNama.Value = obj.Nama;
                pNama.SqlDbType = System.Data.SqlDbType.VarChar;
                command.Parameters.Add(pNama);

                SqlParameter pTelp = new SqlParameter();
                pTelp.ParameterName = "@telp";
                pTelp.Value = obj.Telp;
                pTelp.SqlDbType = System.Data.SqlDbType.VarChar;
                command.Parameters.Add(pTelp);

                SqlParameter pKet = new SqlParameter();
                pKet.ParameterName = "@ket";
                pKet.Value = obj.Keterangan;
                pKet.SqlDbType = System.Data.SqlDbType.VarChar;
                command.Parameters.Add(pKet);

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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception ex2)
                {
                    Console.WriteLine(ex2.Message);
                }
            }
        }

        public void update(Poliklinik obj, string id)
        {
            connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE poliklinik SET nama = @nama, telp = @telp, ket = @ket WHERE id = @id";
                command.Transaction = transaction;

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.Value = id;
                pId.SqlDbType = System.Data.SqlDbType.VarChar;
                command.Parameters.Add(pId);

                SqlParameter pNama = new SqlParameter();
                pNama.ParameterName = "@nama";
                pNama.Value = obj.Nama;
                pNama.SqlDbType = System.Data.SqlDbType.VarChar;
                command.Parameters.Add(pNama);

                SqlParameter pTelp = new SqlParameter();
                pTelp.ParameterName = "@telp";
                pTelp.Value = obj.Telp;
                pTelp.SqlDbType = System.Data.SqlDbType.VarChar;
                command.Parameters.Add(pTelp);

                SqlParameter pKet = new SqlParameter();
                pKet.ParameterName = "@ket";
                pKet.Value = obj.Keterangan;
                pKet.SqlDbType = System.Data.SqlDbType.VarChar;
                command.Parameters.Add(pKet);

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

        public void delete(string id)
        {
            connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "DELETE FROM poliklinik WHERE id = @id";
                command.Transaction = transaction;

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.Value = id;
                pId.SqlDbType = System.Data.SqlDbType.VarChar;
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
}
