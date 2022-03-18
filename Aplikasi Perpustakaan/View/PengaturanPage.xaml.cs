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
using System.Data;

namespace Aplikasi_Perpustakaan.View
{
    /// <summary>
    /// Interaction logic for PengaturanPage.xaml
    /// </summary>
    public partial class PengaturanPage : Page
    {
        Controller.PengaturanController controller;
        public PengaturanPage()
        {
            InitializeComponent();
            controller = new Controller.PengaturanController(this);
        }

        private Boolean hasil;



        public void Kosongkan()
        {
            txtDenda.Text = " ";
            txtLamaPinjam.Text = " ";
            txtMaxPinjam.Text = " ";
        }

        private void btnSimpan_Click(object sender, RoutedEventArgs e)
        {
            hasil = controller.InsertUpdate();
            if (hasil)
            {
                MessageBox.Show("data berhasil disimpan dan diperbarui");
                Kosongkan();
            }
            else
            {
                MessageBox.Show("Data gagal disimpan.");
            }
        }

        private void btnBatal_Click(object sender, RoutedEventArgs e)
        {
            Kosongkan();
        }
    }
}
