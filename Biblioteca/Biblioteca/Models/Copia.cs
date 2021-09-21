using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class Copia
    {
        public int Id { get; set; }
        [Required]
        public String Estado { get; set; }
        [Required]
        public DateTime FechaPrestamo { get; set; }
        public List<Libro> Libro { get; set; }
    }
}
