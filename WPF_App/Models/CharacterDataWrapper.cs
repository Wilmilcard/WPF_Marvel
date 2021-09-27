using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_App.Models
{
    public class CharacterDataWrapper
    {
        public int code { get; set; }
        public string status { get; set; }
        public string copyright { get; set; }
        public string attributionText { get; set; }
        public string attributionHTML { get; set; }
        public CharacterDataContainer data { get; set; }
        public string etag { get; set; }
    }
}
