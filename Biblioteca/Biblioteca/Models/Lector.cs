using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class Lector
    {
        public int Id { get; set; }
        public int LibrosPrestamo { get; set; }
        public DateTime Multa { get; set; }
        public String Copias { get; set; }
        
    }
}
