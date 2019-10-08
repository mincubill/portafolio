using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SigloXXI.Data;
using SigloXXI.Models;
using System.Web.Mvc;


namespace SigloXXI.Controllers
{
    public class MesaController : Controller
    {
        public ActionResult VerMesas()
        {
            var mesa = new Mesas();
            ViewData["Mesas"] = mesa.ObtenerMesas();
            return View();
        }

        [HttpGet]
        public ActionResult AgregarMesas()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarMesas(MesaModel model)
        {
            var mesa = new Mesas()
            {
                Id = model.Id,
                Numero = model.Numero,
                Capacidad = model.Capacidad,
            };
            mesa.CrearMesa(mesa);
            return RedirectToAction("VerMesas");
        }

        [HttpGet]
        public ActionResult EditarMesas(int id)
        {
            var mesa = new Mesas();
            mesa = mesa.ObtenerMesa(id);
            MesaModel model = new MesaModel
            {
                Id = mesa.Id,
                Numero = mesa.Numero,
                Capacidad = mesa.Capacidad,
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult EditarMesas(MesaModel model)
        {
            var mesa = new Mesas()
            {
                Id = model.Id,
                Numero = model.Numero,
                Capacidad = model.Capacidad,
            };
            mesa.ActualizarMesa(mesa);
            return RedirectToAction("VerMesas");
        }

        public ActionResult EliminarMesas(int id)
        {
            var mesa = new Mesas();
            mesa.EliminarMesa(id);
            return RedirectToAction("VerMesas");
        }
    }
}