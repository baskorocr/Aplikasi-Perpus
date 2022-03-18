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
using Aplikasi_Perpustakaan.Controller;

namespace Aplikasi_Perpustakaan.View
{
    /// <summary>
    /// Interaction logic for Pengembalian.xaml
    /// </summary>
    public partial class Pengembalian : Window
    {
        Controller.PengembalianController controller;



        public Pengembalian()
        {

            InitializeComponent();
            controller = new Controller.PengembalianController(this);
            tampilPengembalian();
          


        }

        public void tampilPeminjaman()
        {
            controller.SelectDataPeminjaman();
        }
        public void tampilPengembalian()
        {
            controller.SelectDataPengembalian();
        }

        public void tampilCariPengembalian()
        {
            controller.SelectDataCariPengembalian();
        }



        public void Denda()
        {
            controller.HitungDenda();
        }

        public void IsiData()
        {
            controller.IsiData();
        }

        public void DeletePeminjaman()
        {
            controller.DeletePeminjaman();
        }

        public void UpdateJlmBuku()
        {
            controller.UpdateJlmBuku();
        }

        public void InsertKas()
        {
            controller.InsertKas();
        }

       

        

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {

        }

        

        private void btnBaru_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btn_back(object sender, RoutedEventArgs e)
        {
            GC.Collect();
            this.Close();
        }

        private void btnCari_Click(object sender, RoutedEventArgs e)
        {
            tampilPeminjaman();
            IsiData();
            
            
            
        }

         
       

        private void dgPinjam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void btnHitung_Click(object sender, RoutedEventArgs e)
        {
           
            Denda();

        }

        private void btnProses_Click(object sender, RoutedEventArgs e)
        {
            controller.Kembali();
            DeletePeminjaman();
            tampilCariPengembalian();
            tampilPeminjaman();
            UpdateJlmBuku();
            InsertKas();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GC.Collect();
            this.Close();
        }

        private void dgPinjam_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtDenda_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtNoPinjam_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
