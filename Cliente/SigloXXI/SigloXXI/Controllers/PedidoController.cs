using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SigloXXI.Controllers
{
    public class PedidoController : Controller
    {
        // GET: Pedido
        public ActionResult VerPedidos()
        {
            return View();
        }
        public ActionResult AgregarPedido()
        {
            return View();
        }
        public ActionResult EditarPedido()
        {
            return View();
        }
        public ActionResult EliminarPedido()
        {
            return View();
        }
    }
}