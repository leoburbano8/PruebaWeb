using BF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BF.Controllers
{
    public class ReservaController : Controller
    {
        PruebaDataContext db = new PruebaDataContext();

        // GET: Consulta
        public ActionResult Index()
        {
            
            return View();
        }

        public JsonResult listarReserva()
        {
            
            var lista = db.d.Where(p => p.habilitado.Equals(1))
                .Select(p => new { p.codigo, p.Persona, p.Vuelo }).ToList();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public JsonResult bReserva(string codin)
        {
            var lista = db.d.Where(p => p.habilitado.Equals(1)
            && p.codigo == new Guid(codin))
                .Select(p => new { p.codigo, p.Persona, p.Vuelo }).ToList();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }
        
    }
}