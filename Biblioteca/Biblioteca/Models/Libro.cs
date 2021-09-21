using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class Libro
    {
        public int Id { get; set; }
        [Required]
        public String Nombre { get; set; }
        [Required]
        public int Tipo { get; set; }
        public String Editorial { get; set; }
        public String Ano { get; set; }
        public List<Autor> Autor { get; set; }
    }
}
