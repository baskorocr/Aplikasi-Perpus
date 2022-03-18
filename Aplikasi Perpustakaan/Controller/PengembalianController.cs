using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplikasi_Perpustakaan.View;
using Aplikasi_Perpustakaan.Model;
using System.Windows;
using System.Data;


namespace Aplikasi_Perpustakaan.Controller
{
    class PengembalianController
    {
        View.Pengembalian view;
        Model.PengembalianModel model;
        private Boolean hasil;

        public PengembalianController(View.Pengembalian view)
        {
            this.view = view;
            model = new Model.PengembalianModel();
        }

        public Boolean IsiData()
        {
            
            model.Cari = view.txtKodeAnggota.Text;
            hasil = model.CariData();
            view.txtNoPinjam.Text = model.JumlahPinjam;
            view.txtNama.Text = model.Nama;


            return hasil;
        }

      

        public Boolean HitungDenda()
        {
            model.IdPinjam = view.txtPinjam.Text;
            hasil = model.TampungData();
            view.txtDenda.Text = model.Denda.ToString();
            return hasil;
        }

        public void SelectDataPeminjaman()
        {
            model.Cari = view.txtKodeAnggota.Text;
            DataSet data = model.SelectDataPeminjaman();
            view.dgPinjam.ItemsSource = data.Tables[0].DefaultView;
        }

        public void SelectDataPengembalian()
        {
            DataSet data = model.SelectDataPengembalian();
            view.dgBalik.ItemsSource = data.Tables[0].DefaultView;
        }

        public void SelectDataCariPengembalian()
        {
            DataSet data = model.SelectDataCariPengembalian();
            view.dgBalik.ItemsSource = data.Tables[0].DefaultView;
        }

        public Boolean Kembali()
        {
            hasil = model.InsertPengembalian();
            return hasil;
        }
        public Boolean DeletePeminjaman()
        {
            hasil = model.DeletePeminjaman();
            return hasil;
        }

        public Boolean UpdateJlmBuku()
        {
            hasil = model.UpdateJmlBuku();
            if(hasil)
            {
                view.txtKodeAnggota.Text = "";
                view.txtNama.Text = "";
                view.txtNoPinjam.Text = "";
                MessageBox.Show("Buku Berhasil Dikembalikan");
            }
            else
            {
                MessageBox.Show("Buku Gagal Dikembalikan");
            }
            return hasil;
        }

        public Boolean InsertKas()
        {
            if(model.Denda>0)
            {
                hasil = model.InsertKasMasuk();
            }
            else
            {
                hasil = false;
            }
            
            return hasil;
        }



    }
}
