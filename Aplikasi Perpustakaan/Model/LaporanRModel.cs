using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Aplikasi_Perpustakaan.Model
{
    class LaporanRModel
    {
        private SqlConnection connectionn;
        private SqlCommand command;
        private String cari;
        private String datetime_asal;
        private String datetime_sampai;
        private int display;
        public string Cari
        {
            get { return cari; }
            set { cari = value; }
        }
        public string Asal
        {
            get { return datetime_asal; }
            set { datetime_asal = value; }
        }
        public string Sampai
        {
            get { return datetime_sampai; }
            set { datetime_sampai = value; }
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

        public LaporanRModel()
        {
            connectionn = DbConnection.GetConnection();
        }
        public DataSet SelectLaporanAdmin()
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

        public DataSet SelectLaporanPeminjaman()
        {
            DataSet ds = new DataSet();
            try
            {
                connectionn.Open();
                command = new SqlCommand();
                command.Connection = connectionn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT Peminjaman.IdPinjam,Peminjaman.NIS,SISWA.Nama,Peminjaman.TglPinjam,Peminjaman.TglKembali,Peminjaman.IdBuku,Buku.Judul,Peminjaman.LamaPinjam,Peminjaman.Status,Peminjaman.Telat,Peminjaman.JumlahPinjam from SISWA,Peminjaman inner join Buku on Peminjaman.IdBuku = Buku.IdBuku where SISWA.NIS = Peminjaman.NIS";
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(ds, "Peminjaman");
                connectionn.Close();
            }
            catch (SqlException)
            {

            }
            return ds;
        }

        public DataSet SelectLaporanPengunjung()
        {
            DataSet ds = new DataSet();
            try
            {
                connectionn.Open();
                command = new SqlCommand();
                command.Connection = connectionn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM Pengunjung";
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(ds, "Pengunjung");
                connectionn.Close();
            }
            catch (SqlException)
            {

            }
            return ds;
        }

        public DataSet SelectLaporanSiswa()
        {
            DataSet ds = new DataSet();
            try
            {
                connectionn.Open();
                command = new SqlCommand();
                command.Connection = connectionn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM Siswa";
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(ds, "Siswa");
                connectionn.Close();
            }
            catch (SqlException)
            {

            }
            return ds;
        }

        public DataSet SearchLaporanAdmin()
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
                sda.Fill(ds, "Admin");

                connectionn.Close();
            }
            catch (SqlException)
            {

            }
            return ds;
        }

        public DataSet SearchLaporanPeminjaman()
        {
            DataSet ds = new DataSet();
            try
            {
                connectionn.Open();
                command = new SqlCommand();
                command.Connection = connectionn;
                command.CommandType = CommandType.Text;
                command.CommandText = " SELECT Peminjaman.IdPinjam,Peminjaman.NIS,SISWA.Nama,Peminjaman.TglPinjam,Peminjaman.TglKembali,Peminjaman.IdBuku,Buku.Judul,Peminjaman.LamaPinjam,Peminjaman.Status,Peminjaman.Telat,Peminjaman.JumlahPinjam from SISWA,Peminjaman inner join Buku on Peminjaman.IdBuku = Buku.IdBuku where SISWA.NIS = Peminjaman.NIS and Peminjaman.IdPinjam = '"+cari+"'";
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(ds, "Peminjaman");

                connectionn.Close();
            }
            catch (SqlException)
            {

            }
            return ds;
        }

        public DataSet TampilLaporanPengunjung()
        {
            DataSet ds = new DataSet();
            try
            {
                connectionn.Open();
                command = new SqlCommand();
                command.Connection = connectionn;
                command.CommandType = CommandType.Text;
                command.CommandText = " select * from Pengunjung WHERE NIS BETWEEN '" + Asal + "' AND '" + Sampai + "'";
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(ds, "Admin");

                connectionn.Close();
            }
            catch (SqlException)
            {

            }
            return ds;
        }

        public DataSet SearchLaporanPengunjung()
        {
            DataSet ds = new DataSet();
            try
            {
                connectionn.Open();
                command = new SqlCommand();
                command.Connection = connectionn;
                command.CommandType = CommandType.Text;
                command.CommandText = " select * from Pengunjung WHERE NIS like '%" + cari + "%'";
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(ds, "Siswa");

                connectionn.Close();
            }
            catch (SqlException)
            {

            }
            return ds;
        }
        public DataSet SearchLaporanSiswa()
        {
            DataSet ds = new DataSet();
            try
            {
                connectionn.Open();
                command = new SqlCommand();
                command.Connection = connectionn;
                command.CommandType = CommandType.Text;
                command.CommandText = " select top 1 * from SISWA WHERE NIS like '%" + cari + "%'";
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(ds, "Siswa");

                connectionn.Close();
            }
            catch (SqlException)
            {

            }
            return ds;
        }

        public DataSet LaporanPeminjamanDisplay()
        {
            DataSet ds = new DataSet();
            try
            {
                connectionn.Open();
                command = new SqlCommand();
                command.Connection = connectionn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT TOP "+display+" Peminjaman.IdPinjam,Peminjaman.NIS,SISWA.Nama,Peminjaman.TglPinjam,Peminjaman.TglKembali,Peminjaman.IdBuku,Buku.Judul,Peminjaman.LamaPinjam,Peminjaman.Status,Peminjaman.Telat,Peminjaman.JumlahPinjam from SISWA,Peminjaman inner join Buku on Peminjaman.IdBuku = Buku.IdBuku where SISWA.NIS = Peminjaman.NIS";
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(ds, "KELAS");

                connectionn.Close();
            }
            catch (SqlException)
            {

            }
            return ds;
        }
        public DataSet AdminDisplay()
        {
            DataSet ds = new DataSet();
            try
            {
                connectionn.Open();
                command = new SqlCommand();
                command.Connection = connectionn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT TOP " + display + " * From Admin";
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
