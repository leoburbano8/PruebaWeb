using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BF.Models
{
    public class Vuelo
    {
        public int id { get; set; }
        public string CiudadOrigen { get; set; }
        public string CiudadDestino { get; set; }
        public DateTime Fecha { get; set; }
        public int NumeroVuelo { get; set; }
        public int Precio { get; set; }
        public string Moneda { get; set; }
    }
}