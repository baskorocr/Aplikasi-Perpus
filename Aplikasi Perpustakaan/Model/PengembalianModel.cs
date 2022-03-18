using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Aplikasi_Perpustakaan.Model
{
    class PengembalianModel
    {
        private SqlConnection connection;
        private SqlCommand command;
        private string query;
        private bool result;


        public PengembalianModel()
        {
            connection = DbConnection.GetConnection();
        }

        private string cari, jumlahPinjam, nama, idPinjam, tglPinjam, tglBalik, idBuku, judulBuku, statusPerminjaman, tglTerkini, telat;
        private int temp, lamaPinjam, denda;

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
        public string JumlahPinjam
        {
            get
            {
                return jumlahPinjam;
            }
            set
            {
                jumlahPinjam = value;
            }
        }

        public string Nama
        {
            get
            {
                return nama;
            }
            set
            {
                nama = value;
            }
        }

        public string IdPinjam
        {
            get
            {
                return idPinjam;
            }
            set
            {
                idPinjam = value;
            }
        }
        public string TglPinjam
        {
            get
            {
                return tglPinjam;
            }
            set
            {
                tglPinjam = value;
            }
        }
        public string TglBalik
        {
            get
            {
                return tglBalik;
            }
            set
            {
                tglBalik = value;
            }
        }

        public string IdBuku
        {
            get
            {
                return idBuku;
            }
            set
            {
                idBuku = value;
            }
        }
        public string JudulBuku
        {
            get
            {
                return judulBuku;
            }
            set
            {
                judulBuku = value;
            }
        }

        public string StatusPerminjaman
        {
            get
            {
                return statusPerminjaman;
            }
            set
            {
                statusPerminjaman = value;
            }
        }
        public string TglKini
        {
            get
            {
                return tglTerkini;
            }
            set
            {
                tglTerkini = value;
            }
        }


        public int Temp
        {
            get
            {
                return temp;
            }
            set
            {
                temp = value;
            }
        }

        public int LamaPinjam
        {
            get
            {
                return lamaPinjam;
            }
            set
            {
                lamaPinjam = value;
            }
        }

        public string Telat
        {
            get
            {
                return telat;
            }
            set
            {
                telat = value;
            }
        }

        public int Denda
        {
            get
            {
                return denda;
            }
            set
            {
                denda = value;
            }
        }

        public Boolean CariData()
        {
            result = false;

            try
            {
                query = "SELECT SISWA.Nama, Count(Peminjaman.IdPinjam) as 'Total' FROM SISWA inner join Peminjaman ON SISWA.NIS = Peminjaman.NIS WHERE Peminjaman.NIS = '"+cari+"' GROUP BY SISWA.Nama";
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = query;
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {

                    JumlahPinjam = dataReader.GetInt32(1).ToString();
                    Nama = dataReader.GetString(0).ToString();
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

        public Boolean TampungData()
        {
            //DateTime TglKini = DateTime.Today;
            result = false;

            try
            {
                query = "SELECT SISWA.Nama,Peminjaman.IdBuku,Peminjaman.Telat FROM SISWA INNER JOIN Peminjaman ON SISWA.NIS = Peminjaman.NIS WHERE Peminjaman.IdPinjam = '"+idPinjam+"'";
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = query;
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Nama = dataReader.GetString(0).ToString();
                    IdBuku = dataReader.GetString(1).ToString();
                    Telat = dataReader.GetInt16(2).ToString();
                    int back = int.Parse(Telat);
                    // DateTime balik = DateTime.Parse(TglBalik);
                    //TimeSpan ts = new TimeSpan();
                    //ts = TglKini.Subtract(balik);
                    //Telat = ts.Days;
                    if (back > 0)
                    {
                        Denda = back * 3000;
                    }
                    else
                    {
                        Denda = 0 * 3000;
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

        public DataSet SelectDataPeminjaman()
        {
            DataSet ds = new DataSet();
            try
            {
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT Peminjaman.IdPinjam,Peminjaman.NIS,SISWA.Nama,Peminjaman.TglPinjam,Peminjaman.TglKembali,Peminjaman.IdBuku,Buku.Judul,Peminjaman.LamaPinjam,Peminjaman.Status,Peminjaman.Telat,Peminjaman.JumlahPinjam from SISWA,Peminjaman inner join Buku on Peminjaman.IdBuku = Buku.IdBuku where SISWA.NIS = '"+cari+"'";
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(ds, "Peminjaman");

                connection.Close();
            }
            catch (SqlException)
            {

            }
            return ds;
        }

        public DataSet SelectDataPengembalian()
        {
            DataSet ds = new DataSet();
            try
            {
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT Pengembalian.IdPengembalian,Pengembalian.NIS,SISWA.Nama,Pengembalian.IdBuku,Buku.Judul,Pengembalian.TglDiKembalikan,Pengembalian.Denda,Pengembalian.status from SISWA,Pengembalian inner join Buku on Pengembalian.IdBuku = Buku.IdBuku WHERE SISWA.NIS = Pengembalian.NIS";
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(ds, "Pengembalian");

                connection.Close();
            }
            catch (SqlException)
            {

            }
            return ds;
        }

        public Boolean InsertPengembalian()
        {

            result = false;
            try
            {
                query = "INSERT INTO Pengembalian values('" + idPinjam + "','" + cari + "','" + idBuku + "','" + DateTime.Today + "'," + denda + ",'Kembali')";
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

        public Boolean InsertKasMasuk()
        {

            result = false;
            try
            {
                query = "INSERT INTO Kas values("+denda+",0,'"+Model.AdminModel.tampungNama+"','Denda Peminjaman')";
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
        public DataSet SelectDataCariPengembalian()
        {
            DataSet ds = new DataSet();
            try
            {
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT Pengembalian.IdPengembalian, Pengembalian.NIS,SISWA.Nama,Pengembalian.IdBuku,Buku.Judul,Pengembalian.TglDiKembalikan,Pengembalian.Denda,Pengembalian.status from SISWA,Pengembalian inner join Buku on Pengembalian.IdBuku = Buku.IdBuku WHERE SISWA.NIS = '"+cari+"'";
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(ds, "Peminjaman");

                connection.Close();
            }
            catch (SqlException)
            {

            }
            return ds;
        }
        public Boolean DeletePeminjaman()
        {

            result = false;
            try
            {
                query = "DELETE FROM Peminjaman WHERE IdPinjam = '"+idPinjam+"'";
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

        public Boolean UpdateJmlBuku()
        {

            result = false;
            try
            {
                query = "UPDATE Buku SET Stok = Stok+1  WHERE IdBuku='"+idBuku+"' ";
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
    }
}
