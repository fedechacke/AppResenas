using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppResenas.Models
{
    public class Resena
    {

        //VUELA TODO
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string texto { get; set; }
        public double puntajeAcum { get; set; }
        public int votos { get; set; }

        public Resena(int id, string texto)
        {
            this.id = id;
            this.texto = texto;
            puntajeAcum = 0;
            votos = 0;
        }

        public void Puntuar(double puntaje)
        {
            votos += 1;
            puntajeAcum += puntaje;
            
        }
    }
}   

