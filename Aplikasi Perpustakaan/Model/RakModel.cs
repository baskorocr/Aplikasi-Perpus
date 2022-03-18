using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace Aplikasi_Perpustakaan.Model
{
    class RakModel
    {
        private int idrak;
        private String rak;
        private int display;
        private String cari;

        public int IdRak
        {
            get
            {
                return idrak;
            }
            set
            {
                idrak = value;
            }
        }

        public string Rak
        {
            get
            {
                return rak;
            }
            set
            {
                rak = value;
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

        public RakModel()
        {
            connection = DbConnection.GetConnection();
        }

        public DataSet SelectRak()
        {
            DataSet ds = new DataSet();
            try
            {
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM RAKBUKU ";
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(ds, "RAK");

                connection.Close();
            }
            catch (SqlException)
            {

            }
            return ds;
        }

        public Boolean InsertRak()
        {
            status = false;
            try
            {
                query = "INSERT INTO  RAKBUKU values(" + idrak + ",'" + rak + "')";
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = query;
                command.ExecuteNonQuery();
                status = true;
                connection.Close();
            }
            catch (SqlException)
            {
                status = false;
            }
            return status;
        }

        public Boolean DeleteRak()
        {
            status = false;
            try
            {
                query = "DELETE FROM RAKBUKU WHERE IdRak = " + idrak + "";
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = query;
                command.ExecuteNonQuery();
                status = true;
                connection.Close();

            }
            catch (SqlException)
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
                query = "SELECT MAX(IdRak) FROM RAKBUKU";
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

        public DataSet RakDisplay()
        {
            DataSet ds = new DataSet();
            try
            {
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT TOP " + display + " * FROM RAKBUKU ";
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(ds, "RAK");

                connection.Close();
            }
            catch (SqlException)
            {

            }
            return ds;
        }

        public DataSet SearchRak()
        {
            DataSet ds = new DataSet();
            try
            {
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = " select top 1 * from RAKBUKU WHERE Rak like '%" + cari + "%'";
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(ds, "RAK");

                connection.Close();
            }
            catch (SqlException)
            {

            }
            return ds;
        }

    }
}
