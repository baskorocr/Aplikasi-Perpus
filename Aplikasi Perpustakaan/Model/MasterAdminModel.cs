using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Aplikasi_Perpustakaan.Model
{
    class MasterAdminModel
    {
        private string username;
        private string nama;
        private string email;
        private string password;
        private string notelpon;
        private String cari;
        public string Username
        {
            get { return username; } set { username = value; }
        }
        public string Nama
        {
            get { return nama; } set { nama = value; }
        }
        public string Email
        {
            get { return email; } set { email = value; }
        }
        public string Password
        {
            get { return password; } set { password = value; }
        }
        public string NoTelpon
        {
            get { return notelpon; } set { notelpon = value; }
        }
        public string Cari
        {
            get { return cari; } set { cari = value; }
        }

        private SqlConnection connectionn;
        private SqlCommand command;
        private String query;
        private Boolean status;


        public MasterAdminModel()
        {
            connectionn = DbConnection.GetConnection();
        }
        public DataSet SelectAdmin()
        {
            DataSet ds = new DataSet();
            try
            {
                connectionn.Open();
                command = new SqlCommand();
                command.Connection = connectionn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM Admin";
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(ds, "Admin");
                connectionn.Close();
            }
            catch (SqlException)
            {

            }
            return ds;
        }
        public Boolean InsertAdmin()
        {
            status = false;
            try
            {
                query = "INSERT INTO Admin values('" + username + "','" + nama + "','" + email + "','" + password + "', '"+notelpon+"')";
                connectionn.Open();
                command = new SqlCommand();
                command.Connection = connectionn;
                command.CommandText = query;
                command.ExecuteNonQuery();
                status = true;
                connectionn.Close();
            }
            catch (SqlException)
            {
                status = false;
            }
            return status;
        }

        public Boolean DeleteAdmin()
        {
            status = false;
            try
            {
                query = "DELETE FROM Admin WHERE Username = '"+username+"'";
                connectionn.Open();
                command = new SqlCommand();
                command.Connection = connectionn;
                command.CommandText = query;
                command.ExecuteNonQuery();
                status = true;
                connectionn.Close();

            }
            catch (SqlException)
            {
                status = false;
            }
            return status;
        }

        public Boolean UpdateDataAdmin()
        {
            status = false;
            try
            {
                query = "UPDATE Admin SET  Nama = '" + nama + "',Email ='" + email + "',Password = '" + password + "',NoTelp = '" + notelpon + "' WHERE Username = '" + username + "'";
                connectionn.Open();
                command = new SqlCommand();
                command.Connection = connectionn;
                command.CommandText = query;
                command.ExecuteNonQuery();
                status = true;
                connectionn.Close();
            }
            catch (SqlException)
            {
                status = false;
                connectionn.Close();
            }
            return status;
        }
        public DataSet SearchAdmin()
        {
            DataSet ds = new DataSet();
            try
            {
                connectionn.Open();
                command = new SqlCommand();
                command.Connection = connectionn;
                command.CommandType = CommandType.Text;
                command.CommandText = " select top 1 * from Admin WHERE Username like '%" + cari + "%'";
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(ds, "KELAS");

                connectionn.Close();
            }
            catch (SqlException)
            {

            }
            return ds;
        }

    }
}