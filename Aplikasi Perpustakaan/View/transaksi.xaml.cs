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
    /// Interaction logic for transaksi.xaml
    /// </summary>
    public partial class transaksi : Page
    {
        public transaksi()
        {
            InitializeComponent();
        }

        private void txtPeminjaman_Click(object sender, RoutedEventArgs e)
        {
            Peminjaman pinjam = new Peminjaman();
            pinjam.Show();
        }

        

        private void btnPengembalian1_Click(object sender, RoutedEventArgs e)
        {
            Pengembalian balik = new Pengembalian();
            balik.Show();
        }

        private void btnKasMasuk_Click(object sender, RoutedEventArgs e)
        {
            KasMasuk masuk = new KasMasuk();
            masuk.Show();
        }

        private void btnKasKeluar_Click(object sender, RoutedEventArgs e)
        {
            KasKeluar keluar = new KasKeluar();
            keluar.Show();
        }
    }
}
