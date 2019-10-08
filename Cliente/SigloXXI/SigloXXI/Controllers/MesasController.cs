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
        string _token;
        public ActionResult VerMesas()
        {
            _token = Session["Token"].ToString();
            var mesa = new Mesas() { Token = _token };
            ViewData["Mesas"] = mesa.ObtenerMesas();
            return View();
        }

        [HttpGet]
        public ActionResult AgregarMesas()
        {
            _token = Session["Token"].ToString();
            return View();
        }

        [HttpPost]
        public ActionResult AgregarMesas(MesaModel model)
        {
            _token = Session["Token"].ToString();
            var mesa = new Mesas()
            {
                Token = _token,
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
            _token = Session["Token"].ToString();
            var mesa = new Mesas() { Token = _token };
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
            _token = Session["Token"].ToString();
            var mesa = new Mesas()
            {
                Token = _token,
                Id = model.Id,
                Numero = model.Numero,
                Capacidad = model.Capacidad,
            };
            mesa.ActualizarMesa(mesa);
            return RedirectToAction("VerMesas");
        }

        public ActionResult EliminarMesas(int id)
        {
            _token = Session["Token"].ToString();
            var mesa = new Mesas() { Token = _token };
            mesa.EliminarMesa(id);
            return RedirectToAction("VerMesas");
        }
    }
}