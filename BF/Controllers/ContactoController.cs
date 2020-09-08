using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace BF.Controllers
{
    public class ContactoController : Controller
    {
        // GET: Contacto
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Nuevo(Contacto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (PruebaDataContext db = new PruebaDataContext())
                    {
                        var oTabla = new Contacto();
                        oTabla.correo = model.correo;
                        oTabla.mensaje = model.mensaje;

                        db.Contacto.InsertOnSubmit(oTabla);
                        db.SubmitChanges();
                     
                    }

                    return Redirect("~/Contacto/");
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