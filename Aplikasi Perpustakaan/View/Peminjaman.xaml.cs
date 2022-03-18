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
    /// Interaction logic for Peminjaman.xaml
    /// </summary>
    public partial class Peminjaman : Window
    {
        Controller.PeminjamanController controller;
        public Peminjaman()
        {
            InitializeComponent();
            controller = new Controller.PeminjamanController(this);
            Tampil();
        }

        private Boolean hasil;
        

        public void KosongkanText()
        {
            txtIdBuku.Text = "IdBuku";
            txtIdNIS.Text = "NIS";
            txtIsiIdPinjam.Text = " ";
            txtJudul.Text = "";
            txtJumalhBuku.Text = "";
            txtKelas.Text = "";
            txtNamaAnggota.Text = "";
            txtTanggalPinjam.Text = "";
            txtIsiIdPinjam.IsEnabled = false;
            txtJumalhBuku.IsEnabled = false;
            txtIdNIS.IsEnabled = true;
            txtIdBuku.IsEnabled = true;
            btnTambahkan.IsEnabled = true;
            
        }

        public void Tampil()
        {
            controller.SelectPeminjaman();
            controller.CekUpdateTelat();
        }


        private void btn_back(object sender, RoutedEventArgs e)
        {
            MainWindow back = new MainWindow();
            this.Close();
        }

        private void btnTambahkan_Click(object sender, RoutedEventArgs e)
        {
            hasil = controller.CekId();
            if (hasil)
            {
                controller.fillTextBox();
                btnSimpan.IsEnabled = true;
                btnBaru.IsEnabled = true;
                btnTambahkan.IsEnabled = false;
                txtJumalhBuku.IsEnabled = true;
                txtTanggalPinjam.Text = DateTime.Today.ToString("dd-MM-yyyy");
                txtIdBuku.IsEnabled = false;
                txtIdNIS.IsEnabled = false;
                txtJumalhBuku.Focus();
            }
            else
            {
                MessageBox.Show(" NIS atau IdBuku tidak ditemukan. \n Pastikan NIS dan IdBuku susuai :) ");
            }

        }

        private void btnSimpan_Click(object sender, RoutedEventArgs e)
        {
            hasil = controller.InsertPeminjaman();
            if (hasil)
            {
                MessageBox.Show("Data berhasil disimpan");
                KosongkanText();
                btnSimpan.IsEnabled = false;
                btnBaru.IsEnabled = false;
                Tampil();
            }
            else
            {
                MessageBox.Show(" Data Gagal Disimpan.");
            }
        }

        private void btnBaru_Click(object sender, RoutedEventArgs e)
        {
            KosongkanText();
            btnSimpan.IsEnabled = false;
            btnBaru.IsEnabled = false;
        }
    }
}
