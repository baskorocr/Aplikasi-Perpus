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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Aplikasi_Perpustakaan.View
{
    /// <summary>
    /// Interaction logic for laporanMaster.xaml
    /// </summary>
    public partial class laporanMaster : Page
    {
        public laporanMaster()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LaporanKasMasuk laporanmasuk = new LaporanKasMasuk();
            laporanmasuk.Show();
        }

      
        private void btnKasKeluar1_Click(object sender, RoutedEventArgs e)
        {
            LaporanKasKeluar laporankeluar = new LaporanKasKeluar();
            laporankeluar.Show();
        }

        private void btnLaporanSiswa_Click(object sender, RoutedEventArgs e)
        {
            LaporanSiswa laporansiswa = new LaporanSiswa();
            laporansiswa.Show();
        }

        private void btnLaporanAdmin_Click(object sender, RoutedEventArgs e)
        {
            LaporanAdmin laporanadmin = new LaporanAdmin();
            laporanadmin.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LaporanPeminjaman laporanpinjam = new LaporanPeminjaman();
                laporanpinjam.Show();
        }
    }
}
