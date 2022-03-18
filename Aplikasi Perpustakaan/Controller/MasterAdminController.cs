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
    class MasterAdminController
    {
        View.MasterAdmin view;
        Model.MasterAdminModel model;
        private Boolean Hasil;

        public MasterAdminController(View.MasterAdmin view)
        {
            this.view = view;
            model = new Model.MasterAdminModel();
        }
        public void SelectAdmin()
        {
            DataSet data = model.SelectAdmin();
            view.dgAdmin.ItemsSource = data.Tables[0].DefaultView;
        }

        public Boolean InsertAdmin()
        {
            model.Username = view.txtUsername.Text;
            model.NoTelpon = view.txtNotelp.Text;
            model.Nama = view.txtNama.Text;
            model.Email = view.txtEmail.Text;
            model.Password = view.txtPassword.Password;
            Hasil = model.InsertAdmin();
            return Hasil;
        }
        public Boolean DeleteAdmin ()
        {
            model.Username = view.txtUsername.Text;
            model.NoTelpon = view.txtNotelp.Text;
            model.Nama = view.txtNama.Text;
            model.Email = view.txtEmail.Text;
            model.Password = view.txtPassword.Password;
            Hasil = model.DeleteAdmin();
            return Hasil;
        }

        public Boolean UpdateDataSiswa()
        {
            model.Username = view.txtUsername.Text;
            model.NoTelpon = view.txtNotelp.Text;
            model.Nama = view.txtNama.Text;
            model.Email = view.txtEmail.Text;
            model.Password = view.txtPassword.Password;
            Hasil = model.UpdateDataAdmin();
            return Hasil;
        }
        public void Cari()
        {
            model.Cari = view.txtCari.Text;
            DataSet data = model.SearchAdmin();
            view.dgAdmin.ItemsSource = data.Tables[0].DefaultView;

        }
    }
}
