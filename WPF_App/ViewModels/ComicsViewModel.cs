using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<Comic> _listaComics = new ObservableCollection<Comic>();
        public ObservableCollection<Comic> ListaComics { get { return _listaComics; } set { _listaComics = value; OnPropertyChanged("ListaComics"); } }

        public ComicsViewModel()
        {
            this.Consulta_Comics();
        }

        public async void Consulta_Comics(string nombre_comic = "")
        {
            var comics = await con.Get<ComicDataWrapper>();
            
            foreach(var comic in comics.data.results)
                this.ListaComics.Add(comic);

        }
    }
}
