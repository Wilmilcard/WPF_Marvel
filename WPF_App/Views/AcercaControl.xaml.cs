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

namespace WPF_App.Views
{
    /// <summary>
    /// Lógica de interacción para AcercaControl.xaml
    /// </summary>
    public partial class AcercaControl : UserControl
    {
        public AcercaControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://nevergate.com.co/");
        }

        private void TreeViewItem_Selected(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCf0J9AO-KeLEkBe3ZpVpfKQ");
        }

        private void TreeViewItem_Selected_1(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://materialdesigninxaml.net/");

        }

        private void TreeViewItem_Selected_2(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://developer.marvel.com/");

        }

        private void TreeViewItem_Selected_3(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Wilmilcard/WPF_Marvel");
        }

        private void TreeViewItem_Selected_4(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.coreldraw.com/la/");
        }
    }
}
