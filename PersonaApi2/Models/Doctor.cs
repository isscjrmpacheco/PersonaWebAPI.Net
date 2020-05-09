using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonaApi2.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Materno { get; set; }
        public string Paterno { get; set; }
        public string Especialidad { get; set; }
        public Hospital Hospital { get; set; }
    }
}