﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SigloXXI.Data;

namespace SigloXXI.Tests
{
    [TestClass]
    public class ProductosTest
    {
        public string _token;
        public void ObtenerToken(string usuario, string contrasena)
        {
            var user = new Usuario();
            user.IniciarSesion(usuario, contrasena);
            _token = user.Token;
        }
        [TestMethod]
        public void ObtenerProductos()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var prod = new Productos() { Token = _token };
            var res = prod.ObtenerProductos();
            Assert.IsNotNull(res);
        }
        [TestMethod]
        public void ObtenerProducto()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var prod = new Productos() { Token = _token };
            var res = prod.ObtenerProducto(1);
            Assert.IsNotNull(res);
        }
        [TestMethod]
        public void CrearProducto()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var prod = new Productos()
            {
                Token = _token,
                cantidad = 1,
                categoria = "ingrediente",
                descripcion = "transgenico",
                nombre = "tomaco",
                precio = 800,
            };
            var res = prod.CrearProducto(prod);
            Assert.IsNull(res);
        }
        [TestMethod]
        public void ActualizarProducto()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var prod = new Productos()
            {
                Token = _token,
                cantidad = 10,
                categoria = "ingrediente",
                descripcion = "transgenico",
                nombre = "tomaco",
                precio = 1800,
            };
            var res = prod.ActualizarProducto(prod);
            Assert.IsNull(res);
        }
        [TestMethod]
        public void EliminarProducto()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var prod = new Productos() { Token = _token };
            var res = prod.EliminarProducto(1);
            Assert.AreEqual(true, res);
        }
    }
}
