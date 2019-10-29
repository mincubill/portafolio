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

        [TestMethod]
        public void ObtenerProveedor()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var prove = new Proveedores() { Token = _token };
            var data = prove.ObtenerProveedor("77356035-6");
            Assert.IsNotNull(data);            
        }

        [TestMethod]
        public void AgregarProveedor()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var prove = new Proveedores
            {
                Token = _token,
                correo = "Upa@upa.cl",
                direccion = "Av del valle 750",
                nombre = "UPA SpA",
                rut = "12345678-9",
                telefono = "6666969"
            };
            bool res = prove.CrearProveedor(prove);
            Assert.AreEqual(true, res);
        }
                
        [TestMethod]
        public void EditarProveedor()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var prove = new Proveedores
            {
                Token = _token,
                correo = "Upa@upa.cl",
                direccion = "Av del valle 750",
                nombre = "UPA SpA",
                rut = "12345678-9",
                telefono = "3216547"
            };
            bool res = prove.ActualizarProveedor(prove);
            Assert.AreEqual(true, res);
        }

        [TestMethod]
        public void EliminarProveedor()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var prove = new Proveedores() { Token = _token };
            bool res = prove.EliminarProveedor("12345678-9");
            Assert.AreEqual(true, res);
        }
    }
}
