using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SigloXXI.Data;

namespace SigloXXI.Tests
{
    [TestClass]
    public class ProveedoresTest
    {
        public string _token;
        public void ObtenerToken(string usuario, string contrasena)
        {
            var user = new Users();
            user.IniciarSesion(usuario, contrasena);
            _token = user.Token;
        }
        [TestMethod]
        public void ObtenerProveedores()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var prove = new Proveedores() { Token = _token };
            var data = prove.ObtenerProveedores();
            Assert.IsNotNull(data);
        }
    }
}
