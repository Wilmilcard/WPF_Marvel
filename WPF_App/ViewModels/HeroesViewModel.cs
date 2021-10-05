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
    
    public class HeroesViewModel : BaseViewModel
    {
        Conexion con = new Conexion();
        Utils utils = new Utils();


        private bool _isLoad = false, esAcs = false;
        public bool IsLoad { get { return _isLoad; } set { _isLoad = value; OnPropertyChanged("IsLoad"); } }


        private ObservableCollection<Character> _listaHeroes = new ObservableCollection<Character>();
        public ObservableCollection<Character> ListaHeroes { get { return _listaHeroes; } set { _listaHeroes = value; OnPropertyChanged("ListaHeroes"); } }

        public HeroesViewModel()
        {
            this.CargarHeroes();
        }

        public async void CargarHeroes()
        {
            this.IsLoad = true;

            ListaHeroes.Clear();

            var heroes = await con.Get<CharacterDataWrapper>("100", true);
            foreach (var comic in heroes.data.results)
            {
                
                comic.image = $"{comic.thumbnail.path}.{comic.thumbnail.extension}";
                if(comic.thumbnail.path != "http://i.annihil.us/u/prod/marvel/i/mg/b/40/image_not_available")
                    this.ListaHeroes.Add(comic);
            }
            this.ListaHeroes.OrderBy(x => x.name);

            this.IsLoad = false;
        }

        public void msj()
        {
            MessageBox.Show("pendiente");

        }

    }
}
