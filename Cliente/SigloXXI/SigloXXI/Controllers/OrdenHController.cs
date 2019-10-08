using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SigloXXI.Models;
using SigloXXI.Data;

namespace SigloXXI.Controllers
{
    public class OrdenHControllers : Controller
    {
        [HttpGet]
        public ActionResult AgregarOrden_H()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarOrden_H(OrdenHModel model)
        {
            var orden_h = new Orden_H
            {
                Url = "http://weasdf.ddns.net:8082",
                Id = model.Id,
                Total = model.Total,
                Estado = model.Estado,
                Documento_Id = model.Documento_Id,
                Mesa_Id = model.Mesa_Id,
            };    
            orden_h.CrearOrden_H(orden_h);
            return RedirectToAction("VerOrden_H");
        }

        [HttpGet]
        public ActionResult VerOrden_H()
        {
            var orden_h = new Orden_H() { Url = "http://weasdf.ddns.net:8082" };
            ViewData["Orden_H"] = orden_h.Obtenerorden_H();
            return View();
        }

        [HttpGet]
        public ActionResult Editarorden_H(int Id)
        {
            var orden_h = new Orden_H() { Url = "http://weasdf.ddns.net:8082" };
            orden_h = orden_h.ObtenerOrdenH(Id);
            ViewData["Orden H"] = orden_h;
            OrdenHModel model = new OrdenHModel()
            {
                Id = orden_h.Id,
                Total = orden_h.Total,
                Estado = orden_h.Estado,
                Documento_Id = orden_h.Documento_Id,
                Mesa_Id = orden_h.Mesa_Id,
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult EditarOrden_H(OrdenHModel model)
        {
            var orden_h = new Orden_H
            {
                Url = "http://weasdf.ddns.net:8082",
                Id = model.Id,
                Total = model.Total,
                Estado = model.Estado,
                Documento_Id = model.Documento_Id,
                Mesa_Id = model.Mesa_Id,
            };
            orden_h.ActualizarOrden_H(orden_h);
            return RedirectToAction("VerOrden_H");
        }


        public ActionResult EliminarOrden_H(int Id)
        {
            var ordenh = new Orden_H() { Url = "http://weasdf.ddns.net:8082" };
            ordenh.EliminarOrdenH(Id);
            return RedirectToAction("VerOrden_H");

        }
    }
}