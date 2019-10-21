using SigloXXI.Data;
using SigloXXI.Models;
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
        DocumentoModel _model = new DocumentoModel();
        string _token;
        public ActionResult VerPedidos()
        {
            _token = Session["Token"].ToString();
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            var pedido = new PedidoHeader() { Token = _token };
            var data = pedido.ObtenerPedidos();
            foreach (var p in data)
            {
                p.CalcularTotal();
            }
            ViewData["Pedidos"] = data;
            return View();
        }
        [HttpGet]
        public ActionResult AgregarPedido()
        {
            _token = Session["Token"].ToString();
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            var proveedores = new Proveedores { Token = _token };
            var produtos = new Productos { Token = _token };
            ViewData["Proveedores"] = proveedores.ObtenerProveedores();
            _model.Productos = produtos.ObtenerProductos();
            return View(_model);
        }
        [HttpPost]
        public ActionResult AgregarPedido(DocumentoModel model)
        {
            _token = Session["Token"].ToString();
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            var proveedores = new Proveedores { Token = _token };
            var produtos = new Productos { Token = _token };
            ViewData["Proveedores"] = proveedores.ObtenerProveedores();
            _model.Productos = produtos.ObtenerProductos();
            return View(_model);
        }

        public void AgregarProducto(DocumentoModel model)
        {
            var wea = "";
        }

        public ActionResult VerDetalles(int id)
        {
            _token = Session["Token"].ToString();
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            var pedido = new PedidoHeader() { Token = _token };
            pedido = pedido.ObtenerPedido(id);
            ViewData["Detalles"] = pedido.pedidoBId;
            return View();
        }

        public ActionResult ValidarPedido()
        {
            return RedirectToAction("VerPedidos");
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