using System;
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
            var user = new Users();
            user.IniciarSesion(usuario, contrasena);
            _token = user.Token;
        }
        [TestMethod]
        public void ObtenerProductos()
        {
            ObtenerToken("mincubill", "palito");
            var prod = new Productos() { Token = _token };
            var res = prod.ObtenerProductos();
            Assert.IsNotNull(res);
        }
        [TestMethod]
        public void ObtenerProducto()
        {
            ObtenerToken("mincubill", "palito");
            var prod = new Productos() { Token = _token };
            var res = prod.ObtenerProducto(1);
            Assert.IsNotNull(res);
        }
        [TestMethod]
        public void CrearProducto()
        {
            ObtenerToken("mincubill", "palito");
            var prod = new Productos()
            {
                Token = _token,
                cantidad = 1,
                categoria = "ingrediente",
                descripcion = "transgenico",
                nombre = "tomaco",
                precio = 800,
            };
            bool res = prod.CrearProducto(prod);
            Assert.AreEqual(true, res);
        }
        [TestMethod]
        public void ActualizarProducto()
        {
            ObtenerToken("mincubill", "palito");
            var prod = new Productos()
            {
                Token = _token,
                cantidad = 10,
                categoria = "ingrediente",
                descripcion = "transgenico",
                nombre = "tomaco",
                precio = 1800,
            };
            bool res = prod.ActualizarProducto(prod);
            Assert.AreEqual(true, res);
        }
        [TestMethod]
        public void EliminarProducto()
        {
            ObtenerToken("mincubill", "palito");
            var prod = new Productos() { Token = _token };
            var res = prod.EliminarProducto(1);
            Assert.AreEqual(true, res);
        }
    }
}
