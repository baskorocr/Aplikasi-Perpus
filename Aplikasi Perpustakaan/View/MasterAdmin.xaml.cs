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
    /// Interaction logic for MasterAdmin.xaml
    /// </summary>
    public partial class MasterAdmin : Window
    {
        Controller.MasterAdminController controller;
        private Boolean hasil;

        public MasterAdmin()
        {
            InitializeComponent();
            controller = new Controller.MasterAdminController(this);
            tampilData();
        }

        public void tampilData()
        {
            controller.SelectAdmin();
        }
        private void btnKeluar_Click(object sender, RoutedEventArgs e)
        {
            GC.Collect();
            this.Close();
        }
        private void btnSimpan_Click(object sender, RoutedEventArgs e)
        {
            hasil = controller.InsertAdmin();
            if (hasil == true)
            {
                MessageBox.Show("Admin Berhasil disimpan");
            }
            else
            {
                MessageBox.Show("Penyimpanan admin gagal");
            }
            tampilData();
        }
        private void btnHapus_Click(object sender, RoutedEventArgs e)
        {
            hasil = controller.DeleteAdmin();
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
        private void btnTambah_Click(object sender, RoutedEventArgs e)
        {
            hasil = controller.UpdateDataSiswa();
            if (hasil == true)
            {
                MessageBox.Show("Kelas Berhasil diperbarui");
            }
            else
            {
                MessageBox.Show("Kelas gagal diperbarui");
            }
            tampilData();
        }
        private void btnCari_Click(object sender, RoutedEventArgs e)
        {
            controller.Cari();
        }
    }
}
