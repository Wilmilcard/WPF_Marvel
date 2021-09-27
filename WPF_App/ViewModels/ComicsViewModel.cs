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
using System.Configuration;
using System.Text.RegularExpressions;

namespace WPF_App.ViewModels
{
    public class ComicsViewModel : BaseViewModel
    {
        Conexion con = new Conexion();
        Utils utils = new Utils();

        private bool _isLoad = false, esAcs = false;
        public bool IsLoad { get { return _isLoad; } set { _isLoad = value; OnPropertyChanged("IsLoad"); } }

        private string _titulo, _cantidadFiltro = "100";
        public string Titulo { get { return _titulo; } set { _titulo = value; OnPropertyChanged("Titulo"); } }
        public string CantidadFiltro { get { return _cantidadFiltro; } set { _cantidadFiltro = value; OnPropertyChanged("CantidadFiltro"); } }


        private Regex regex = new Regex(@"\d{3}|\d{2}");


        private int _tipoFiltroSeleccionado = 0, _tipoFormatoSeleccionado = 0;
        public int TipoFiltroSeleccionado { get { return _tipoFiltroSeleccionado; } set { _tipoFiltroSeleccionado = value; OnPropertyChanged("TipoFiltroSeleccionado"); } }
        public int TipoFormatoSeleccionado { get { return _tipoFormatoSeleccionado; } set { _tipoFormatoSeleccionado = value; OnPropertyChanged("TipoFormatoSeleccionado"); } }

        
        private ObservableCollection<Comic> _listaComics = new ObservableCollection<Comic>();
        public ObservableCollection<Comic> ListaComics { get { return _listaComics; } set { _listaComics = value; OnPropertyChanged("ListaComics"); } }

        
        private ICommand _exportarCommand, _buscarCommand, _ascCommand, _descCommand, _filtroCommand, _filtroTitulosCommand, _filtroPaginasCommand, _filtroSeriesCommand, _filtroFechasCommand;
        public ICommand ExportarCommand { get { if (_exportarCommand == null) _exportarCommand = new RelayCommand(new Action(Exportar)); return _exportarCommand; } }
        public ICommand BuscarCommand { get { if (_buscarCommand == null) _buscarCommand = new RelayCommand(new Action(Consulta_Comics)); return _buscarCommand; } }
        public ICommand AscCommand { get { if (_ascCommand == null) _ascCommand = new RelayCommand(new Action(ASC)); return _ascCommand; } }
        public ICommand DescCommand { get { if (_descCommand == null) _descCommand = new RelayCommand(new Action(DESC)); return _descCommand; } }
        public ICommand FiltroCommand { get { if (_filtroCommand == null) _filtroCommand = new RelayCommand(new Action(Filtro)); return _filtroCommand; } }
        public ICommand FiltroTitulosCommand { get { if (_filtroTitulosCommand == null) _filtroTitulosCommand = new RelayCommand(new Action(esTitulo)); return _filtroTitulosCommand; } }
        public ICommand FiltroPaginasCommand { get { if (_filtroPaginasCommand == null) _filtroPaginasCommand = new RelayCommand(new Action(esPagina)); return _filtroPaginasCommand; } }
        public ICommand FiltroSeriesCommand { get { if (_filtroSeriesCommand == null) _filtroSeriesCommand = new RelayCommand(new Action(esSerie)); return _filtroSeriesCommand; } }
        public ICommand FiltroFechasCommand { get { if (_filtroFechasCommand == null) _filtroFechasCommand = new RelayCommand(new Action(esFecha)); return _filtroFechasCommand; } }

        public ComicsViewModel()
        {
            this.Consulta_Comics();
        }

        public async void Consulta_Comics()
        {
            this.IsLoad = true;

            ListaComics.Clear();

            var comics = await con.Get<ComicDataWrapper>(regex.Match(this.CantidadFiltro).Value);
            foreach (var comic in comics.data.results)
                this.ListaComics.Add(comic);
            this.ASC();

            this.IsLoad = false;
        }

        public async void Exportar()
        {
            this.IsLoad = true;

            bool hacer = false;
            hacer = await utils.json_to_xlsx(regex.Match(this.CantidadFiltro).Value);
            if (hacer)
                MessageBox.Show("Guardado");
            if (!hacer)
                MessageBox.Show("no guardado");
            
            this.IsLoad = false;
        }

        public void Filtro()
        {
            switch (this.TipoFiltroSeleccionado)
            {
                case 0:
                    if (this.esAcs)
                        this.ListaComics = new ObservableCollection<Comic>(this.ListaComics.OrderBy(x => x.title));
                    if (!this.esAcs)
                        this.ListaComics = new ObservableCollection<Comic>(this.ListaComics.OrderByDescending(x => x.title));
                    break;
                case 1:
                    if (this.esAcs)
                        this.ListaComics = new ObservableCollection<Comic>(this.ListaComics.OrderBy(x => x.pageCount));
                    if (!this.esAcs)
                        this.ListaComics = new ObservableCollection<Comic>(this.ListaComics.OrderByDescending(x => x.pageCount));
                    break;
                case 2:
                    if (this.esAcs)
                        this.ListaComics = new ObservableCollection<Comic>(this.ListaComics.OrderBy(x => x.series.name));
                    if (!this.esAcs)
                        this.ListaComics = new ObservableCollection<Comic>(this.ListaComics.OrderByDescending(x => x.series.name));
                    break;
                case 3:
                    if (this.esAcs)
                        this.ListaComics = new ObservableCollection<Comic>(this.ListaComics.OrderBy(x => x.modified));
                    if (!this.esAcs)
                        this.ListaComics = new ObservableCollection<Comic>(this.ListaComics.OrderByDescending(x => x.modified));
                    break;
            }

        }

        public void ASC() { this.esAcs = true; this.Filtro(); }

        public void DESC() { this.esAcs = false; this.Filtro(); }

        public void esTitulo() { this.Filtro(); this.Filtro(); }

        public void esPagina() { this.Filtro(); this.Filtro(); }

        public void esSerie() { this.Filtro(); this.Filtro(); }

        public void esFecha() { this.Filtro(); this.Filtro(); }
    }
}
