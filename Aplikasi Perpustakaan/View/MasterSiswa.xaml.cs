using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Aplikasi_Perpustakaan.View
{
    /// <summary>
    /// Interaction logic for MasterSiswa.xaml
    /// </summary>
    public partial class MasterSiswa : Window
    {
        public MasterSiswa()
        {
            InitializeComponent(); controller = new Controller.SiswaController(this);
            TampilData();
            ComboIsi();
        }

        Controller.SiswaController controller;

        private Boolean hasil;


        private void btnKeluar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        public void Kosongkan()
        {
            this.txtAlamat.Text = "";
            this.txtAngkatan.Text = "";
            //this.txtCari.Text = "Cari Nama Siswa";
            this.txtNamaSiswa.Text = "";
            this.txtNIS.Text = "";
            this.txtTelepon.Text = "";
            this.cmbJenisKel.Text = "--Pilih Jenis Kelamin--";
            this.cmbKelas.Text = "--Pilih Kelas--";
            this.cmbStatus.Text = "--Pilih Status--";
        }
        public void TampilData()
        {
            controller.SelectDataSiswa();
        }

        private void btnSimpan_Click(object sender, RoutedEventArgs e)
        {
            hasil = controller.InsertDataSiswa();
            if (hasil)
            {
                MessageBox.Show("Data berhasil Disimpan");
                Kosongkan();
                TampilData();
            }
            else
            {
                MessageBox.Show("Menyimpan data gagal");
            }
        }

        private void btnUbah_Click(object sender, RoutedEventArgs e)
        {
            hasil = controller.UpdateDataSiswa();
            if (hasil)
            {
                MessageBox.Show("Data berhasil diubah");
                Kosongkan();
                TampilData();
            }
            else
            {
                MessageBox.Show("Mengubah data gagal, pastikan nomor NIS/Kode sesuai");
            }
            //TampilData();
        }

        private void btnHapus_Click(object sender, RoutedEventArgs e)
        {
            hasil = controller.DeleteDataSiswa();
            if (hasil)
            {
                MessageBox.Show("Data berhasil Dihapus");
                Kosongkan();
                TampilData();
            }
            else
            {
                MessageBox.Show("Menghapus data gagal, pastikan nomor NIS/Kode sesuai");
            }
        }

        private void btnCari_Click(object sender, RoutedEventArgs e)
        {
            controller.CaridanTampil();
        }

        public void ComboIsi()
        {
            cmbKelas.IsEditable = true;
            cmbKelas.IsTextSearchEnabled = true;
        }

        private void btnTampilDisplay_Click(object sender, RoutedEventArgs e)
        {
            controller.Display();
        }
    }
}
