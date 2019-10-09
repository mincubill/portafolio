using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SigloXXI.Data;
using SigloXXI.Models;
using System.Web.Mvc;

namespace SigloXXI.Controllers
{
    public class PlatilloController : Controller
    {
        public ActionResult VerPlatillos()
        {
            var plat = new Platillo();
            ViewData["Platillo"] = plat.ObtenerPlatillos();
            return View();
        }

        [HttpGet]
        public ActionResult AgregarPlatillo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarPlatillo(PlatilloModel model)
        {
            var plat = new Platillo()
            {
                Id = model.Id,
                Nombre = model.Nombre,
                Tiempo = model.Tiempo,
            };
            plat.CrearPlatillo(plat);
            return RedirectToAction("VerPlatillos");
        }

        [HttpGet]
        public ActionResult EditarPlatillo(int id)
        {
            var plat = new Platillo();
            plat = plat.ObtenerPlatillo(id);
            PlatilloModel model = new PlatilloModel
            {
                Id = plat.Id,
                Nombre = plat.Nombre,
                Tiempo = plat.Tiempo,
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult EditarPlatillo(PlatilloModel model)
        {
            var plat = new Platillo()
            {
                Id = model.Id,
                Nombre = model.Nombre,
                Tiempo = model.Tiempo,
            };
            plat.ActualizarPlatillo(plat);
            return RedirectToAction("VerPlatillos");
        }

        public ActionResult EliminarPlatillo(int id)
        {
            var plat = new Platillo();
            plat.EliminarPlatillo(id);
            return RedirectToAction("VerPlatillos");
        }
    }
}