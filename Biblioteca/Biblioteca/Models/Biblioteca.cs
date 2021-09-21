using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class Biblioteca
    {
        public int Id { get; set; }
        public List<Lector> Lectores { get; set; }
        public List<Copia> Copias { get; set; }
    }
}
