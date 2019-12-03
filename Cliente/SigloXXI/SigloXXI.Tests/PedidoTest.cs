using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SigloXXI.Data;

namespace SigloXXI.Tests
{
    [TestClass]
    public class PedidoTest
    {
        public string _token;
        public void ObtenerToken(string usuario, string contrasena)
        {
            var user = new Usuario();
            user.IniciarSesion(usuario, contrasena);
            _token = user.Token;
        }
        [TestMethod]
        public void AgregarPedido()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            Documentos doc = new Documentos
            {
                Token = _token,
                fecha = DateTime.Now.ToString("yyyy-MM-dd"),
                hora = DateTime.Now.ToShortTimeString(),
                tipo = TipoDocumento.Boleta,
                id = 69,
                pedidoH = new List<PedidoHeader>
                {
                    new PedidoHeader
                    {
                        proveedor = new Proveedores
                        {
                            rut = "77356035-6",
                            nombre = "IMPORTACIONES",
                            telefono = "985467091",
                            direccion = "AV. PORCINO 656",
                            correo = "IMPORTACIONESLTDA@PORCINO.CL",
                        },
                        estado = EstadoPedido.NoRecibido,
                        documentoId = 69,
                        pedidoBId = new List<PedidoBody>
                        {
                            new PedidoBody
                            {
                                productoId = new Productos
                                {
                                    id = 1,
                                    categoria = "INGREDIENTE",
                                    descripcion = "CARNE DE VACUNO",
                                    nombre = "CARNE",
                                    precio = 1500,
                                },
                                cantidad = 10,
                            },

                            new PedidoBody
                            {
                                productoId = new Productos
                                {
                                    id = 2,
                                    categoria = "INGREDIENTE",
                                    descripcion = "TOMATE DULCE",
                                    nombre = "TOMATE",
                                    precio = 600,
                                },
                                cantidad = 50,
                            }
                        }
                    }
                },
                ordenHId = new List<OrdenHeader>(),
            };
            doc.CrearDocumento(doc);
        }
        [TestMethod]
        public void ListarPedidos()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var pedido = new PedidoHeader() { Token = _token };
            var data = pedido.ObtenerPedidos();
            foreach (var d in data)
            {
                
                d.CalcularTotal();
            }
            Assert.IsNotNull(data);
        }
        [TestMethod]
        public void ObtenerPedido()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var pedido = new PedidoHeader() { Token = _token };
            var data = pedido.ObtenerPedido(26);
            Assert.IsNotNull(data);
        }
        [TestMethod]
        public void EliminarPedido()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var pedido = new PedidoHeader() { Token = _token };
            int docId = pedido.ObtenerPedido(26).documentoId;
            var doc = new Documentos { Token = _token };
            doc.EliminarDocumento(docId);
        }
        [TestMethod]
        public void ValidarRecibo()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var pedido = new PedidoHeader() { Token = _token };
        }
        [TestMethod]
        public void ObtenerNumeroDocumento()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var pedido = new PedidoHeader() { Token = _token };
            int docId = pedido.ObtenerPedido(26).documentoId;
            Assert.AreEqual(69, docId);
        }
        [TestMethod]
        public void ObtenerDecumentoDelPedido()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var pedido = new PedidoHeader() { Token = _token };
            var doc = new Documentos() { Token = _token };
            int docId = pedido.ObtenerPedido(26).documentoId;
            doc = doc.ObtenerDocumento(docId);
            Assert.AreEqual(69, doc.id);

        }
        [TestMethod]
        public void ObtenerDecumentosDePedidos()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var doc = new Documentos() { Token = _token };
            var pedidos = doc.ObtenerDocumentos().Where(d => d.pedidoH.Count > 0).ToList();
            var wea = "";
        }
        [TestMethod]
        public void RecibirPedido()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var pedido = new PedidoHeader() { Token = _token };
            pedido = pedido.RecibirPedido(26);
        }
        [TestMethod]
        public void ObtenerDetalles()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var pedido = new PedidoHeader() { Token = _token };
            pedido = pedido.ObtenerPedido(5);
            var detalles = pedido.pedidoBId;
            Assert.IsNotNull(detalles);
        }

    }
}
