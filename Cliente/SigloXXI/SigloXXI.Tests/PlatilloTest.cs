using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SigloXXI.Data;

namespace SigloXXI.Tests
{
    [TestClass]
    public class PlatilloTest
    {
        public string _token;
        public void ObtenerToken(string usuario, string contrasena)
        {
            var user = new Users();
            user.IniciarSesion(usuario, contrasena);
            _token = user.Token;
        }

        [TestMethod]
        public void ListarPlatillos()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var platillo = new Platillo()
            {
                Token = _token
            };
            var platilloList = platillo.ObtenerPlatillos();
            Assert.AreEqual(true, platilloList != null);
        }

        [TestMethod]
        public void CrearPlatillo()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var platillo = new Platillo()
            {
                Token = _token,
                nombre = "Humita chilena",
                tiempo = 30,
                ingredienteId = new List<Ingredientes>()
                {
                    new Ingredientes()
                    {
                        cantidad = 5,
                        productoId = new Productos()
                        {
                            id = 41,
                            nombre = "CHOCLO",
                            descripcion = "CHOCLO AMARILLO",
                            cantidad = 50,
                            precio = 200,
                            categoria = "INGREDIENTE"
                        }
                    },
                    new Ingredientes()
                    {
                        cantidad = 3,
                        productoId = new Productos()
                        {
                            id = 42,
                            nombre = "CEBOLLA",
                            descripcion = "CEBOLLA TRADICIONAL",
                            cantidad = 50,
                            precio = 500,
                            categoria = "INGREDIENTE"
                        }
                    }
                }
            };
            bool res = platillo.CrearPlatillo(platillo);
            Assert.AreEqual(true, res);
        }

        [TestMethod]
        public void BuscarPlatillo()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var platillo = new Platillo()
            {
                Token = _token
            };
            platillo = platillo.ObtenerPlatillo(61);
            Assert.AreEqual(true, platillo != null);
        }

        [TestMethod]
        public void ActualizarPlatillo()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var platillo = new Platillo()
            {
                id = 61,
                Token = _token,
                nombre = "HUMITA",
                tiempo = 25,
                ingredienteId = new List<Ingredientes>()
                {
                    new Ingredientes()
                    {
                        cantidad = 5,
                        productoId = new Productos()
                        {
                            id = 41,
                            nombre = "CHOCLO",
                            descripcion = "CHOCLO AMARILLO",
                            cantidad = 50,
                            precio = 200,
                            categoria = "INGREDIENTE"
                        }
                    },
                    new Ingredientes()
                    {
                        cantidad = 3,
                        productoId = new Productos()
                        {
                            id = 42,
                            nombre = "CEBOLLA",
                            descripcion = "CEBOLLA TRADICIONAL",
                            cantidad = 50,
                            precio = 500,
                            categoria = "INGREDIENTE"
                        }
                    }
                }
            };
            Assert.AreEqual(true, platillo.ActualizarPlatillo(platillo));
        }
        
        [TestMethod]
        public void EliminarPlatillo()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var platillo = new Platillo()
            {
                Token = _token
            };
            Assert.AreEqual(true, platillo.EliminarPlatillo(61));
        }
    }
}
