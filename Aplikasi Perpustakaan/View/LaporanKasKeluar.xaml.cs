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
    /// Interaction logic for LaporanKasKeluar.xaml
    /// </summary>
    public partial class LaporanKasKeluar : Window
    {
        Controller.KasController controller;

        public void TampilData()
        {
            controller.SelectKasKeluar();
        }

        public LaporanKasKeluar()
        {
            InitializeComponent();
            controller = new Controller.KasController(this);
            string[] str = new string[] { "4", "6", "8", "99" };
            cmbLaporanKK.ItemsSource = str;
            TampilData();
            Total();
        }

        public void Total()
        {
            controller.TotalPengeluaranKas();
        }

        private void cmbDisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            controller.DisplayKeluar();
        }

        private void btnKeluar_Click(object sender, RoutedEventArgs e)
        {
            GC.Collect();
            this.Close();
        }

        private void txtCariKM_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnCetakKasMasuk_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.PrintDialog Printdlg = new System.Windows.Controls.PrintDialog();
            if ((bool)Printdlg.ShowDialog().GetValueOrDefault())
            {
                Size pageSize = new Size(Printdlg.PrintableAreaWidth, Printdlg.PrintableAreaHeight);
                // sizing of the element.
                dgLaporanKK.Measure(pageSize);
                dgLaporanKK.Arrange(new Rect(5, 5, pageSize.Width, pageSize.Height));
                Printdlg.PrintVisual(dgLaporanKK, Title);
            }
            TampilData();
        }
    }
}
