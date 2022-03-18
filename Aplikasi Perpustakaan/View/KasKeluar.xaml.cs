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
    /// Interaction logic for KasKeluar.xaml
    /// </summary>
    public partial class KasKeluar : Window
    {

        Controller.KasController controller;

        public KasKeluar()
        {
            InitializeComponent();
            controller = new Controller.KasController(this);
            Tampil();
            txtIdFaktur.IsEnabled = false;


        }
        public void Tampil()
        {
            controller.GetFt2();
        }
        public void InsertKas()
        {
            controller.insertKasKeluar();
        }



        private void btnBatalKK_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_back(object sender, RoutedEventArgs e)
        {
            GC.Collect();
            this.Close();
        }

        private void btnSimpanKK_Click_1(object sender, RoutedEventArgs e)
        {
            InsertKas();
            Tampil();
        }
    }
}
