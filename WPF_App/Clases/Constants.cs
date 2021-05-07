using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_App.Clases
{
    class Constants
    {
        public const string SoftwareVersion = "1.0.0";
        public const string apikey = "77b14e0dd13289e6f9ea07fd29169c36";
        public const string hash = "d83a9612c2a47bece6ccfcb46bd5553d";
        public const string comics = "v1/public/comics?ts=1&apikey="+ apikey + "&hash="+ hash;


        public const string ApiUrl = @"http://gateway.marvel.com/";
    }
}
