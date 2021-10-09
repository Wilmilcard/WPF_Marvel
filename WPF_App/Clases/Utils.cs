using Aspose.Cells;
using Aspose.Cells.Utility;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_App.Models;

namespace WPF_App.Clases
{
    public class Utils
    {
        Conexion con = new Conexion();

        public async Task<bool> json_to_xlsx(string limit, string nombre_archivo = "Consulta Excel")
        {
            bool rpta = false;
            SaveFileDialog saveFile = new SaveFileDialog();

            Workbook workbook = new Workbook();
            Worksheet worksheet = workbook.Worksheets[0];

            var consulta = await con.Get<ComicDataWrapper>(limit);
            string jsonInput = consulta.ToString();

            JsonLayoutOptions options = new JsonLayoutOptions();
            options.ArrayAsTable = true;

            JsonUtility.ImportData(jsonInput, worksheet.Cells, 0, 0, options);

            saveFile.Filter = "Archivos Excel|*.xlsx";
            saveFile.FileName = nombre_archivo;
            if (saveFile.ShowDialog() == true)
            {
                workbook.Save(string.Concat(saveFile.FileName));
                rpta = true;
            }

            return rpta;
        }
    }

    public class Archivo
    {
        public int height { set; get; }
        public DateTime timestamp { set; get; }
        public string uri { set; get; }
        public string fileName { set; get; }
        public string data { set; get; }

        public static string SaveFile(string Path, string FileName, string dataFile)
        {
            if (System.IO.File.Exists(Path + FileName))
            {
                FileName = Globals.GetFechaActual().Ticks.ToString() + FileName;
            }
            Byte[] bytes = Convert.FromBase64String(dataFile);
            File.WriteAllBytes(Path + FileName, bytes);
            return FileName;
        }
    }

    public static class Globals
    {
        public static DateTime GetFechaActual()
        {
            return DateTime.UtcNow.AddHours(-5);
        }
    }

}
