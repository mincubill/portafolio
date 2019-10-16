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
            
            return View();
        }
        [HttpGet]
        public ActionResult AgregarPedido()
        {
            _token = Session["Token"].ToString();
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