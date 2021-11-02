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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_App.Clases;
using WPF_App.Views;

namespace WPF_App
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.txtVersion.Text = $"Version {Constants.SoftwareVersion}";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Login();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                this.Login();
            }
        }

        public void Login()
        {
            //PrincipalView p = new PrincipalView();
            //p.Show();
            //this.Hide();

            if (this.txtUser.Text.ToLower() == "admin" && this.txtPassword.Password == "1234")
            {
                PrincipalView p = new PrincipalView();
                p.Show();
                this.Hide();
            }
            else
            {
                this.Dialog.IsOpen = true;
            }
        }
    }
}
