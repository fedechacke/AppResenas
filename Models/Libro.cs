using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppResenas.Models
{
    public class Libro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string titulo { get; set; }
        public string isbn { get; set; }
        public Autor autor { get; set; }
        public Resena resena { get; set; }
        // SACAR RESENA Y AGREGAR STRING TEXTORESENA, DOUBLE PUNTAJE ACUMULADO Y INT VOTOS

    }
}
