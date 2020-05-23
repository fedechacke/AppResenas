using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppResenas.Models
{
    public class Usuario
    {
        [Key]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int edad { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public List<Resena> resenasFavoritas { get; set; }
        public List<Libro> librosFavoritos { get; set; }
        public List<Autor> autoresFavoritos { get; set; }

    }
}
