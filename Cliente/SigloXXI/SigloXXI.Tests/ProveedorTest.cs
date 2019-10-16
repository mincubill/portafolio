using Microsoft.VisualStudio.TestTools.UnitTesting;
using SigloXXI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigloXXI.Tests
{
    [TestClass]
    public class ProveedorTest
    {
        public string _token;
        public void ObtenerToken(string usuario, string contrasena)
        {
            var user = new Users();
            user.IniciarSesion(usuario, contrasena);
            _token = user.Token;
        }

        [TestMethod]
        public void AgregarProveedor()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            Proveedores proveedor = new Proveedores
            {
                Token = _token,
                rut = "18853947-9",
                correo = "CarneAlPaso@gmail.com",
                direccion = "carnita #699",
                nombre = "Carnes 360",
                telefono = "72169523"               
            };
            proveedor.CrearProveedor(proveedor);
        }
        [TestMethod]
        public void ListarProveedores()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var proveedor = new Proveedores() { Token = _token };
            var data = proveedor.ObtenerProveedores();
            Assert.IsNotNull(data);
        }

        [TestMethod]
        public void ObtenerProveedor()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var proveedor = new Proveedores() { Token = _token };
            var data = proveedor.ObtenerProveedor("77395435-8");
            Assert.IsNotNull(data);
        }

        [TestMethod]
        public void ActualizarProveedor()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            Proveedores pro = new Proveedores() 
            {
                Token = _token,
                rut = "77395435-8",
                correo = "FASTFOODLCDHOTMAIL.COM",
                direccion = "AV. NEXO 154",
                telefono = "985965093",
                nombre = "ENORMIZAR"
            };
            pro.ActualizarProveedor(pro);
        }

        [TestMethod]
        public void EliminarProveedor()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var proveedor = new Proveedores() { Token = _token };
            var proveedorRut = proveedor.ObtenerProveedor("18853947-9").rut;
            proveedor.EliminarProveedor(proveedorRut);
        }
    }
}
