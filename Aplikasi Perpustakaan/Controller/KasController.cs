using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;

namespace Aplikasi_Perpustakaan.Controller
{
    class KasController
    {

        View.KasMasuk viewmasuk;
        View.KasKeluar viewkeluar;
        View.LaporanKasMasuk laporanMasuk;
        View.LaporanKasKeluar laporanKeluar;
        Model.KasModel model;
        private Boolean hasil;


        public KasController(View.KasMasuk viewMasuk)
        {
            viewmasuk = viewMasuk;
            model = new Model.KasModel();
        }
        public KasController(View.KasKeluar viewKeluar)
        {
            viewkeluar = viewKeluar;
            model = new Model.KasModel();
        }
        public KasController(View.LaporanKasMasuk laporanKasMasuk)
        {
            laporanMasuk = laporanKasMasuk;
            model = new Model.KasModel();
        }
        public KasController(View.LaporanKasKeluar laporanKasKeluar)
        {
            laporanKeluar = laporanKasKeluar;
            model = new Model.KasModel();
        }


        public Boolean GetFt()
        {
            hasil = model.GetFt();
            viewmasuk.txtIdFaktur.Text = model.GetFaktur;
            return hasil;

        }
        public Boolean GetFt2()
        {
            hasil = model.GetFt();
            viewkeluar.txtIdFaktur.Text = model.GetFaktur;
            return hasil;

        }

        public Boolean insertKasMasuk()
        {
            model.KasMasuk = int.Parse(viewmasuk.txtKasMasuk.Text);
            model.KasKeluar = 0;
            model.Keterangan = viewmasuk.txtKeteranganKM.Text;
            hasil = model.InsertKas();
            if (hasil)
            {
                MessageBox.Show("Kas Masuk Berhasil Di Input");
                viewmasuk.txtKasMasuk.Text = "";
                viewmasuk.txtKeteranganKM.Text = "";
                viewmasuk.txtIdFaktur.Text = "";
            }
            else
            {
                MessageBox.Show("Kas Masuk Gagal Di Input");
                viewmasuk.txtKasMasuk.Text = "";
                viewmasuk.txtKeteranganKM.Text = "";
                viewmasuk.txtIdFaktur.Text = "";
            }
            return hasil;
            

        }
        public Boolean insertKasKeluar()
        {
            model.KasMasuk = 0;
            model.KasKeluar = int.Parse(viewkeluar.txtKasKeluar.Text);
            model.Keterangan = viewkeluar.txtKeterangan.Text;
            hasil = model.InsertKas();
            if (hasil)
            {
                MessageBox.Show("Kas Keluar Berhasil Di Input");
                viewkeluar.txtKasKeluar.Text = "";
                viewkeluar.txtKeterangan.Text = "";
                viewkeluar.txtIdFaktur.Text = "";
            }
            else
            {
                MessageBox.Show("Kas Keluar Gagal Di Input");
                viewkeluar.txtKasKeluar.Text = "";
                viewkeluar.txtKeterangan.Text = "";
                viewkeluar.txtIdFaktur.Text = "";
            }
            return hasil;
        }

        public Boolean TotalPemasukanKas()
        {
            hasil = model.TotalPemasukaKas();
            laporanMasuk.lblTotal.Content = model.TotalPemasukan;
            laporanMasuk.lblTotalKeluar.Content = model.TotalPengeluaran;
            laporanMasuk.lblTotalKeseluruhan.Content = model.TotalKeseluruhan;
            return hasil;
        }
        public Boolean TotalPengeluaranKas()
        {
            hasil = model.TotalPemasukaKas();
            laporanKeluar.lblTotal.Content = model.TotalPemasukan;
            laporanKeluar.lblTotalKeluar.Content = model.TotalPengeluaran;
            laporanKeluar.lblTotalKeseluruhan.Content = model.TotalKeseluruhan;
            return hasil;
        }

        public void DisplayMasuk()
        {

            model.Display = Int16.Parse(laporanMasuk.cmbLaporanKM.SelectedItem.ToString());
            DataSet data = model.KasDisplayMasuk();
            laporanMasuk.dgLaporanKM.ItemsSource = data.Tables[0].DefaultView;

        }
        public void DisplayKeluar()
        {

            model.Display = Int16.Parse(laporanKeluar.cmbLaporanKK.SelectedItem.ToString());
            DataSet data = model.KasDisplayKeluar();
            laporanKeluar.dgLaporanKK.ItemsSource = data.Tables[0].DefaultView;

        }
        public void SelectKasMasuk()
        {                        
            DataSet data = model.selectKasMasuk();
            laporanMasuk.dgLaporanKM.ItemsSource = data.Tables[0].DefaultView;

        }
        public void SelectKasKeluar()
        {
            DataSet data = model.selectKasKeluar();
            laporanKeluar.dgLaporanKK.ItemsSource = data.Tables[0].DefaultView;

        }

        public void CariFtMasuk()
        {

            model.Cari = laporanMasuk.txtCariKM.Text;
            DataSet data = model.SearchFTMasuk();
            laporanMasuk.dgLaporanKM.ItemsSource = data.Tables[0].DefaultView;

        }
    }
}
