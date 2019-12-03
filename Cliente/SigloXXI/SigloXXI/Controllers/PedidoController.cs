using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            _token = Session["Token"].ToString();

            var proveedores = new Proveedores { Token = _token };
            var produtos = new Productos { Token = _token };
            ViewData["Proveedores"] = proveedores.ObtenerProveedores();
            ViewData["Productos"] = produtos.ObtenerProductos();
            return View(_model);
        }
        [HttpPost]
        public ActionResult AgregarPedido(string data)
        {
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            _token = Session["Token"].ToString();
            var proveedores = new Proveedores { Token = _token };
            var productos = new Productos { Token = _token };
            ViewData["Proveedores"] = proveedores.ObtenerProveedores();
            ViewData["Productos"] = productos.ObtenerProductos();
            var pedidoDocumento = JsonConvert.DeserializeObject<DocumentoModel>(data);
            var documento = new Documentos
            {
                Token = _token,
                fecha = DateTime.Parse(pedidoDocumento.Fecha).ToString("yyyy-MM-dd"),
                hora = DateTime.Parse(pedidoDocumento.Fecha).ToString("HH:mm"),
                ordenHId = new List<OrdenHeader>(),
                pedidoH = pedidoDocumento.Pedidos.Select(p =>
                new PedidoHeader
                {
                    proveedor = new Proveedores{ Token = _token }.ObtenerProveedor(p.ProveedorRut),
                    pedidoBId = p.DetallePedido.Select(d => new PedidoBody
                    {
                        Token = _token,
                        cantidad = d.Cantidad,
                        productoId = new Productos { Token = _token }.ObtenerProducto(d.Codigo),
                    }).ToList(),
                    estado = EstadoPedido.NoRecibido,
                }).ToList(),
                tipo = Data.TipoDocumento.OrdenDeCompra,
                
            };
            var doc = documento.CrearDocumento(documento);
            

            return Json(Url.Action("VerDocumento", "Documento", new { id = doc.id }));
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

        public ActionResult ValidarPedido(int id)
        {
            _token = Session["Token"].ToString();
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            var pedido = new PedidoHeader() { Token = _token };
            pedido.RecibirPedido(id);
            return RedirectToAction("VerPedidos");
        }

        public ActionResult EditarPedido()
        {

            return View();
        }

        public ActionResult EliminarPedido(int id)
        {
            _token = Session["Token"].ToString();
            var pedido = new PedidoHeader() { Token = _token };
            var doc = new Documentos() { Token = _token };
            doc.EliminarDocumento(pedido.ObtenerPedido(id).documentoId);
            return RedirectToAction("VerPedidos");
        }
    }
}