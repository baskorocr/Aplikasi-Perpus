using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Aplikasi_Perpustakaan.Controller
{
    class PeminjamanController
    {
        View.Peminjaman view;
        Model.PeminjamanModel model;

        private Boolean hasil, cek, cek2;

        public PeminjamanController(View.Peminjaman view)
        {
            this.view = view;
            model = new Model.PeminjamanModel();
            
        }

        public void SelectPeminjaman()
        {
            DataSet data = model.SelectPeminjaman();
            view.dgPeminjaman.ItemsSource = data.Tables[0].DefaultView;
        }

        public Boolean CekId()
        {
            cek = model.CekIdBuku(view.txtIdBuku.Text);
            cek2 = model.CekIdSiswa(view.txtIdNIS.Text);
            if (cek && cek2)
            {
                hasil = true;
            }
            else
            {
                hasil = false;
            }
            return hasil;
        }

        public void fillTextBox()
        {
            view.txtNamaAnggota.Text = model.NamaSiswa(view.txtIdNIS.Text);
            view.txtKelas.Text = model.KelasSiswa(view.txtIdNIS.Text);
            view.txtJudul.Text = model.JudulBuku(view.txtIdBuku.Text);
            view.txtIsiIdPinjam.Text = model.GenerateCode();
        }

        public Boolean InsertPeminjaman()
        {
            cek = CekStokdanMaxPinjam();
            if (cek)
            {
                int isi = model.LamaPinjamFill();
                SelisihTangal();
                model.IdPinjam = view.txtIsiIdPinjam.Text;
                model.Nis = view.txtIdNIS.Text;
                model.IdBuku = view.txtIdBuku.Text;
                model.LamaPinjam = isi ;
                model.Jumlambuku = Int16.Parse(view.txtJumalhBuku.Text);
                model.TglPinjam = DateTime.Today.ToString("yyyy-MM-dd");
                model.TglKembali = DateTime.Today.AddDays(isi).ToString("yyyy-MM-dd");
                hasil = model.InsertDataBuku();
                model.UpdateStokBuku();
                model.UpdateMaxPinjamSiswa();
            }
            else
            {
                hasil = false;
            }
            return hasil;
        }

        public void CekUpdateTelat()
        {
            string tglcek = model.GetUpdateTanggal();
            if (tglcek == DateTime.Today.ToString("yyyy-MM-dd"))
            {

            }
            else
            {
                model.UpdateTelat();
                model.UpdateTanggal();
            }
        }


        public void SelisihTangal()
        {
            DateTime tanggal1 = DateTime.Today;
            DateTime tanggal2 = DateTime.Today.AddDays(model.LamaPinjamFill());
            TimeSpan ts = new TimeSpan();
            ts = tanggal1.Subtract(tanggal2);
            model.Telat = Int16.Parse(ts.Days.ToString());
        }

        public Boolean CekStokdanMaxPinjam()
        {
            int maxpinjam = model.MaxPinjamSiswaFill(view.txtIdNIS.Text);
            int stok = model.StokBukuLama(view.txtIdBuku.Text);
            model.MaxPinjam = maxpinjam - Int16.Parse(view.txtJumalhBuku.Text);
            model.Stok = stok - Int16.Parse(view.txtJumalhBuku.Text);
            if(model.MaxPinjam >= 0)
            {
                if(model.Stok >= 0)
                {
                    hasil = true;
                }
                else
                {
                    MessageBox.Show("Stok buku ini di perpustakaan tersisa = " + stok +
                    "\nTidak bisa di pinjam melebihi jumlah stok tersisa.");
                    hasil = false;
                }
            }
            else
            {
                MessageBox.Show(model.NamaSiswa(view.txtIdNIS.Text) + " telah melampaui batas maksimal peminjaman buku" +
                    "\nJumlah buku yang bisa di pinjam tidak lebih dari = " + maxpinjam + ".");
                hasil = false;
            }
            return hasil;
        }
    }
}
