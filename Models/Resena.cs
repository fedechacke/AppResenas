using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppResenas.Models
{
    public class Resena
    {
        public string titulo { get; set; }
        public string texto { get; set; }
        public string tituloLibro { get; set; }
        public double puntaje { get; set; }
    }
}
