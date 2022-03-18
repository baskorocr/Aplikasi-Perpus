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
    /// Interaction logic for rakBuku.xaml
    /// </summary>
    public partial class rakBuku : Window
    {
        Controller.RakController controller;
        private String proses;
        private Boolean hasil;
        public rakBuku()
        {
            proses = "";
            InitializeComponent();
            controller = new Controller.RakController(this);
            AturButton(true);
            string[] str = new string[] { "4", "6", "8", "99" };
            cmbDisplay.ItemsSource = str;
            tampilData();
        }

        public void tampilData()
        {
            controller.SelectRak();
        }
        public void AturText(Boolean status)
        {
            txtRak.IsEnabled = status;
            txtId.IsEnabled = !status;
        }
        public void AturButton(Boolean status)
        {
            btnTambah.IsEnabled = status;
            btnSimpan.IsEnabled = !status;
            btnDelete.IsEnabled = status;
        }

        private void btnKeluar_Click(object sender, RoutedEventArgs e)
        {
            GC.Collect();
            this.Close();
        }

        private void btnCari_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCari_Click_1(object sender, RoutedEventArgs e)
        {
            controller.Cari();
        }

        private void cmbDisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            controller.Display();
        }

        private void btnTambah_Click(object sender, RoutedEventArgs e)
        {
            proses = "INSERT";
            AturText(true);
            AturButton(false);

            txtId.Text = "";
            controller.SetKode();
            txtRak.Text = "";
            txtRak.Focus();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            hasil = controller.DeleteRak();
            if (hasil == true)
            {
                MessageBox.Show("Kelas Berhasil dihapus");
            }
            else
            {
                MessageBox.Show("Kelas gagal dihapus");
            }
            tampilData();
        }

        private void btnSimpan_Click(object sender, RoutedEventArgs e)
        {
            if (proses == "INSERT")
            {
                hasil = controller.InsertRak();
            }
            if (hasil == true)
            {
                MessageBox.Show("Kelas Berhasil disimpan");
            }
            else
            {
                MessageBox.Show("Penyimpanan kelas gagal");
            }
            tampilData();
            AturButton(true);
        }
    }
}
