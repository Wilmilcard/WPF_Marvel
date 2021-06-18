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

        private bool _isLoad = false;
        public bool IsLoad { get { return _isLoad; } set { _isLoad = value; OnPropertyChanged("IsLoad"); } }

        private int _selectedIndex = 0;
        public int SelectedIndex { get { return _selectedIndex; } set { _selectedIndex = value; OnPropertyChanged("SelectedIndex"); } }

        private ObservableCollection<Comic> _listaComics = new ObservableCollection<Comic>();
        public ObservableCollection<Comic> ListaComics { get { return _listaComics; } set { _listaComics = value; OnPropertyChanged("ListaComics"); } }

        public enum tiposFiltros { titulo, paginas, serie, fecha}

        private ICommand _exportarCommand, _buscarCommand, _ascCommand, _descCommand, _filtroCommand;
        public ICommand ExportarCommand { get { if (_exportarCommand == null) _exportarCommand = new RelayCommand(new Action(Exportar)); return _exportarCommand; } }
        public ICommand BuscarCommand { get { if (_buscarCommand == null) _buscarCommand = new RelayCommand(new Action(Consulta_Comics)); return _buscarCommand; } }
        public ICommand AscCommand { get { if (_ascCommand == null) _ascCommand = new RelayCommand(new Action(ASC)); return _ascCommand; } }
        public ICommand DescCommand { get { if (_descCommand == null) _descCommand = new RelayCommand(new Action(DESC)); return _descCommand; } }
        public ICommand FiltroCommand { get { if (_filtroCommand == null) _filtroCommand = new RelayCommand(new Action(Filtro)); return _filtroCommand; } }

        public ComicsViewModel()
        {
            this.Consulta_Comics();
        }

        public async void Consulta_Comics()
        {
            this.IsLoad = true;
            
            var comics = await con.Get<ComicDataWrapper>();
            
            foreach(var comic in comics.data.results)
                this.ListaComics.Add(comic);
            
            this.ASC();
            
            this.IsLoad = false;

        }

        public async void Exportar()
        {

        }

        public void Filtro()
        {
            int index = this.SelectedIndex;
            MessageBox.Show(Convert.ToString((int)tiposFiltros.titulo));
        }

        public void ASC()
        {
            var list = this.ListaComics.OrderBy(x => x.pageCount);
            this.ListaComics = new ObservableCollection<Comic>(list);
        }

        public void DESC()
        {
            var list = this.ListaComics.OrderByDescending(x => x.pageCount);
            this.ListaComics = new ObservableCollection<Comic>(list);
        }
    }
}
