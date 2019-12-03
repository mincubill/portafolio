using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SigloXXI.Data;

namespace SigloXXI.Controllers
{
    public class CajaController : Controller
    {
        string _token;
        // GET: Caja
        public ActionResult VerOrdenesSinPago()
        {
            _token = Session["Token"].ToString();
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            var ordenes = new OrdenHeader { Token = _token };
            ViewData["Ordenes"] = ordenes.Obtenerordenes().Where(o => o.estado == EstadoOrden.NoPagado).ToList();
            return View();
        }
        public ActionResult MarcarPago(int id)
        {
            _token = Session["Token"].ToString();
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            var ordenes = new OrdenHeader { Token = _token };
            ordenes.ValidarPago(id);
            return RedirectToAction("VerOrdenesSinPago");
        }
    }
}