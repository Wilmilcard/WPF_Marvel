using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_App.Clases
{
    public class Conexion
    {

        /*
        IMPORTANTE:

        El api trae un error en el registro de los comics desde el numero 4 en adelante
        con el campo: "modified": "-0001-11-30T00:00:00-0500"
        este error me genera conflicto con el tipo fecha del modelo ya que no puede castear el formato de fecha
        asi que si quiero traer datos:
        
        1- me veo en la necesidad de limitar la cantidad de registros a solo 3 con el parametro '&limit=3' en la url del api en la clase Constants.cs

        2- Reemplazar todo lo que venga malo, eso lo hago en la linea 46

        */

        public Conexion()
        {

        }

        public async Task<T> Get<T>(int comic_id = 0) where T : class
        {
            string filtro = comic_id != 0 ? $"/{comic_id}" : "";
            var rpta = await Task.FromResult<T>(null); 
            var client = new HttpClient();
            string url = $"{Constants.ApiUrl}{Constants.comics}{filtro}{Constants.credenciales}";
            var httpResponse = await client.GetAsync(url);
            if (httpResponse.IsSuccessStatusCode)
            {
                try
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    content = content.Replace("-0001", "1900");
                    rpta = JsonConvert.DeserializeObject<T>(content);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
            return rpta;
        }
    }
}
