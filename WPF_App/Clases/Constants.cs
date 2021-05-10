using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_App.Clases
{
    class Constants
    {
        public const string SoftwareVersion = "1.2.4";

        public const string ApiUrl = @"http://gateway.marvel.com/";

        public const string apikey = "77b14e0dd13289e6f9ea07fd29169c36";
        public const string hash = "d83a9612c2a47bece6ccfcb46bd5553d";
        public const string credenciales = "?ts=1&limit=3&apikey=" + apikey+"&hash="+hash;
        /*
        El api trae un error en el registro de los comics desde el numero 4 en adelante
        con el campo: "modified": "-0001-11-30T00:00:00-0500"
        este error me genera conflicto con el tipo fecha del modelo ya que no puede castear el formato de fecha
        asi que me veo en la necesidad de limitar la cantidad de registros a solo 3
        si se desea traer todos, o aunmentar la cantidad de registros hay que modificar el parametro limit de la variable credenciales
        */

        public const string comics = "v1/public/comics";
        public const string characters = "v1/public/characters";

    }
}
