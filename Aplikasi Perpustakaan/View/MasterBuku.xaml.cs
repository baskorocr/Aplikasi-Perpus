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
    /// Interaction logic for MasterBuku.xaml
    /// </summary>
    public partial class MasterBuku : Window
    {
        Controller.BukuController controller;
        public MasterBuku()
        {
            InitializeComponent();

            controller = new Controller.BukuController(this);
            TampilData();
            ComboIsi();
        }

        public Boolean hasil;

        public void Kosongkan()
        {
            this.txtCari.Text = "";
            this.txtDeskripsi.Text = "";
            this.txtIdBuku.Text = "";
            this.txtIsbn.Text = "";
            this.txtJudulBuku.Text = "";
            this.txtJumlahBuku.Text = "";
            this.txtJumlahHalaman.Text = "";
            this.txtPenerbit.Text = "";
            this.txtPengarang.Text = ""; 
            this.txtTahunTerbit.Text = "";
            this.txtTmptTerbit.Text = "";
            this.cmbKategori.Text = "--Pilih Kategori--";
            this.cmbRak.Text = "--Pilih Rak--";
        }


        private void btnKeluar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void TampilData()
        {
            controller.SelectDataBuku();
        }

        private void btnSimpan_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(cmbKategori.SelectedItem.ToString());
            hasil = controller.InsertDataBuku();
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
            //Kosongkan();
            //TampilData();
        }

        private void btnUbah_Click(object sender, RoutedEventArgs e)
        {
            hasil = controller.UpdateDataBuku();
            if (hasil)
            {
                MessageBox.Show("Data berhasil Disimpan");
                Kosongkan();
                TampilData();
            }
            else
            {
                MessageBox.Show("Mengubah data gagal\n Pastikan Id buku sudah sesuai");
            }
            //Kosongkan();
            //TampilData();
        }

        private void btnHapus_Click(object sender, RoutedEventArgs e)
        {
            hasil = controller.DeleteDataBuku();
            if (hasil)
            {
                MessageBox.Show("Data berhasil Dihapus");
                Kosongkan();
                TampilData();
            }
            else
            {
                MessageBox.Show("Menghapus data gagal\n Pastikan Id Buku sudah sesuai");
            }
            //Kosongkan();
            //TampilData();
        }

        public void ComboIsi()
        {
            cmbKategori.IsEditable = true;
            cmbKategori.IsEnabled = true;
            cmbKategori.IsTextSearchEnabled = true;
            cmbRak.IsEnabled = true;
            cmbRak.IsTextSearchEnabled = true;
        }

        private void btnCari_Click(object sender, RoutedEventArgs e)
        {
            controller.Cari();
        }

        private void btnTampilDisplay_Click(object sender, RoutedEventArgs e)
        {
            controller.Display();
        }
    }
}
