using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplikasi_Perpustakaan.View;
using Aplikasi_Perpustakaan.Model;
using System.Windows;
using System.Data.SqlClient;
using System.Data;

namespace Aplikasi_Perpustakaan.Controller
{
    class KelasController
    {
        View.dataKelas view;
        Model.KelasModel model;
        private Boolean hasil;
        

        public KelasController(View.dataKelas view)
        {
            this.view = view;
            model = new Model.KelasModel();
            
        }
        public void SelectKelas()
        {
            DataSet data = model.SelectKelas();
         
           view.dgKelas.ItemsSource = data.Tables[0].DefaultView;
            
            
        }

        public Boolean InsertKelas()
        {
            model.IdKelas = Int16.Parse(view.txtId.Text);
            model.Kelas = view.txtKelas.Text;
            hasil = model.InsertKelas();
            return hasil;
        }

        public Boolean DeleteKelas()
        {
            model.IdKelas = Int16.Parse(view.txtId.Text);
            hasil = model.DeleteKelas();
            return hasil;
        }

        public void SetKode()
        {
            view.txtId.Text = model.BuatKode().ToString();
        }

        public void Display()
        {

            model.Display = Int16.Parse( view.cmbDisplay.SelectedItem.ToString());
            DataSet data = model.KelasDisplay();
            view.dgKelas.ItemsSource = data.Tables[0].DefaultView;

        }

        public void Cari()
        {

            model.Cari = view.txtCari.Text;
            DataSet data = model.SearchKelas();
            view.dgKelas.ItemsSource = data.Tables[0].DefaultView;

        }







    }
}
