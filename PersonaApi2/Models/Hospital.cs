using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonaApi2.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Horario { get; set; }
        public string Ubicacion { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Logo { get; set; }

    }
}