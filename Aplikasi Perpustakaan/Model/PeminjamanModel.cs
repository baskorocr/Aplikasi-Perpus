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
    class PeminjamanModel
    {
        private SqlConnection connection;
        private SqlCommand command;
        private string query;
        private Boolean status;

        public PeminjamanModel()
        {
            connection = DbConnection.GetConnection();
        }

        private int   jumlahbuku, lamapinjam, stok,telat, maxpinjam;
        private string nis, idbuku, tglpinjam, idpinjam, statussql, tglkembali ;

        public string IdPinjam { get { return idpinjam; } set { idpinjam = value; } }
        public string Nis { get { return nis; } set { nis = value; } }
        public string IdBuku { get { return idbuku; } set { idbuku = value; } }
        public int Jumlambuku { get { return jumlahbuku; } set { jumlahbuku = value; } }
        public int LamaPinjam { get { return lamapinjam; } set { lamapinjam = value; } }
        public int Stok { get { return stok; } set { stok = value; } }
        public int Telat { get { return telat; } set { telat = value; } }
        public int MaxPinjam { get { return maxpinjam; } set { maxpinjam = value; } }
        public string TglPinjam { get { return tglpinjam; } set { tglpinjam = value; } }
        public string StatusSql { get { return statussql; } set { statussql = value; } }
        public string TglKembali { get { return tglkembali; } set { tglkembali = value; } }
        





        public DataSet SelectPeminjaman()
        {
            DataSet ds = new DataSet();
            try
            {
                query = "SELECT IdPinjam, Peminjaman.NIS, SISWA.Nama, TglPinjam AS 'Tanggal Pinjam',TglKembali AS 'Tanggal Kembali', Peminjaman.IdBuku, Buku.Judul, LamaPinjam, Peminjaman.Status, Telat,JumlahPinjam " +
                    "FROM Peminjaman INNER JOIN SISWA ON Peminjaman.NIS = SISWA.NIS INNER JOIN Buku ON Peminjaman.IdBuku = Buku.IdBuku";
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(ds, "Peminjaman");
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
                query = "INSERT INTO Peminjaman (IdPinjam, NIS, IdBuku, TglPinjam, TglKembali, LamaPinjam, Status, Telat, JumlahPinjam)" +
                    "VALUES('"+IdPinjam+"', '"+Nis+"', '"+IdBuku+"', '"+TglPinjam+"', '"+TglKembali+"', "+LamaPinjam+", 'Di Pinjam', '"+Telat+"', '"+Jumlambuku+"')";
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
                connection.Close();
            }
            return status;
        }


        //mengambil data nama anggota berdasarkan nis
        public string NamaSiswa(string nama)
        {
            string siswa = " ";
            try
            {
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT Nama FROM SISWA WHERE NIS = \'" + nama + "\'";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    siswa = reader.GetString(0);
                }
                connection.Close();
            }
            catch (SqlException)
            {
                siswa= " nama tidak ditemukan ";
            }
            return siswa;
        }

        //mengambil data kelas dari anggota berdasarkan nis
        public string KelasSiswa(string nama)
        {
            string kelas = " ";
            try
            {
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT Kelas, NIS FROM SISWA INNER JOIN KELAS ON SISWA.IdKelas=Kelas.IdKelas WHERE NIS = \'" + nama + "\'";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    kelas = reader.GetString(0);
                }
                connection.Close();
            }
            catch (SqlException)
            {
            }
            return kelas;
        }

        //mengambil data judul buku dari databese berdasarkan nis yang diinputkan
        public string JudulBuku(string nama)
        {
            string judul = " ";
            try
            {
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT Judul FROM BUKU WHERE IdBuku = \'" + nama + "\'";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    judul = reader.GetString(0);
                }
                connection.Close();
            }
            catch (SqlException)
            {
                connection.Close();
            }
            return judul;
        }

        //cek ketersediaan idbuku
        public Boolean CekIdBuku(string nama)
        {
            string cek = " ";
            status = false;
            try
            {
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT Judul FROM BUKU WHERE IdBuku = \'" + nama + "\'";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cek = reader.GetString(0);
                    if(cek == " ")
                        status = false;
                    else
                        status = true;
                }
                connection.Close();
            }
            catch (SqlException)
            {
                status = false;
            }
            return status;
        }

        //cek keterdiediaan kode anggota
        public Boolean CekIdSiswa(string nama)
        {
            string cek = " ";
            status = false;
            try
            {
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM SISWA WHERE NIS = \'" + nama + "\'";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    cek = reader.GetString(1);
                    if (cek == " ")
                        status = false;
                    else
                        status = true;
                }
                connection.Close();
            }
            catch (SqlException)
            {
                status = false;
            }
            return status;
        }

        //menampilkan isi data lamapinjam
        public int LamaPinjamFill()
        {
            int kode = 0;
            try
            {
                query = "SELECT LamaPinjam FROM Setting ";
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = query;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    kode = Int16.Parse(reader.GetByte(0).ToString());
                }
                connection.Close();
            }
            catch (SqlException)
            {
                kode = 0;
            }
            return kode;
        }

        //Mengambil nilai jumlah stok buku
        public int StokBukuLama(string nama)
        {
            int kode = 0;
            try
            {
                connection.Open(); 
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT Stok FROM BUKU WHERE IdBuku = \'" + nama+"\'";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    kode = Int16.Parse(reader.GetByte(0).ToString());
                }
                connection.Close();
            }
            catch (SqlException)
            {
            }
            return kode;
        }

        public int MaxPinjamSiswaFill(string nama)
        {
            int kode = 0;
            try
            {
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT MaxPinjam FROM SISWA WHERE NIS = \'" + nama + "\' ";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    kode = Int16.Parse(reader.GetByte(0).ToString());
                }
                connection.Close();
            }
            catch (SqlException)
            {
            }
            return kode;
        }

        //Update jumlah stok buku
        public Boolean UpdateStokBuku()
        {
            status = false;
            try
            {
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE BUKU SET Stok = '" + Stok + "'  WHERE IdBuku = \'"+ IdBuku +"\' ";
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

        //untuk update max peminjaman di tabel siswa
        public Boolean UpdateMaxPinjamSiswa()
        {
            status = false;
            try
            {
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE SISWA SET MaxPinjam = '" + MaxPinjam + "' WHERE NIS = \'" + Nis+"\'";
                command.ExecuteNonQuery();
                status = true;
                connection.Close();
            }
            catch (SqlException)
            {
            }
            return status;
        }

        //get update tanggal pengembalian
        public string GetUpdateTanggal()
        {
            string tanggal = " ";
            try
            {
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT MAX(UpdateTanggal) FROM Peminjaman";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tanggal = reader.GetDateTime(0).ToString("yyyy-MM-dd");
                }
                connection.Close();
            }
            catch (SqlException)
            {
            }
            return tanggal;
        }

        public Boolean UpdateTelat()
        {
            status = false;
            try
            {
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE Peminjaman SET Telat = Telat + 1 ";
                command.ExecuteNonQuery();
                connection.Close();
                status = true;
            }
            catch (SqlException)
            {
            }
            return status;
        }

        public Boolean UpdateTanggal()
        {
            status = false;
            try
            {
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE Peminjaman SET UpdateTanggal = \'" + DateTime.Today.ToString("yyyy-MM-dd")+"\'";
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

        public string GenerateCode()
        {
            int ii = 0;
            string i = "" , GetCode = " ";
            try
            {
                query = "SELECT COUNT(IdPinjam) from Peminjaman";
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = query;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ii = reader.GetInt32(0) + 1;
                    i = ii.ToString();
                    if (ii <= 9)
                    {
                        GetCode = "PJM00000" + i;
                    }
                    if (ii > 9)
                    {
                        GetCode = "PJM0000" + i;
                    }
                    if (ii > 99)
                    {
                        GetCode = "PJM000" + i;
                    }
                    if (ii > 999)
                    {
                        GetCode = "PJM00" + i;
                    }
                    if (ii > 9999)
                    {
                        GetCode = "PJM0" + i;
                    }
                    if (ii > 99999)
                    {
                        GetCode = "PJM" + i;
                    }
                }
                connection.Close();
            }
            catch
            {

            }
            return GetCode;
        }
    }
}
