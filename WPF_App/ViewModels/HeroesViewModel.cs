using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF_App.Clases;
using WPF_App.Models;

namespace WPF_App.ViewModels
{
    
    public class HeroesViewModel : BaseViewModel
    {
        Conexion con = new Conexion();
        Utils utils = new Utils();


        private bool _isLoad = false, esAcs = false, filter = true;
        public bool IsLoad { get { return _isLoad; } set { _isLoad = value; OnPropertyChanged("IsLoad"); } }


        private ObservableCollection<Character> _listaHeroes = new ObservableCollection<Character>();
        private ObservableCollection<Character> _listaFiltrada = new ObservableCollection<Character>();
        public ObservableCollection<Character> ListaHeroes { get { return _listaHeroes; } set { _listaHeroes = value; OnPropertyChanged("ListaHeroes"); } }
        public ObservableCollection<Character> ListaFiltrada { get { return _listaFiltrada; } set { _listaFiltrada = value; OnPropertyChanged("ListaFiltrada"); } }

        private ICommand _favoritoCommand, _buscarCommand;
        public ICommand FavoritoCommand { get { if (_favoritoCommand == null) _favoritoCommand = new RelayCommand(new Action(Favorito)); return _favoritoCommand; } }
        public ICommand BuscarCommand { get { if (_buscarCommand == null) _buscarCommand = new RelayCommand(new Action(CargarHeroes)); return _buscarCommand; } }

        public HeroesViewModel()
        {
            this.CargarHeroes();
        }

        public async void CargarHeroes()
        {
            this.IsLoad = true;

            ListaFiltrada.Clear();

            var heroes = await con.Get<CharacterDataWrapper>("100", true);
            foreach (var comic in heroes.data.results)
            {
                if (string.IsNullOrEmpty(comic.description))
                    comic.description = "No description available for Marvel";

                comic.image = $"{comic.thumbnail.path}.{comic.thumbnail.extension}";
                if (comic.thumbnail.path != "http://i.annihil.us/u/prod/marvel/i/mg/b/40/image_not_available")
                    this.ListaHeroes.Add(comic);

                this.ListaFiltrada = this.ListaHeroes;
            }
            this.ListaFiltrada.OrderBy(x => x.name);

            this.IsLoad = false;
        }

        public void msj()
        {
            MessageBox.Show(ListaHeroes[0].description);
        }

        public void abrirWeb(string url)
        {
            System.Diagnostics.Process.Start(url);
        }

        public async void Favorito()
        {
            var lista = this.ListaHeroes.ToList();

            if (filter)
                lista = this.ListaHeroes.Where(x => x.favorite).ToList();

            this.ListaFiltrada = new ObservableCollection<Character>();
            foreach (var comic in lista)
                this.ListaFiltrada.Add(comic);
            
            filter = !filter ? true : false;
        }

    }
}
