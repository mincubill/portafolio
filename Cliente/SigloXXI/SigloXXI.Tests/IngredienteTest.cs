using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SigloXXI.Data;

namespace SigloXXI.Tests
{
    [TestClass]
    public class IngredienteTest
    {
        public string _token;
        public void ObtenerToken(string usuario, string contrasena)
        {
            var user = new Usuario();
            user.IniciarSesion(usuario, contrasena);
            _token = user.Token;
        }

        [TestMethod]
        public void ListarIngredientes()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var ingrediente = new Ingredientes()
            {
                Token = _token
            };
            var ingredienteList = ingrediente.ObtenerIngredientes();
            Assert.AreEqual(true, ingredienteList != null);
        }

        [TestMethod]
        public void CrearIngrediente()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var ingrediente = new Ingredientes()
            {
                Token = _token,
                cantidad = 15,
                platilloId = 62,
                productoId = new Productos()
                {
                    id = 61,
                    nombre = "AZUCAR",
                    descripcion = "AZUCAR",
                    cantidad = 5,
                    precio = 1500,
                    categoria = "INGREDIENTE"
                }
            };
            Assert.AreEqual(true, ingrediente.CrearIngrediente(ingrediente));
        }

        [TestMethod]
        public void BuscarIngrediente()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var ingrediente = new Ingredientes()
            {
                Token = _token
            };
            Assert.AreEqual(true, ingrediente.ObtenerIngrediente(85) != null);
        }

        [TestMethod]
        public void ActualizarIngrediente()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var ingrediente = new Ingredientes()
            {
                Token = _token,
                id = 85,
                cantidad = 1,
                platilloId = 62,
                productoId = new Productos()
                {
                    id = 61,
                    nombre = "AZUCAR",
                    descripcion = "AZUCAR",
                    cantidad = 5,
                    precio = 1500,
                    categoria = "INGREDIENTE"
                }
            };
            Assert.AreEqual(true, ingrediente.ActualizarIngrediente(ingrediente));
        }

        [TestMethod]
        public void EliminarIngrediente()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var ingrediente = new Ingredientes()
            {
                Token = _token
            };
            Assert.AreEqual(true, ingrediente.EliminarIngrediente(85));
        }
    }
}
