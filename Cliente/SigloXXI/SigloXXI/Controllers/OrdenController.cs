using SigloXXI.Data;
using SigloXXI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SigloXXI.Controllers
{
    public class OrdenController : Controller
    {
        DocumentoModel _model = new DocumentoModel();
        string _token;
        // GET: Orden
        public ActionResult VerOrdenes()
        {
            _token = Session["Token"].ToString();
            if(string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            var orden = new OrdenHeader { Token = _token };
            var data = orden.Obtenerordenes();
            foreach (var o in data)
            {
                o.CalcularTotal();
            }
            ViewData["Ordenes"] = data;
            return View();
        }
        [HttpGet]
        public ActionResult AgregarOrden()
        {
            _token = Session["Token"].ToString();
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult AgregarOrden(DocumentoModel model)
        {
            return View();
        }
        public ActionResult VerDetalles(int id)
        {
            _token = Session["Token"].ToString();
            var orden = new OrdenHeader { Token = _token };
            ViewData["Detalles"] = orden.ObtenerOrden(id).ordenBId;
            return View();
        }
        public ActionResult EditarOrden(int id)
        {
            return View();
        }
        public ActionResult EliminarOrden(int id)
        {
            return View();
        }
        public ActionResult PagarOrden(int id)
        {
            return RedirectToAction("");
        }
    }
}