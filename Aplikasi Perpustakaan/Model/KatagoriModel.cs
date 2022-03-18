using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Aplikasi_Perpustakaan.Model
{
    class KatagoriModel
    {
        private int idkatagori;
        private string katagori;
        private int display;
        private String cari;

        public int IdKatagori
        {
            get
            {
                return idkatagori;
            }
            set
            {
                idkatagori = value;
            }
        }
         public string Katagori
        {
            get
            {
                return katagori;
            }
            set
            {
                katagori = value;
            }
        }

        public int Display
        {
            get
            {
                return display;
            }
            set
            {
                display = value;
            }
        }

        public string Cari
        {
            get
            {
                return cari;
            }
            set
            {
                cari = value;
            }
        }
        private SqlConnection connection;
        private SqlCommand command;
        private String query;
        private Boolean status;

        public KatagoriModel()
        {
            connection = DbConnection.GetConnection();
        }

        public DataSet selectKatagori()
        {
            DataSet ds = new DataSet();
            try
            {
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM KATAGORI";
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(ds, "KELAS");
                connection.Close();
            }
            catch(SqlException)
            {
                
            }
            return ds;
        }

        public Boolean InsertKatagori()
        {
            status = false;
            try
            {
                query = "INSERT INTO  KATAGORI values('" + idkatagori + "','" + katagori + "')";
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = query;
                command.ExecuteNonQuery();
                status = true;
                connection.Close();
            }
            catch(SqlException)
            {
                status = false;
            }
            return status;
        }

        public Boolean DeleteKatagori()
        {
            status = false;
            try
            {
                query = "DELETE FROM KATAGORI WHERE IdKatagori = " + IdKatagori + "";
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = query;
                command.ExecuteNonQuery();
                status = true;
                connection.Close();
            }
            catch(SqlException)
            {
                status = false;
            }
            return status;
        }

        public int BuatKode()
        {
            int kode = 0;
            try
            {
                query = "SELECT MAX(IdKatagori) FROM KATAGORI";
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = query;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    kode = Int16.Parse(reader.GetInt16(0).ToString()) + 1;

                }
                connection.Close();
            }
            catch (SqlException)
            {
                kode = 0;
            }
            return kode;

        }

        public DataSet KatagoriDisplay()
        {
            DataSet ds = new DataSet();
            try
            {
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT TOP " + display + " * FROM KATAGORI ";
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(ds, "KATAGORI");

                connection.Close();
            }
            catch (SqlException)
            {

            }
            return ds;
        }

        public DataSet SearchKelas()
        {
            DataSet ds = new DataSet();
            try
            {
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = " select top 1 * from KATAGORI WHERE Katagori like '%" + cari + "%'";
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(ds, "KATAGORI");

                connection.Close();
            }
            catch (SqlException)
            {

            }
            return ds;
        }
    }
}
