using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BF.Models
{
    public class Aeropuerto
    {
       
        public int id { get; set; }

        public string Nombre { get; set; }
        
        public string Ciudad{ get; set; }
    }
}