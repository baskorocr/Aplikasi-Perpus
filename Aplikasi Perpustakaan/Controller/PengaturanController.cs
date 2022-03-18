using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Aplikasi_Perpustakaan.Controller
{
    class PengaturanController
    {
        View.PengaturanPage view;
        Model.PengaturanModel model;

        private Boolean hasil, cek;

        public PengaturanController(View.PengaturanPage view)
        {
            this.view = view;
            model = new Model.PengaturanModel();
        }

        public Boolean InsertUpdate()
        {
            hasil = false;
            model.LamaPinjam = Int16.Parse(view.txtLamaPinjam.Text);
            model.MaxPinjam = Int16.Parse(view.txtMaxPinjam.Text);
            model.Denda = Int16.Parse(view.txtDenda.Text);
            cek = model.InsertSetting();
            if (cek)
            {
                hasil = true;
            }
            else
            {
                hasil = model.UpdateSetting();
            }
            return hasil;
        }
    }
}
