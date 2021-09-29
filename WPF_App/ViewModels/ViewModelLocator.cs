using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_App.ViewModels
{
    public class ViewModelLocator
    {
        private static readonly ComicsViewModel comicsViewModel;
        private static readonly HeroesViewModel heroesViewModel;

        static ViewModelLocator()
        {
            comicsViewModel = new ComicsViewModel();
            heroesViewModel = new HeroesViewModel();
        }

        public static ComicsViewModel ComicsViewModel => comicsViewModel;
        public static HeroesViewModel HeroesViewModel => heroesViewModel;
    }
}
