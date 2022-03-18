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
    class SiswaModel
    {
        private SqlConnection connection;
        private SqlCommand command;
        private string query;

        public SiswaModel()
        {
            connection = DbConnection.GetConnection();
        }

        private int kelas, kelasid, display, maxpinjam ;
        private string nis, nama, thnAngkatan, jenisKel, noTelpon, status, alamat, cari;
        //private string display;
        private Boolean status1;

        public string Nis { get { return nis; } set { nis = value; } }
        public string Nama { get { return nama; } set { nama = value; } }
        public int Kelas { get { return kelas; } set { kelas = value; } }
        public string ThnAngkatan { get { return thnAngkatan; } set { thnAngkatan = value; } }
        public string JenisKel { get { return jenisKel; } set { jenisKel = value; } }
        public string NoTelpon { get { return noTelpon; } set { noTelpon = value; } }
        public string Status { get { return status; } set { status = value; } }
        public string Alamat { get { return alamat; } set { alamat = value; } }
        public string Cari { get { return cari; } set { cari = value; } }
        public int Display { get { return display; } set { display = value; } }
        public int KelasId { get { return kelasid; } set { kelasid = value; } }
        public int MaxPinjam { get { return maxpinjam; } set { maxpinjam = value; } }





        public DataSet SelectDataSiswa()
        {
            DataSet ds = new DataSet();
            try
            {
                query = "SELECT NIS, Nama, KELAS.Kelas, ThnAngkatan AS 'Angkatan',JenisKel AS 'Jenis Kelamin',NoTelpon,Status, Alamat, MaxPinjam "+
                    "FROM SISWA INNER JOIN KELAS ON SISWA.IdKelas=KELAS.IdKelas";
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(ds, "SISWA");
                connection.Close();
            }
            catch
            {
                connection.Close();
            }
            return ds;
        }

        public Boolean InsertDataSiswa()
        {
            status1 = false;
            try
            {
                query = "INSERT INTO SISWA VALUES ('" + Nis + "','" + Nama + "'," + Kelas + ",'"
                    + ThnAngkatan + "','" + JenisKel + "','" + NoTelpon + "','" + Status + "','" + Alamat + "',"+MaxPinjam+")";
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = query;
                command.ExecuteNonQuery();
                status1 = true;
                connection.Close();

            }
            catch(SqlException)
            {
                status1 = false;
                connection.Close();
            }
            return status1;
        }

        public Boolean UpdateDataSiswa()
        {
            status1 = false;
            try
            {
                query = "UPDATE SISWA SET  Nama = '" + Nama + "', IdKelas = " + Kelas +", ThnAngkatan = '" + ThnAngkatan + "', JenisKel = '" + JenisKel + "', NoTelpon = '" + NoTelpon + "', Status = '" + Status + "', Alamat = '" + Alamat + "' WHERE NIS = " + Nis;
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = query;
                command.ExecuteNonQuery();
                status1 = true;
                connection.Close();
            }
            catch (SqlException)
            {
                status1 = false;
                connection.Close();
            }
            return status1;
        }

        public DataSet CaridanTampil()
        {
            DataSet data = new DataSet();
            try
            {
                //MessageBox.Show(Cari);
                query = "SELECT NIS, Nama, KELAS.Kelas, ThnAngkatan AS 'Angkatan',JenisKel AS 'Jenis Kelamin',NoTelpon,Status, Alamat FROM SISWA" +
                    "INNER JOIN KELAS ON SISWA.IdKelas = KELAS.IdKelas WHERE NAMA LIKE  \'" + Cari + "%\'";
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = query;
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(data, "SISWA");
                //status1 = true;
                connection.Close();
            }
            catch 
            {
                
            }
            return data;
        }

        public DataSet SiswaDisplya()
        {
            DataSet data = new DataSet();
            try
            {
                //MessageBox.Show(Display.ToString());
                query = "SELECT TOP 10 NIS, Nama, Kelas.Kelas, ThnAngkatan AS 'Angkatan',JenisKel AS 'Jenis Kelamin', NoTelpon, Status, Alamat FROM SISWA " +
                    " INNER JOIN KELAS ON SISWA.IdKelas = KELAS.IdKelas WHERE SISWA.NIS >= " + Display+" ";
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                //command.CommandText = "SELECT TOP 10 * FROM Siswa WHERE NIS >=";
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(data, "SISWA");
                connection.Close();
            }
            catch (SqlException)
            {
                connection.Close();
            }
            return data;
        }

        public Boolean DeleteDataSiswa()
        {
            status1 = false;
            try
            {
                query = "DELETE FROM  SISWA  WHERE NIS = " + Nis;
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = query;                
                command.ExecuteNonQuery();
                status1 = true;
                connection.Close();
            }
            catch (SqlException)
            {
                status1 = false; 
            }
            return status1;
        }

        //Mengisi combo box
        public List<string> fillComboRak()
        {
            List<string> comboArrayList = new List<string>();
            StringBuilder sb = new StringBuilder();
            try
            {
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT Kelas FROM KELAS";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var ii = reader.FieldCount;
                    for(int i=0; i<ii; i++)
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
            }
            return comboArrayList;
        }

        //untuk mengisi ID KELAS sesuai nama kelas dari combobox
        public int Id_Kelas(string nama)
        {
            try
            {
                connection.Open();
                command = new SqlCommand();
                command = connection.CreateCommand();
                command.CommandText = "SELECT top 1 * FROM KELAS WHERE Kelas = \'"+nama+"\' ";
                SqlDataReader reader = command.ExecuteReader();
                //SqlDataAdapter sda = new SqlDataAdapter(command);
                while (reader.Read())
                {
                    KelasId = Int16.Parse(reader.GetInt16(0).ToString());
                }
                connection.Close();
            }
            catch 
            {
                connection.Close();
            }
            return KelasId;
        }

        //Mengambil nilai maxpinjam
        public int MaxPinjamFill()
        {
            int kode = 0;
            try
            {
                query = "SELECT MaxPinjam FROM Setting WHERE IdSetting IN (SELECT MAX(IdSetting)FROM Setting)";
                connection.Open();
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
                connection.Close();
            }
            return kode;
        }
    }
}
