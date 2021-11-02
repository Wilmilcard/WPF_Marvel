using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_App.Clases
{
    class Constants
    {
        public const string SoftwareVersion = "1.4.2";

        public const string ApiUrl = @"http://gateway.marvel.com/";

        public const string apikey = "77b14e0dd13289e6f9ea07fd29169c36";
        public const string hash = "d83a9612c2a47bece6ccfcb46bd5553d";
        public const string credenciales = "&apikey=" + apikey + "&hash=" + hash;
        
        public const string comics = "v1/public/comics";
        public const string characters = "v1/public/characters";

    }
}
