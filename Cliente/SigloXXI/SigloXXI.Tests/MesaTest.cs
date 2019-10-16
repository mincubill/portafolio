using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SigloXXI.Data;

namespace SigloXXI.Tests
{
    [TestClass]
    public class MesaTest
    {
        public string _token;
        public void ObtenerToken(string usuario, string contrasena)
        {
            var user = new Users();
            user.IniciarSesion(usuario, contrasena);
            _token = user.Token;
        }
        [TestMethod]
        public void CrearMesa()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            Mesas mesa = new Mesas
            {
                Token = _token,
                numero = 12,
                capacidad = 6,                
            };
            mesa.CrearMesa(mesa);
        }

        [TestMethod]
        public void ListarMesas()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var mesa = new Mesas() { Token = _token };
            var data = mesa.ObtenerMesas();
            Assert.IsNotNull(data);
        }

        [TestMethod]
        public void ObtenerMesa()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var mesa = new Mesas() { Token = _token };
            var data = mesa.ObtenerMesa(10);
            Assert.IsNotNull(data);
        }

        [TestMethod]
        public void ActualizarMesa()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            Mesas mesa = new Mesas
            {
                Token = _token,
                id = 10,
                capacidad = 2,
                numero = 10,                
            };
            mesa.ActualizarMesa(mesa);
        }

        [TestMethod]
        public void EliminarMesa()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var mesa = new Mesas() { Token = _token };
            mesa.EliminarMesa(42);
        }
    }
}
