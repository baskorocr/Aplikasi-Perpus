using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;

namespace Aplikasi_Perpustakaan.Model
{
    class DbConnection
    {
        private static SqlConnection connection;
        public static SqlConnection GetConnection()
        {
            connection = new SqlConnection();
            connection.ConnectionString = "Data Source = DESKTOP-I6LNHI4\\SQLEXPRESS;" +
                                          "Initial Catalog = Perpusku;" +
                                          "Integrated Security = true";

            return connection;
        }
        public void TestConnection()
        {
            GetConnection();
            try
            {
                connection.Open();
                MessageBox.Show("Connection success");
            }
            catch (SqlException se)
            {
                MessageBox.Show("Connection failed " + se);
            }
        }
    }
}
