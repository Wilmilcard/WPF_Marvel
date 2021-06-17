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
    public class ComicsViewModel : BaseViewModel
    {
        Conexion con = new Conexion();
        private ObservableCollection<Comic> _listaComics = new ObservableCollection<Comic>();
        public ObservableCollection<Comic> ListaComics { get { return _listaComics; } set { _listaComics = value; OnPropertyChanged("ListaComics"); } }

        private ICommand _exportarCommand, _buscarCommand;
        public ICommand ExportarCommand { get { if (_exportarCommand == null) _exportarCommand = new RelayCommand(new Action(Exportar)); return _exportarCommand; } }
        public ICommand BuscarCommand { get { if (_buscarCommand == null) _buscarCommand = new RelayCommand(new Action(Consulta_Comics)); return _buscarCommand; } }

        public ComicsViewModel()
        {
            this.Consulta_Comics();
        }

        public async void Consulta_Comics()
        {
            var comics = await con.Get<ComicDataWrapper>();
            
            foreach(var comic in comics.data.results)
                this.ListaComics.Add(comic);

            this.ListaComics.OrderBy(x => x.title);
        }

        public async void Exportar()
        {

        }
    }
}
