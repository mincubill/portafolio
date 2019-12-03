using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SigloXXI.Data;

namespace SigloXXI.Controllers
{
    public class AsignacionController : Controller
    {
        string _token;

        // GET: Asignacion
        public ActionResult Index()
        {
            if (Session["Rol"] == null)
            {
                Session["Rol"] = "";
            }
            return View();
        }
        [HttpPost]
        public ActionResult Index(int cantidad)
        {
            Mesas mesa = new Mesas { Token = _token }.SeleccionMesa(cantidad);
            TempData["mesa"] = mesa;
            return RedirectToAction("VerDetalle");
        }
        public ActionResult VerDetalle()
        {
            var temp = (Mesas)TempData["mesa"];
            ViewData["Detallae"] = temp;
            return View();
        }
    }
}