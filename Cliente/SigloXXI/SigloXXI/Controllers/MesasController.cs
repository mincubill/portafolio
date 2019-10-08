using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SigloXXI.Data;
using SigloXXI.Models;

namespace SigloXXI.Controllers
{
    public class MesasController : Controller
    {
        // GET: Mesas
        public ActionResult VerMesasDisponibles()
        {
            var mesa = new Mesas();
            ViewData["mesas"] = mesa.ObtenerMesas();
            return View();
        }

        public ActionResult AgregarMesa()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarMesa(MesaModel model)
        {
            var mesa = new Mesas()
            {
                Id = model.Id,
                Capacidad = model.Capacidad,
                Numero = model.Numero,
            };
            mesa.CrearMesas(mesa);
            return View();
        }

        [HttpGet]
        public ActionResult EditarMesa(int id)
        {
            var mesa = new Mesas();
            mesa.ObtenerMesa(id);
            MesaModel model = new MesaModel
            {
                Capacidad = mesa.Capacidad,
                Id = mesa.Id,
                Numero = mesa.Numero,
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult EditarMesa(MesaModel model)
        {
            var mesa = new Mesas()
            {
                Id = model.Id,
                Capacidad = model.Capacidad,
                Numero = model.Numero,
            };
            mesa.EditarMesa(mesa);
            return RedirectToAction("VerMesasDisponibles");
        }

        public ActionResult EliminarMesa(int id)
        {
            var mesa = new Mesas();
            mesa.EliminarMesa(id);
            return RedirectToAction("VerMesasDisponibles");
        }
    }
}