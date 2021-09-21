using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class BibliotecaDbContext : DbContext
    {
        public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options) : base(options) { }
        public DbSet<Autor> Autors { get; set; }
        public DbSet<Copia> Copias { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Lector> Lectors { get; set; }
        public DbSet<Biblioteca> Bibliotecas { get; set; }
    }
}
