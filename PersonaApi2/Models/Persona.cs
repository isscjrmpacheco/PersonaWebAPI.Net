using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonaApi2.Models
{
    public enum ESexo
    {
        Masculino,
        Femenino
    }
    public class Persona
    {
        public string Nombre { get; set; }
        public int Id { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public ESexo Sexo { get; set; }
        public bool Status { get; set; }

    }
}