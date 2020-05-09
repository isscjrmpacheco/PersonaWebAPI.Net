using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonaApi2.Models
{
    public class Maestro
    {
        public Persona Persona { get; set; }
        public int IdPersona { get; set; }
        public string Folio { get; set; }
        public string Asignatura { get; set; }
        public double Salario { get; set; }
    }
}