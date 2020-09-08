using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BF.Models
{
    public class Contacto
    {
        public int Id { get; set; }
        public string Correo { get; set; }
        public string Mensaje { get; set; }
    }
}