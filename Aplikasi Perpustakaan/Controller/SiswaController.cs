using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;

namespace Aplikasi_Perpustakaan.Controller
{
    class SiswaController
    {
        View.MasterSiswa view;
        Model.SiswaModel model;

        private Boolean hasil;
        

        public SiswaController(View.MasterSiswa view)
        {
            this.view = view;
            model = new Model.SiswaModel();
            this.fillComboKelas();
        }


        public void SelectDataSiswa()
        {
            DataSet data = model.SelectDataSiswa();
            view.dgSiswa.ItemsSource = data.Tables[0].DefaultView;
        }

        public void CaridanTampil()
        {
            model.Cari = view.txtCari.Text;
            //MessageBox.Show(model.Cari);
            DataSet data = model.CaridanTampil();
            view.dgSiswa.ItemsSource = data.Tables[0].DefaultView;
        }

        public void Display()
        {
            model.Display = Int16.Parse(view.cmbDisplay.Text);
            //MessageBox.Show(model.Display.ToString());
            DataSet data = model.SiswaDisplya();
            view.dgSiswa.ItemsSource = data.Tables[0].DefaultView;
        }

        public void fillComboKelas()
        {
            List<string> dataKelas = model.fillComboRak();
            view.cmbKelas.ItemsSource = dataKelas;
        }

        public Boolean InsertDataSiswa()
        {
            model.Kelas = model.Id_Kelas(view.cmbKelas.SelectedItem.ToString());
            model.MaxPinjam = Int16.Parse(model.MaxPinjamFill().ToString());
            //MessageBox.Show(model.MaxPinjam.ToString());
            model.Nis = view.txtNIS.Text;
            //MessageBox.Show(model.Kelas.ToString());
            model.Nama = view.txtNamaSiswa.Text;
            model.ThnAngkatan = view.txtAngkatan.Text;
            model.JenisKel = view.cmbJenisKel.Text;
            model.NoTelpon = view.txtTelepon.Text;
            model.Status = view.cmbStatus.Text;
            model.Alamat = view.txtAlamat.Text;
            hasil = model.InsertDataSiswa();
            return hasil;
        }

        public Boolean UpdateDataSiswa()
        {
            model.Kelas = model.Id_Kelas(view.cmbKelas.SelectedItem.ToString());
            model.Nis = view.txtNIS.Text;
            model.Nama = view.txtNamaSiswa.Text;
            model.ThnAngkatan = view.txtAngkatan.Text;
            model.JenisKel = view.cmbJenisKel.Text;
            model.NoTelpon = view.txtTelepon.Text;
            model.Status = view.cmbStatus.Text;
            model.Alamat = view.txtAlamat.Text;
            hasil = model.UpdateDataSiswa();
            return hasil;
        }

        public Boolean DeleteDataSiswa()
        {
            model.Nis = view.txtNIS.Text;
            hasil = model.DeleteDataSiswa();
            return hasil; 
        }

        
    }
}
