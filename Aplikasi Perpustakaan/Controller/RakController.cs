using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Aplikasi_Perpustakaan.Controller
{
    class RakController
    {
        View.rakBuku view;
        Model.RakModel model;
        private Boolean hasil;

        public RakController(View.rakBuku view)
        {
            this.view = view;
            model = new Model.RakModel();

        }
        public void SelectRak()
        {
            DataSet data = model.SelectRak();

            view.dgRak.ItemsSource = data.Tables[0].DefaultView;


        }

        public Boolean InsertRak()
        {
            model.IdRak = Int16.Parse(view.txtId.Text);
            model.Rak = view.txtRak.Text;
            hasil = model.InsertRak();
            return hasil;
        }

        public Boolean DeleteRak()
        {
            model.IdRak = Int16.Parse(view.txtId.Text);
            hasil = model.DeleteRak();
            return hasil;
        }
        public void SetKode()
        {
            view.txtId.Text = model.BuatKode().ToString();
        }

        public void Display()
        {

            model.Display = Int16.Parse(view.cmbDisplay.SelectedItem.ToString());
            DataSet data = model.RakDisplay();
            view.dgRak.ItemsSource = data.Tables[0].DefaultView;

        }

        public void Cari()
        {

            model.Cari = view.txtCari.Text;
            DataSet data = model.SearchRak();
            view.dgRak.ItemsSource = data.Tables[0].DefaultView;

        }


    }
}
