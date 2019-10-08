using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SigloXXI.Data;
using SigloXXI.Models;
using System.Web.Mvc;


namespace SigloXXI.Controllers
{
    public class PedidoHController : Controller
    {
        public ActionResult VerPedido_H()
        {
            var pedido_h = new Pedidos_H();
            ViewData["PedidoH"] = pedido_h.ObtenerPedidos_H();
            return View();
        }
        [HttpGet]
        public ActionResult AgregarPedidos_H()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarPedidos_H(PedidoHModel model)
        {
            var pedidos_h = new Pedidos_H()
            {
                Id = model.Id,
                Total = model.Total,
                Proveedor_Id = model.Proveedor_Id,
                Documento_Id = model.Documento_Id,
    };
            pedidos_h.CrearPedido_H(pedidos_h);
            return RedirectToAction("VerPedidos_H");
        }

        [HttpGet]
        public ActionResult EditarPedidos_H(int id)
        {
            var pedidos_h = new Pedidos_H();
            pedidos_h = pedidos_h.ObtenerPedidos_H(id);
            PedidoHModel model = new PedidoHModel
            {
                Id = pedidos_h.Id,
                Total = pedidos_h.Total,
                Proveedor_Id = pedidos_h.Proveedor_Id,
                Documento_Id = pedidos_h.Documento_Id,
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult EditarPedidos_H(PedidoHModel model)
        {
            var pedidos_h = new Pedidos_H()
            {
                Id = model.Id,
                Total = model.Total,
                Proveedor_Id = model.Proveedor_Id,
                Documento_Id = model.Documento_Id,
            };
            pedidos_h.ActualizarPedido_H(pedidos_h);
            return RedirectToAction("VerPedidos_H");

        }

        public ActionResult EliminarPedidos_H(int id)
        {
            var pedidos_h = new Pedidos_H();
            pedidos_h.EliminarPedidos_H(id);
            return RedirectToAction("VerPedidos_H");
        }
    }
}