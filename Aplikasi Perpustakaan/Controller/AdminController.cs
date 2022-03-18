using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplikasi_Perpustakaan.View;
using Aplikasi_Perpustakaan.Model;
using System.Windows;

namespace Aplikasi_Perpustakaan.Controller
{
    class AdminController
    {
        private Login login;
        private Model.AdminModel admin;

        public AdminController(Login login)
        {
            this.login = login;
            admin = new Model.AdminModel();
        }

        internal void LoginCheck()
        {
            admin.Username = login.txtUser.Text;
            admin.Password = login.txtPass.Password;
            bool result = admin.LoginCheck();

            if (result)
            {
                View.MainWindow home = new View.MainWindow();
                home.Show();
                login.Close();
            }
            else
            {
                MessageBox.Show("Maaf username dan password salah");
                login.txtUser.Text = "";
                login.txtPass.Password = "";
                login.txtUser.Focus();
            }
        }
    }
}
