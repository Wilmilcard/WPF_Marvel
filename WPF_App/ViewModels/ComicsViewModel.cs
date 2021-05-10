using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_App.Clases;
using WPF_App.Models;

namespace WPF_App.ViewModels
{
    public class ComicsViewModel : BaseViewModel
    {
        Conexion con = new Conexion();

        public ComicsViewModel()
        {
            this.Consulta_Comics();
        }

        public async void Consulta_Comics()
        {
            var comic = await con.Get<ComicDataWrapper>(@"http://gateway.marvel.com/v1/public/comics/82967?ts=1&apikey=77b14e0dd13289e6f9ea07fd29169c36&hash=d83a9612c2a47bece6ccfcb46bd5553d", true);
            MessageBox.Show(comic.data.results[0].title);
        }
    }
}
