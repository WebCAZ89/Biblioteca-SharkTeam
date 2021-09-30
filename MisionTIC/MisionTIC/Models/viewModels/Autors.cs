using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MisionTIC.Models.viewModels
{
    public class Autors
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Nacionalidad { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}