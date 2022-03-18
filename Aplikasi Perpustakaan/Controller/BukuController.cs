using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows;

namespace Aplikasi_Perpustakaan.Controller
{
    class BukuController
    {
        View.MasterBuku view;
        Model.BukuModel model;

        private Boolean hasil;

        public BukuController(View.MasterBuku view)
        {
            this.view = view;
            model = new Model.BukuModel();
            fillComboKategori();
            fillComboRak();
        }

        public void SelectDataBuku()
        {
            DataSet data = model.SelectDataBuku();
            view.dgBuku.ItemsSource = data.Tables[0].DefaultView;
        }

        public void fillComboKategori()
        {
            List<string> dataKategori = model.fillComboKategori();
            view.cmbKategori.ItemsSource = dataKategori;
        }

        public void fillComboRak()
        {
            List<string> dataRak = model.fillComboRak();
            view.cmbRak.ItemsSource = dataRak;
        }

        public void Display()
        {
            model.Display = Int16.Parse(view.cmbDisplay.Text);
            DataSet data = model.BukuDisplay();
            view.dgBuku.ItemsSource = data.Tables[0].DefaultView;
        }

        public void Cari()
        {
            model.Cari = view.txtCari.Text;
            DataSet data = model.CaridanTampil();
            view.dgBuku.ItemsSource = data.Tables[0].DefaultView;
        }

        public Boolean InsertDataBuku()
        {            
            model.IdBuku     = view.txtIdBuku.Text;
            model.Judul      = view.txtJudulBuku.Text;
            model.Pengarang  = view.txtPengarang.Text;
            model.Penerbit   = view.txtPenerbit.Text;
            model.TotalHlmn  = view.txtJumlahHalaman.Text;
            model.ThnTerbit  = view.txtTahunTerbit.Text;
            model.TmptTerbit = view.txtTmptTerbit.Text;
            model.ISBN       = view.txtIsbn.Text;
            model.Stok       = view.txtJumlahBuku.Text;
            model.Kategori   = model.Id_Kategori(view.cmbKategori.SelectedItem.ToString());
            model.Rak        = model.Id_Rak(view.cmbRak.SelectedItem.ToString());
            model.Deskripsi  = view.txtDeskripsi.Text;
            //MessageBox.Show(model.Kategori.ToString());
            //MessageBox.Show(model.Rak.ToString());
            hasil            = model.InsertDataBuku();
            return hasil;
        }

        public Boolean UpdateDataBuku()
        {
            model.IdBuku = view.txtIdBuku.Text;
            model.Judul = view.txtJudulBuku.Text;
            model.Pengarang = view.txtPengarang.Text;
            model.Penerbit = view.txtPenerbit.Text;
            model.TotalHlmn = view.txtJumlahHalaman.Text;
            model.ThnTerbit = view.txtTahunTerbit.Text;
            model.TmptTerbit = view.txtTmptTerbit.Text;
            model.ISBN = view.txtIsbn.Text;
            model.Stok = view.txtJumlahBuku.Text;
            model.Kategori = model.Id_Kategori(view.cmbKategori.SelectedItem.ToString());
            model.Rak = model.Id_Rak(view.cmbRak.SelectedItem.ToString());
            model.Deskripsi = view.txtDeskripsi.Text;
            hasil = model.UpdateDataBuku();
            return hasil;
        }

        public Boolean DeleteDataBuku()
        {
            model.IdBuku = view.txtIdBuku.Text;
            hasil = model.DeleteDataBuku();
            return hasil;
        }
    }
}
