using AppResenas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppResenas.Context
{
    public class ResenasDataBaseContext : DbContext
    {
        public
            ResenasDataBaseContext(DbContextOptions<ResenasDataBaseContext> options) : base(options)
        {
        }
        public DbSet<Autor> autores { get; set; }
        public DbSet<Libro> libros {get; set;}
        public DbSet<Resena> resenas {get; set;}
        public DbSet<Usuario> usuarios {get; set;}
       
    }
}
