using System;
using System.Collections.Generic;
using System.Data;
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
using Aplikasi_Perpustakaan.Controller;

namespace Aplikasi_Perpustakaan.View
{
    /// <summary>
    /// Interaction logic for KasMasuk.xaml
    /// </summary>
    public partial class KasMasuk : Window
    {

        Controller.KasController controller;

        public KasMasuk()
        {
            InitializeComponent();
            controller = new Controller.KasController(this);
            TampilFt();
            txtIdFaktur.IsEnabled = false;
        }

        public void TampilFt()
        {
            controller.GetFt();
        }
        public void InsertKas()
        {
            controller.insertKasMasuk();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {

        }

        //Button Keluar
        private void btn_back(object sender, RoutedEventArgs e)
        {
            GC.Collect();
            this.Close();
        }

        //Button Simpan
        private void btnSimpan_Click(object sender, RoutedEventArgs e)
        {
            InsertKas();
            TampilFt();
        }

        //Button Batal
        private void btnBatal_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtKasMasuk_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
