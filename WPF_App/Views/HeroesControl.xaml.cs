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
using WPF_App.ViewModels;

namespace WPF_App.Views
{
    /// <summary>
    /// Lógica de interacción para HeroesControl.xaml
    /// </summary>
    public partial class HeroesControl : UserControl
    {
        public HeroesControl()
        {
            InitializeComponent();
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                ViewModelLocator.HeroesViewModel.abrirWeb(btn.Tag.ToString());
                //(this.DataContext as HeroesViewModel).msj();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ListaHeroes_MouseMove(object sender, MouseEventArgs e)
        {
            
            try
            {
                MessageBox.Show("");
            }
            catch (Exception ex)
            {

            }
        }
    }
}
