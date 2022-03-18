using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Aplikasi_Perpustakaan.View;
using Aplikasi_Perpustakaan.Model;

namespace Aplikasi_Perpustakaan.Controller
{
    class LaporanRController
    {
        View.LaporanAdmin viewadmin;
        View.LaporanPeminjaman viewpeminjaman;
        View.LaporanPengunjung viewpengunjung;
        View.LaporanSiswa viewsiswa;

        Model.LaporanRModel model;

        public LaporanRController(View.LaporanAdmin viewAdmin)
        {
            viewadmin = viewAdmin;
            model = new Model.LaporanRModel();
        }
        public LaporanRController(View.LaporanPeminjaman viewPeminjaman)
        {
            viewpeminjaman = viewPeminjaman;
            model = new Model.LaporanRModel();
        }
        public LaporanRController(View.LaporanPengunjung viewPengunjung)
        {
            viewpengunjung = viewPengunjung;
            model = new Model.LaporanRModel();
        }
        public LaporanRController(View.LaporanSiswa viewSiswa)
        {
            viewsiswa = viewSiswa;
            model = new Model.LaporanRModel();
        }

        public void SelectLaporanAdmin()
        {
            DataSet data = model.SelectLaporanAdmin();
            viewadmin.dgLaporanAdmin.ItemsSource = data.Tables[0].DefaultView;
        }

        public void SelectLaporanPeminjaman()
        {
            DataSet data = model.SelectLaporanPeminjaman();
            viewpeminjaman.dgLaporanPeminjaman.ItemsSource = data.Tables[0].DefaultView;
        }
        public void SelectLaporanPengujung()
        {
            DataSet data = model.SelectLaporanPengunjung();
            viewpengunjung.dgLaporanPengujung.ItemsSource = data.Tables[0].DefaultView;
        }
        public void SelectLaporanSiswa()
        {
            DataSet data = model.SelectLaporanSiswa();
            viewsiswa.dgLaporanSiswa.ItemsSource = data.Tables[0].DefaultView;
        }

        public void CariAdmin()
        {
            model.Cari = viewadmin.txtcari.Text;
            DataSet data = model.SearchLaporanAdmin();
            viewadmin.dgLaporanAdmin.ItemsSource = data.Tables[0].DefaultView;
        }

        public void CariPeminjaman()
        {
            model.Cari = viewpeminjaman.txtcari.Text;
            DataSet data = model.SearchLaporanPeminjaman();
            viewpeminjaman.dgLaporanPeminjaman.ItemsSource = data.Tables[0].DefaultView;
        }
        public void TampilPengujung()
        {
            model.Asal = viewpengunjung.dtAsal.ToString();
            model.Sampai = viewpengunjung.dtSampai.ToString();
            DataSet data = model.TampilLaporanPengunjung();
            viewpengunjung.dgLaporanPengujung.ItemsSource = data.Tables[0].DefaultView;
        }

        public void CariPengunjung()
        {
            model.Cari = viewpengunjung.txtCari.Text;
            DataSet data = model.SearchLaporanPengunjung();
            viewpengunjung.dgLaporanPengujung.ItemsSource = data.Tables[0].DefaultView;
        }
        public void CariSiswa()
        {
            model.Cari = viewsiswa.txtcari.Text;
            DataSet data = model.SearchLaporanSiswa();
            viewsiswa.dgLaporanSiswa.ItemsSource = data.Tables[0].DefaultView;
        }
        public void DisplayLaporanPeminjaman()
        {

            model.Display = Int16.Parse(viewpeminjaman.cmbDisplay.SelectedItem.ToString());
            DataSet data = model.LaporanPeminjamanDisplay();
            viewpeminjaman.dgLaporanPeminjaman.ItemsSource = data.Tables[0].DefaultView;

        }
        public void DisplayLaporanAdmin()
        {
            model.Display = Int16.Parse(viewadmin.cmbDisplay.SelectedItem.ToString());
            DataSet data = model.AdminDisplay();
            viewadmin.dgLaporanAdmin.ItemsSource = data.Tables[0].DefaultView;

        }
    }
}
