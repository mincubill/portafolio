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
            var data = pedido.ObtenerPedidos().OrderByDescending(p => p.id).ToList();
           
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
                        subtotal = new Productos { Token = _token }.ObtenerProducto(d.Codigo).precio * d.Cantidad,
                    }).ToList(),
                    estado = EstadoPedido.NoRecibido,
                }).ToList(),
                tipo = Data.TipoDocumento.OrdenDeCompra,
            };
            documento.pedidoH[0].total = documento.pedidoH.Sum(p => p.pedidoBId.Sum(b => b.subtotal));
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