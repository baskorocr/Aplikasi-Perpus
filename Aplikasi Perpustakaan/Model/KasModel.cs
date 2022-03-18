using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows;

namespace Aplikasi_Perpustakaan.Model
{
    class KasModel
    {
        private int kasmasuk, kaskeluar,display;
        private string keterangan, getfaktur, petugas,totalPemasukan,totalKeluar, totalSemua,cari;

        public int KasMasuk
        {
            get
            {
                return kasmasuk;
            }
            set
            {
                kasmasuk = value;
            }
        }
        public int KasKeluar
        {
            get
            {
                return kaskeluar;
            }
            set
            {
                kaskeluar = value;
            }
        }

        public string Keterangan
        {
            get
            {
                return keterangan;
            }
            set
            {
                keterangan = value;
            }
        }

        public string GetFaktur
        {
            get
            {
                return getfaktur;
            }
            set
            {
                getfaktur = value;
            }
        }
        public string Petugas
        {
            get
            {
                return petugas;
            }
            set
            {
                petugas = value;
            }
        }
        public string TotalPemasukan
        {
            get
            {
                return totalPemasukan;
            }
            set
            {
                totalPemasukan = value;
            }
        }
        public string TotalPengeluaran
        {
            get
            {
                return totalKeluar;
            }
            set
            {
                totalKeluar = value;
            }
        }

        public string TotalKeseluruhan
        {
            get
            {
                return totalSemua;
            }
            set
            {
                totalSemua = value;
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

        private SqlConnection connection;
        private SqlCommand command;
        private String query;
        private Boolean result;

        public KasModel()
        {
            connection = DbConnection.GetConnection();
        }

        public Boolean InsertKas()
        {
            result = false;
            try
            {
                query = "INSERT INTO  Kas values("+kasmasuk+","+kaskeluar+",'"+Model.AdminModel.tampungNama+"','"+keterangan+"')";
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = query;
                command.ExecuteNonQuery();
                result = true;
                connection.Close();
            }
            catch (SqlException)
            {
                result = false;
            }
            return result;
        }

        public Boolean TotalPemasukaKas()
        {
            result = false;
            try
            {
                query = "SELECT SUM(Pemasukan), SUM(Pengeluaran), SUM(Pemasukan-Pengeluaran) from Kas";
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = query;
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    TotalPemasukan = dataReader.GetInt32(0).ToString();
                    TotalPengeluaran = dataReader.GetInt32(1).ToString();
                    TotalKeseluruhan = dataReader.GetInt32(2).ToString();
                    result = true;

                }
                connection.Close();
            }
            catch (SqlException)
            {
                result = false;
            }
            return result;
        }

        public Boolean GetFt()
        {
            int i;
            result = false;

            try
            {
                query = "SELECT COUNT(IdKas) from Kas";
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = query;
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    i = dataReader.GetInt32(0) + 1;
                    if (i <= 9)
                    {
                        GetFaktur = "FT00000" + i;
                    }
                    if (i > 9)
                    {
                        GetFaktur = "FT0000" + i;
                    }
                    if (i > 99)
                    {
                        GetFaktur = "FT000" + i;
                    }
                    if (i > 999)
                    {
                        GetFaktur = "FT00" + i;
                    }
                    if (i > 9999)
                    {
                        GetFaktur = "FT0" + i;
                    }
                    if (i > 99999)
                    {
                        GetFaktur = "FT" + i;
                    }
                    
                    result = true;
                }
                connection.Close();
            }
            catch (SqlException)
            {
                result = false;
            }

            return result;
        }

        public DataSet KasDisplayMasuk()
        {
            DataSet ds = new DataSet();
            try
            {
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT TOP " + display + " IdKas,NoFaktur,Pemasukan,Operator,Keterangan FROM Kas ";
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(ds, "Kas");

                connection.Close();
            }
            catch (SqlException)
            {

            }
            return ds;
        }
        public DataSet KasDisplayKeluar()
        {
            DataSet ds = new DataSet();
            try
            {
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT TOP " + display + " IdKas,NoFaktur,Pengeluaran,Operator,Keterangan FROM Kas ";
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(ds, "Kas");

                connection.Close();
            }
            catch (SqlException)
            {

            }
            return ds;
        }

        public DataSet selectKasMasuk()
        {
            DataSet ds = new DataSet();
            try
            {
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT IdKas,NoFaktur,Pemasukan,Operator,Keterangan FROM Kas";
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(ds, "KELAS");
                connection.Close();
            }
            catch (SqlException)
            {

            }
            return ds;
        }
        public DataSet selectKasKeluar()
        {
            DataSet ds = new DataSet();
            try
            {
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT IdKas,NoFaktur,Pengeluaran,Operator,Keterangan FROM Kas";
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(ds, "KELAS");
                connection.Close();
            }
            catch (SqlException)
            {

            }
            return ds;
        }

        public DataSet SearchFTMasuk()
        {
            DataSet ds = new DataSet();
            try
            {
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = " select top 1 IdKas,NoFaktur,Pemasukan,Operator,Keterangan FROM Kas WHERE NoFaktur like '%" + cari + "%'";
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
