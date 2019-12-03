using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SigloXXI.Data;

namespace SigloXXI.Tests
{
    [TestClass]
    public class OrdenesTest
    {
        public string _token;
        public void ObtenerToken(string usuario, string contrasena)
        {
            var user = new Usuario();
            user.IniciarSesion(usuario, contrasena);
            _token = user.Token;
        }

        [TestMethod]
        public void AgregarOrden()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            Documentos doc = new Documentos
            {
                Token = _token,
                fecha = DateTime.Now.ToString("yyyy-MM-dd"),
                hora = DateTime.Now.ToShortTimeString(),
                tipo = TipoDocumento.Boleta,
                id = 70,
                ordenHId = new List<OrdenHeader>
                {
                    new OrdenHeader
                    {
                        estado = EstadoOrden.Pagado,
                        mesaId = new Mesas
                        {
                            id = 1,
                            capacidad = 2,
                            numero = 1
                        },
                        documentoId = 5,
                        ordenBId = new List<OrdenBody>
                        {
                            new OrdenBody
                            {
                                cantidad = 2,
                                platilloId = new Platillo
                                {
                                    id = 1,
                                    nombre = "Pollo con papas",
                                    tiempo = 30
                                },
                                subTotal = 1000,
                            },

                            new OrdenBody
                            {
                                cantidad = 5,
                                platilloId = new Platillo
                                {
                                    id = 2,
                                    nombre = "Carne con arroz y tocino",
                                    tiempo = 40
                                },
                                subTotal = 15000,
                            },
                        }
                    }
                }
            };
            doc.CrearDocumento(doc);
        }

        [TestMethod]
        public void ListarOdenes()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var orden = new OrdenHeader() { Token = _token };
            var ordenes = orden.Obtenerordenes();
            foreach(var o in ordenes)
            {
                o.CalcularTotal();
            }
            Assert.IsNotNull(ordenes);
        }

        [TestMethod]
        public void ObtenerOrden()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var orden = new OrdenHeader() { Token = _token };
            var data = orden.ObtenerOrden(25);
            Assert.IsNotNull(data);
        }

        [TestMethod]
        public void ValidarPago()
        {
        }
    }
}
