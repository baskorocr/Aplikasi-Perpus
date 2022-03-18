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
    class BukuModel
    {
        private SqlConnection connection;
        private SqlCommand command;
        private string query;

        public BukuModel()
        {
            connection = DbConnection.GetConnection();
        }

        private int kategori, rak, display;
        private string idbuku, judul, pengarang, penerbit, thnterbit, tmptterbit, totalhlmn,stok, isbn, deskripsi, cari;
        private Boolean status;

        public string IdBuku { get { return idbuku; } set { idbuku = value; } }
        public string Judul { get { return judul; } set { judul = value; } }
        public string Pengarang { get { return pengarang; } set { pengarang = value; } }
        public string Penerbit { get { return penerbit; } set { penerbit = value; } }
        public string ThnTerbit { get { return thnterbit; } set { thnterbit = value; } }
        public string TmptTerbit { get { return tmptterbit; } set { tmptterbit = value; } }
        public string TotalHlmn { get { return totalhlmn; } set { totalhlmn = value; } }
        public string ISBN { get { return isbn; } set { isbn = value; } }
        public string Stok { get { return stok; } set { stok = value; } }
        public int Kategori { get { return kategori; } set { kategori = value; } }
        public int Rak { get { return rak; } set { rak = value; } }
        public string Deskripsi { get { return deskripsi; } set { deskripsi = value; } }
        public int Display { get { return display; } set { display = value; } }
        public string Cari { get { return cari; } set { cari = value; } }



        public DataSet SelectDataBuku()
        {
            DataSet ds = new DataSet();
            try
            {
                query = "SELECT IdBuku, Judul, Pengarang, Penerbit, ThnTerbit AS'Tahun Terbit',Buku.TmptTerbit AS'Tempat Terbit'," + " Buku.TotalHlmn AS 'Jumlah Halaman', Buku.ISBN," + "Buku.Stok,KATAGORI.Katagori AS 'Kategori',RAKBUKU.NamaRak AS 'Rak',Deskripsi FROM Buku " + " INNER JOIN KATAGORI ON Buku.IdKatagori = KATAGORI.IdKatagori " + "INNER JOIN RAKBUKU ON Buku.IdRak = RAKBUKU.IdRak";
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(ds, "Buku");
                connection.Close();
            }
            catch
            {
                connection.Close();
            }
            return ds;
        }

        public Boolean InsertDataBuku()
        {
            status = false;
            try
            {
                
                query = "INSERT INTO Buku VALUES ("+IdBuku+",'"+Judul+"', '"+
                    Pengarang+"', '"+Penerbit+"', '"+ThnTerbit+"','"+
                    TmptTerbit+"', '"+TotalHlmn+"', '"+ISBN+"', '"+Stok+"','"+
                    Kategori+"','"+Rak+"', '"+Deskripsi+"') ";
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
                connection.Close();
            }
            return status;
        }

        public Boolean UpdateDataBuku()
        {
            status = false;
            try
            {
                query = "UPDATE Buku SET  Judul = '" + Judul + "', Pengarang = '" + 
                    Pengarang + "', Penerbit = '" + Penerbit + "', ThnTerbit = '" + 
                    ThnTerbit + "', TmptTerbit = '" +TmptTerbit +  "', TotalHlmn = '" + 
                    TotalHlmn + "', ISBN = '" + ISBN + "', Stok = " + Stok + 
                    ", IdKatagori = " + Kategori + ", IdRak = " + Rak + ", Deskripsi = '" + 
                    Deskripsi +  "' WHERE IdBuku = "+IdBuku ;
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

        public Boolean DeleteDataBuku()
        {
            status = false;
            try
            {
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "DELETE FROM  Buku  WHERE IdBuku = " + IdBuku;
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



        public List<string> fillComboKategori()
        {
            List<string> comboArrayList = new List<string>();
            StringBuilder sb = new StringBuilder();
            try
            {
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT Katagori FROM KATAGORI";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var ii = reader.FieldCount;
                    for (int i = 0; i < ii; i++)
                    {
                        if (reader[i] is DBNull)
                            comboArrayList.Add("Null");
                        else
                            comboArrayList.Add(reader[i].ToString());
                    }
                }
                connection.Close();
            }
            catch
            {
                connection.Close();
            }
            return comboArrayList;
        }

        public List<string> fillComboRak()
        {
            List<string> comboArrayList = new List<string>();
            StringBuilder sb = new StringBuilder();
            try
            {
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT NamaRak FROM RAKBUKU";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var ii = reader.FieldCount;
                    for (int i = 0; i < ii; i++)
                    {
                        if (reader[i] is DBNull)
                            comboArrayList.Add("Null");
                        else
                            comboArrayList.Add(reader[i].ToString());
                    }
                }
                connection.Close();
            }
            catch
            {
                connection.Close();
            }
            return comboArrayList;
        }
        //mencari id sesuai nama dari combo box
        public int Id_Kategori(string nama)
        {
            try
            {
                connection.Open();                
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT IdKatagori FROM KATAGORI WHERE Katagori = \'" + nama +"\'" ;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Kategori = Int16.Parse(reader.GetInt16(0).ToString());
                }
                connection.Close();               
            }catch (SqlException )
            {
                connection.Close();
            }
            return Kategori;
        }
        public int Id_Rak(string nama)
        {
            try
            {
                //MessageBox.Show(nama);
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT IdRak FROM RAKBUKU WHERE NamaRak = \'" + nama + "\'";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Rak = Int16.Parse(reader.GetInt16(0).ToString());
                }
                connection.Close();
            }
            catch (SqlException )
            {
                connection.Close();
            }
            //MessageBox.Show(Rak.ToString());
            return Rak;
        }

        public DataSet BukuDisplay()
        {
            DataSet data = new DataSet();
            try
            {
                query = "SELECT IdBuku, Judul, Pengarang, Penerbit, ThnTerbit AS'Tahun Terbit'," +
                    "Buku.TmptTerbit AS'Tempat Terbit', Buku.TotalHlmn AS 'Jumlah Halaman', Buku.ISBN," +
                    "Buku.Stok,KATAGORI.Katagori AS 'Katagori',RAKBUKU.NamaRak AS 'Rak',Deskripsi FROM Buku " +
                    "INNER JOIN KATAGORI ON Buku.IdKatagori = KATAGORI.IdKatagori " +
                    "INNER JOIN RAKBUKU ON Buku.IdRak = RAKBUKU.IdRak WHERE IdBuku >= " + Display;
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(data, "Buku");
                connection.Close();
            }
            catch (SqlException)
            {
                connection.Close();
            }
            return data;
        }

        public DataSet CaridanTampil()
        {
            DataSet data = new DataSet();
            try
            {
                query = "SELECT IdBuku, Judul, Pengarang, Penerbit, ThnTerbit AS'Tahun Terbit'," +
                    "Buku.TmptTerbit AS'Tempat Terbit', Buku.TotalHlmn AS 'Jumlah Halaman', Buku.ISBN," +
                    "Buku.Stok,KATAGORI.Katagori AS 'Katagori',RAKBUKU.NamaRak AS 'Rak',Deskripsi FROM Buku " +
                    "INNER JOIN KATAGORI ON Buku.IdKatagori = KATAGORI.IdKatagori " +
                    "INNER JOIN RAKBUKU ON Buku.IdRak = RAKBUKU.IdRak WHERE Judul LIKE  \'" + Cari + "%\'";
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = query;
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(data, "Buku");
                //status1 = true;
                connection.Close();
            }
            catch
            {
                connection.Close();
            }
            return data;
        }
    }
}

