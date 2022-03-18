using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Aplikasi_Perpustakaan.Model
{
    class AdminModel
    {
        private SqlConnection connection;
        private SqlCommand command;
        private string query;
        private bool result;

        public AdminModel()
        {
            connection = DbConnection.GetConnection();
        }

        private string username, nama, notelp, password;
        public string Username { get { return username; } set { username = value; } }
        public string Nama { get { return nama; } set { nama = value; } }
        public string Notelp { get { return notelp; } set { notelp = value; } }
        public string Password { get { return password; } set { password = value; } }
        public static string tampungNama;
        public bool LoginCheck()
        {
            query = "SELECT Username,Nama,Password FROM Admin WHERE Username='"+username+"' AND Password='"+password+"'";
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = query;

            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                if (dataReader.GetString(0).ToString() == username && (dataReader.GetString(2).ToString() == password))
                {
                    tampungNama = dataReader.GetString(1).ToString();
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            connection.Close();
            return result;
        }


    }

}
