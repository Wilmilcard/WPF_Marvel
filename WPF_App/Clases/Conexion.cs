﻿using Newtonsoft.Json;
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
        public Conexion con = new Conexion();

        public Conexion()
        {

        }

        public async Task<List<T>> Get<T>(string controlador, bool otra_url = false) where T : class
        {
            string hhhh = "";
            var rpta = new List<T>();
            string url = otra_url ? controlador : $"{controlador}";
            var client = new HttpClient();
            var httpResponse = await client.GetAsync(url);
            if (httpResponse.IsSuccessStatusCode)
            {
                try
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    hhhh = content;
                    rpta = JsonConvert.DeserializeObject<List<T>>(content);

                }
                catch (Exception e)
                {
                    MessageBox.Show(hhhh);
                    MessageBox.Show(e.ToString());
                }
            }
            return rpta;
        }
    }
}
