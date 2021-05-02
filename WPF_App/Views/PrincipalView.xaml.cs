using MaterialDesignThemes.Wpf;
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
using WPF_App.Control;
using WPF_App.Models;

namespace WPF_App.Views
{
    /// <summary>
    /// Lógica de interacción para PrincipalView.xaml
    /// </summary>
    public partial class PrincipalView : Window
    {
        public PrincipalView()
        {
            InitializeComponent();
            this.CargarMenu();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void CargarMenu()
        {
            var menuPrincipal = new List<SubItem>();
            var menuComics = new List<SubItem>();

            bool esAdmin = true;

            if (esAdmin)
                menuPrincipal.Add(new SubItem("Dashboard", new DashboardControl()));
            menuPrincipal.Add(new SubItem("Acerca del programa", new AcercaControl()));
            var item1 = new ItemMenu("Principal", menuPrincipal, PackIconKind.Wrestling);

            menuComics.Add(new SubItem("Comics", new ComicsControl()));
            menuComics.Add(new SubItem("Heroes", new HeroesControl()));
            var item2 = new ItemMenu("Consultas", menuComics, PackIconKind.Search);

            Menu.Children.Add(new UserControlMenuItem(item1, this));
            Menu.Children.Add(new UserControlMenuItem(item2, this));
            
            StackPanelMain.Children.Clear();
            StackPanelMain.Children.Add(new DashboardControl());
        }

        internal void SwitchScreen(object sender)
        {
            var screen = ((UserControl)sender);

            if (screen != null)
            {
                StackPanelMain.Children.Clear();
                StackPanelMain.Children.Add(screen);
            }
        }
    }
}
