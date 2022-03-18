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
    /// Interaction logic for LaporanPengunjung.xaml
    /// </summary>
    public partial class LaporanPengunjung : Window
    {
        Controller.LaporanRController controller;
        public void tampildata()
        {
            controller.SelectLaporanPengujung();
        }
        public LaporanPengunjung()
        {
            InitializeComponent();
            controller = new Controller.LaporanRController(this);
            tampildata();
        }

        private void btnTampilKasKeluar_Click(object sender, RoutedEventArgs e)
        {
            controller.TampilPengujung();
        }

        private void btnKeluar_Click(object sender, RoutedEventArgs e)
        {
            GC.Collect();
            this.Close();
        }

        private void btncetakPengunjung_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.PrintDialog Printdlg = new System.Windows.Controls.PrintDialog();
            if ((bool)Printdlg.ShowDialog().GetValueOrDefault())
            {
                Size pageSize = new Size(Printdlg.PrintableAreaWidth, Printdlg.PrintableAreaHeight);
                // sizing of the element.
                dgLaporanPengujung.Measure(pageSize);
                dgLaporanPengujung.Arrange(new Rect(5, 5, pageSize.Width, pageSize.Height));
                Printdlg.PrintVisual(dgLaporanPengujung, Title);
            }
            tampildata();
        }

        private void btnCari_Click(object sender, RoutedEventArgs e)
        {
            controller.CariPengunjung();
        }
    }
}
