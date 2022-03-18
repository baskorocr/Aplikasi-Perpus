using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Aplikasi_Perpustakaan.Controller;

namespace Aplikasi_Perpustakaan.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private Controller.AdminController adminController;
        public Login()
        {
            InitializeComponent();
            txtUser.Focus();
            adminController = new Controller.AdminController(this);

            
        }

        private void bntLogin_Click(object sender, RoutedEventArgs e)
        {
            adminController.LoginCheck();
        }
    }
}
