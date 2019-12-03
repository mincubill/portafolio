using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SigloXXI.Data;
using SigloXXI.Models;

namespace SigloXXI.Tests
{
    [TestClass]
    public class UsuariosTest
    {
        public string _token;
        public void ObtenerToken(string usuario, string contrasena)
        {
            var user = new Usuario();
            user.IniciarSesion("mincubill", "palito");
            _token = user.Token;
        }
        [TestMethod]
        public void CrearUsuario()
        {
            ObtenerToken("mincubill", "palito");
            var user = new Usuario()
            {
                Token = _token,
                Nombre = "asdf",
                Apellido = "qwer",
                Correo = "asdf@asdf.asdf",
                Rut = 12345678,
                Dv = '9',
                UserName = "asdf",
                PassWord = "asdf",
                FechaNacimiento = new DateTime(1987, 8, 23),
                rol = Data.RolUsuario.administrador,
            };
            bool res = user.CrearUsuario(user);
            Assert.AreEqual(true, res);
        }
        [TestMethod]
        public void ActualizarUsuario()
        {
            ObtenerToken("mincubill", "palito");
            var user = new Usuario()
            {
                Token = _token,
                Nombre = "asdf",
                Apellido = "qwer",
                Correo = "asdf@asdf.asdf",
                Rut = 12345678,
                Dv = '9',
                UserName = "asdf",
                PassWord = "zxcv",
                FechaNacimiento = new DateTime(1987, 8, 23),
                rol = Data.RolUsuario.finanzas,
            };
            bool res = user.ActualizarUsuario(user);
            Assert.AreEqual(true, res);
        }
        [TestMethod]
        public void EliminarUsuario()
        {
            ObtenerToken("mincubill", "palito");
            var user = new Usuario() { Token = _token };
            bool res = user.EliminarUsuario(12345678);
            Assert.AreEqual(true, res);
        }
        [TestMethod]
        public void ObtenerUsuarios()
        {
            ObtenerToken("mincubill", "palito");
            var user = new Usuario() { Token = _token };
            var res = user.ObtenerUsuarios();
            Assert.IsNotNull(res);
        }
        [TestMethod]
        public void ObtenerUsuario()
        {
            ObtenerToken("mincubill", "palito");
            var user = new Usuario() { Token = _token };
            var res = user.ObtenerUsuario(17287315);
            Assert.IsNotNull(res);
        }
    }
}
