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
using Aplikasi_Perpustakaan.Model;



namespace Aplikasi_Perpustakaan.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lblUser.Content = Model.AdminModel.tampungNama;

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            
        }

        private void btnMax_Click(object sender, RoutedEventArgs e)
        {
            if(this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else if(this.WindowState==WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void btnMini_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnDatamaster_Click(object sender, RoutedEventArgs e)
        {
            frmHome.Navigate(new dataMaster());
        }

        private void btnTransaksi_Click(object sender, RoutedEventArgs e)
        {
            frmHome.Navigate(new transaksi());
        }

        private void btnLaporan_Click(object sender, RoutedEventArgs e)
        {
            frmHome.Navigate(new laporanMaster());
        }

        private void btnTentang_Click(object sender, RoutedEventArgs e)
        {
            frmHome.Navigate(new Tentang());
        }

        private void windows_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnKeluar_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            GC.Collect();
            this.Close();
        }


        private void btnSetting_Click(object sender, RoutedEventArgs e)
        {
            frmHome.Navigate(new PengaturanPage());
        }
    }
}
