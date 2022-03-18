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
    class KatagoriController
    {
        View.Katagori view;
        Model.KatagoriModel model;
        private Boolean hasil;

        public KatagoriController(View.Katagori view)
        {
            this.view = view;
            model = new Model.KatagoriModel();
        }
        public void SelectKatagori()
        {
            DataSet data = model.selectKatagori();
            view.dgKatagori.ItemsSource = data.Tables[0].DefaultView;
        }

        public Boolean InsertKatagori()
        {
            model.IdKatagori = Int16.Parse(view.txtId.Text);
            model.Katagori = view.txtKatagori.Text;
            hasil = model.InsertKatagori();
            return hasil;
        }
        public Boolean DeleteKatagori()
        {
            model.IdKatagori = Int16.Parse(view.txtId.Text);
            hasil = model.DeleteKatagori();
            return hasil;
        }
        public void SetKode()
        {
            view.txtId.Text = model.BuatKode().ToString();
        }
        public void Display()
        {

            model.Display = Int16.Parse(view.cmbDisplay.SelectedItem.ToString());
            DataSet data = model.KatagoriDisplay();
            view.dgKatagori.ItemsSource = data.Tables[0].DefaultView;

        }

        public void Cari()
        {

            model.Cari = view.txtCari.Text;
            DataSet data = model.SearchKelas();
            view.dgKatagori.ItemsSource = data.Tables[0].DefaultView;

        }


    }
}
