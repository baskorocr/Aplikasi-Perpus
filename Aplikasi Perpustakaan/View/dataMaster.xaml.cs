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
    /// Interaction logic for dataMaster.xaml
    /// </summary>
    public partial class dataMaster : Page
    {
        public dataMaster()
        {
            InitializeComponent();
        }

        private void btnKelas_Click(object sender, RoutedEventArgs e)
        {
            dataKelas kelas = new dataKelas();
            kelas.Show();
        }

        private void btnRak_Click(object sender, RoutedEventArgs e)
        {
            rakBuku rak = new rakBuku();
            rak.Show();
        }

        private void btnKatagori_Click(object sender, RoutedEventArgs e)
        {
            Katagori kata = new Katagori();
            kata.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MasterSiswa siswa = new MasterSiswa();
            siswa.Show();
        }

        private void btnMasterAdmin_Click(object sender, RoutedEventArgs e)
        {
            MasterAdmin admin = new MasterAdmin();
            admin.Show();

        }

        private void btnMasterBuku_Click(object sender, RoutedEventArgs e)
        {
            MasterBuku buku = new MasterBuku();
            buku.Show();
        }
    }
}
