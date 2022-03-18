using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Aplikasi_Perpustakaan.Model
{
    class PengaturanModel
    {
        private SqlConnection connection;
        private SqlCommand command;
        private string query;
        private Boolean status;

        public PengaturanModel()
        {
            connection = DbConnection.GetConnection();
        }

        private int lamapinjam, maxpinjam, denda;
        public int MaxPinjam { get { return maxpinjam; } set { maxpinjam = value; } }
        public int LamaPinjam { get { return lamapinjam; } set { lamapinjam = value; } }
        public int Denda { get { return denda; } set { denda = value; } }
        public string Query { get { return query; } set { query = value; } }


        public Boolean InsertSetting()
        {
            status = false;
            try
            {
                query = "INSERT INTO Setting VALUES (1, " + MaxPinjam + ", " + LamaPinjam + ", " + Denda + ")";
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
                connection.Close();
            }
            return status;
        }

        public Boolean UpdateSetting()
        {
            status = false;
            try
            {
                query = "UPDATE Setting SET MaxPinjam = " + MaxPinjam + ", LamaPinjam = " + LamaPinjam + ", Denda = " + Denda + " WHERE IdSetting = 1";
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
                connection.Close();
            }
            return status;
        }

    }
}
