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
    public class DokterCmd: ICRUD<Dokter>
    {
        string ConnectionString = "Data Source=DESKTOP-V4L94VN;Database=db_rs;" +
            "Integrated Security=True;Connect Timeout=30;";
        SqlConnection connection;

        public void read()
        {
            connection = new SqlConnection(ConnectionString);

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM rumahsakit";

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Id: " + reader[0]);
                    Console.WriteLine("Nama: " + reader[1]);
                    Console.WriteLine("Alamat: " + reader[2]);
                    Console.WriteLine("Telp: " + reader[3]);
                    Console.WriteLine("Gaji: " + reader[4]);
                    Console.WriteLine("Rumahsakit: " + reader[5]);
                    Console.WriteLine("Poli: " + reader[6]);
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
            command.CommandText = "SELECT * FROM dokter WHERE id = @id";

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
                    Console.WriteLine("Alamat: " + reader[2]);
                    Console.WriteLine("Telp: " + reader[3]);
                    Console.WriteLine("Gaji: " + reader[4]);
                    Console.WriteLine("Rumahsakit: " + reader[5]);
                    Console.WriteLine("Poli: " + reader[6]);
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

        public void create(Dokter obj)
        {
            connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO dokter (id, nama, alamat, telp, gaji, rs, poli) VALUES (@id, @nama, @alamat, @telp, @gaji, @rs, @poli)";
                command.Transaction = transaction;

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@Id";
                pId.Value = obj.Id;
                pId.SqlDbType = System.Data.SqlDbType.VarChar;
                command.Parameters.Add(pId);

                SqlParameter pNama = new SqlParameter();
                pNama.ParameterName = "@nama";
                pNama.Value = obj.Nama;
                pNama.SqlDbType = System.Data.SqlDbType.VarChar;
                command.Parameters.Add(pNama);

                SqlParameter pAlamat = new SqlParameter();
                pAlamat.ParameterName = "@alamat";
                pAlamat.Value = obj.Alamat;
                pAlamat.SqlDbType = System.Data.SqlDbType.VarChar;
                command.Parameters.Add(pAlamat);

                SqlParameter pTelp = new SqlParameter();
                pTelp.ParameterName = "@telp";
                pTelp.Value = obj.Telp;
                pTelp.SqlDbType = System.Data.SqlDbType.VarChar;
                command.Parameters.Add(pTelp);

                SqlParameter pGaji = new SqlParameter();
                pGaji.ParameterName = "@gaji";
                pGaji.Value = obj.Gaji;
                pGaji.SqlDbType = System.Data.SqlDbType.Int;
                command.Parameters.Add(pGaji);

                SqlParameter pRs = new SqlParameter();
                pRs.ParameterName = "@rs";
                pRs.Value = obj.Rs;
                pRs.SqlDbType = System.Data.SqlDbType.VarChar;
                command.Parameters.Add(pRs);

                SqlParameter pPoli = new SqlParameter();
                pPoli.ParameterName = "@poli";
                pPoli.Value = obj.Poli;
                pPoli.SqlDbType = System.Data.SqlDbType.VarChar;
                command.Parameters.Add(pPoli);

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

        public void update(Dokter obj, string id)
        {
            connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE dokter SET nama = @nama, alamat = @alamat, telp = @telp, gaji = @gaji, rs = @rs, poli = @poli WHERE id = @id";
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

                SqlParameter pAlamat = new SqlParameter();
                pAlamat.ParameterName = "@alamat";
                pAlamat.Value = obj.Alamat;
                pAlamat.SqlDbType = System.Data.SqlDbType.VarChar;
                command.Parameters.Add(pAlamat);

                SqlParameter pTelp = new SqlParameter();
                pTelp.ParameterName = "@telp";
                pTelp.Value = obj.Telp;
                pTelp.SqlDbType = System.Data.SqlDbType.VarChar;
                command.Parameters.Add(pTelp);

                SqlParameter pGaji = new SqlParameter();
                pGaji.ParameterName = "@gaji";
                pGaji.Value = obj.Gaji;
                pGaji.SqlDbType = System.Data.SqlDbType.Int;
                command.Parameters.Add(pGaji);

                SqlParameter pRs = new SqlParameter();
                pRs.ParameterName = "@rs";
                pRs.Value = obj.Rs;
                pRs.SqlDbType = System.Data.SqlDbType.VarChar;
                command.Parameters.Add(pRs);

                SqlParameter pPoli = new SqlParameter();
                pPoli.ParameterName = "@poli";
                pPoli.Value = obj.Poli;
                pPoli.SqlDbType = System.Data.SqlDbType.VarChar;
                command.Parameters.Add(pPoli);

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
                command.CommandText = "DELETE FROM dokter WHERE id = @id";
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
