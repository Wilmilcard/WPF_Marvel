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
