using BF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace BF.Controllers
{
    public class VueloController : Controller
    {
        PruebaDataContext db = new PruebaDataContext();
        // GET: Inicio
        public ActionResult Index()
        {

            return View();
        }

        public JsonResult listarVuelo()
        {

            var lista = db.Vuelo.Where(p => p.habilitado.Equals(1))
                .Select(p => new { p.Ciudad_Origen,
                                   p.Ciudad_Destino,
                                   fechav = ((DateTime)p.Fecha).ToShortDateString(),
                                   horav = ((DateTime)p.Fecha).ToLongTimeString(),
                                   p.NumeroVuelo,
                                   p.Precio,
                                   p.Moneda
                }).ToList();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public JsonResult bVuelo(string corigen, string cdestino)
        {
            var lista = db.Vuelo.Where(p => p.habilitado.Equals(1)
            && p.Ciudad_Origen.Equals(corigen) && p.Ciudad_Destino.Equals(cdestino))
               .Select(p => new {
                   p.Ciudad_Origen,
                   p.Ciudad_Destino,
                   fechav = ((DateTime)p.Fecha).ToShortDateString(),
                   horav = ((DateTime)p.Fecha).ToLongTimeString(),
                   p.NumeroVuelo,
                   p.Precio,
                   p.Moneda
               }).ToList();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Nuevo(d model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (PruebaDataContext db = new PruebaDataContext())
                    {
                        var oTabla = new d();
                        oTabla.Persona = model.Persona;
                        oTabla.Vuelo = model.Vuelo;

                        db.d.InsertOnSubmit(oTabla);
                        db.SubmitChanges();

                    }

                    return Redirect("~/Vuelo");
                }

                return View(model);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}