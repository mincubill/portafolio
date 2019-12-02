using SigloXXI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SigloXXI.Controllers
{
    public class ReporteController : Controller
    {
        string _token;
        // GET: Reporte
        public ActionResult MesMayorIngreso()
        {
            _token = Session["Token"].ToString();
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            Reportes reportes = new Reportes { Token = _token }.ObtenerMesConMasIngreso();
            ViewData["reporte"] = reportes;
            return View();
        }
        [HttpGet]
        public ActionResult OrdenesDelDia()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OrdenesDelDia(string fecha)
        {
            _token = Session["Token"].ToString();
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            var ordenes = new Reportes { Token = _token }.MovimientosDelDia(fecha);
            ViewData["ordenes"] = ordenes;
            return View("_OrdenesDelDia");
        }

        public ActionResult PedidosDelDia(string fecha)
        {
            _token = Session["Token"].ToString();
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            var ordenes = new Reportes { Token = _token }.PedidosProveedoresDelDia(fecha);
            ViewData["ordenes"] = ordenes;
            return View();
        }

        public ActionResult PlatillosMasConsumidosDelMes(string fecha)
        {
            DateTime fec = DateTime.Parse(fecha);
            _token = Session["Token"].ToString();
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            var platillos = new Reportes { Token = _token }.PlatilloMasConsumidoPorMes(fec.Month, fec.Year);
            ViewData["Reporte"] = platillos;
            return View();
        }

    }
}