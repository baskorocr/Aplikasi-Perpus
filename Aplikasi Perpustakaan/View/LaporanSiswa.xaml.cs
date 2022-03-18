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
    /// Interaction logic for LaporanSiswa.xaml
    /// </summary>
    public partial class LaporanSiswa : Window
    {
        Controller.LaporanRController controller;
        public LaporanSiswa()
        {
            InitializeComponent();
            controller = new Controller.LaporanRController(this);
            string[] str = new string[] { "4", "6", "8", "99" };
            cmbDisplay.ItemsSource = str;
            tampildata();
        }

        public void tampildata()
        {
            controller.SelectLaporanSiswa();
        }

        private void btnKeluar_Click(object sender, RoutedEventArgs e)
        {
            GC.Collect();
            this.Close();
        }

        private void btnCari_Click(object sender, RoutedEventArgs e)
        {
            controller.CariSiswa();
        }

        private void btnCetakAdmin_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.PrintDialog Printdlg = new System.Windows.Controls.PrintDialog();
            if ((bool)Printdlg.ShowDialog().GetValueOrDefault())
            {
                Size pageSize = new Size(Printdlg.PrintableAreaWidth, Printdlg.PrintableAreaHeight);
                // sizing of the element.
                dgLaporanSiswa.Measure(pageSize);
                dgLaporanSiswa.Arrange(new Rect(5, 5, pageSize.Width, pageSize.Height));
                Printdlg.PrintVisual(dgLaporanSiswa, Title);
            }
            tampildata();
        }
    }
}
