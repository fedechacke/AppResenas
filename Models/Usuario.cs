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
        public bool esAdmin { get; set; }

        public Usuario(int id, string nombre, string apellido, int edad, string username, string password)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
            this.username = username;
            this.password = password;
            esAdmin = false;
            resenasFavoritas = new List<Resena>();
            librosFavoritos = new List<Libro>();
            autoresFavoritos = new List<Autor>();
        }

        public void agregarLibroFavorito(Libro libro) 
        {
            librosFavoritos.Add(libro);
        }

        public void agregarAutorFavorito(Autor autor)
        {
            autoresFavoritos.Add(autor);
        }

        public void agregarResenaFavorita(Resena resena)
        {
            resenasFavoritas.Add(resena);
        }
    }
}
