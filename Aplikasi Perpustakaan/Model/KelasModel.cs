using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Aplikasi_Perpustakaan.Model
{
    
    class KelasModel
    {
        private int idkelas;
        private String kelas;
        private int display;
        private String cari;


        public int IdKelas
        {
            get
            {
                return idkelas;
            }
            set
            {
                idkelas = value;
            }
        }
        public string Kelas
        {
            get
            {
                return kelas;
            }
            set
            {
                kelas = value;
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

        public KelasModel()
        {
            connection = DbConnection.GetConnection();
        }

        public DataSet SelectKelas()
        {
            DataSet ds = new DataSet();
            try
            {
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM KELAS ";
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(ds, "KELAS");
                
                connection.Close();
            }
            catch(SqlException)
            {

            }
            return ds;
        }

        

        public Boolean InsertKelas()
        {
            status = false;
            try
            {
                query = "INSERT INTO  KELAS values("+idkelas+",'" + kelas + "')";
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

        public Boolean DeleteKelas()
        {
            status = false;
            try
            {
                query = "DELETE FROM KELAS WHERE IdKelas = " + idkelas + ""; 
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
                query = "SELECT MAX(IdKelas) FROM KELAS";
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = query; 
                 SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    kode = Int16.Parse(reader.GetInt16(0).ToString()) + 1;
                    
                }
                connection.Close();
            }
            catch(SqlException)
            {
                kode = 0;
            }
            return kode;
        }

        public DataSet KelasDisplay()
        {
            DataSet ds = new DataSet();
            try
            {
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT TOP "+display+" * FROM KELAS ";
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(ds, "KELAS");

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
                command.CommandText = " select top 1 * from KELAS WHERE Kelas like '%"+cari+"%'";
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(ds, "KELAS");

                connection.Close();
            }
            catch (SqlException)
            {

            }
            return ds;
        }





    }
}
