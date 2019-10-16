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
            platillo.CrearPlatillo(platillo);
        }
    }
}
