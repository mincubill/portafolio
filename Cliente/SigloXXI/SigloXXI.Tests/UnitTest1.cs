using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SigloXXI.Data;
using SigloXXI.Models;

namespace SigloXXI.Tests
{
    [TestClass]
    public class UnitTest1
    {
        public object JsonConvert { get; private set; }

        [TestMethod]
        public void RestPostTest()
        {
            var user = new Users()
            {
                Url = "http://192.168.1.13:8082",
                Apellido = "cubillos",
                Correo = "mincubill@gmail.com",
                Dv = '4',
                FechaNacimiento = DateTime.Now,
                Nombre = "andres",
                PassWord = "asdsadsa",
                rol = 1,
                Rut = 17287315,
                UserName = "mincubill",
            };
            //user.CrearUsuario(user);
            //user.ObtenerUsuario(18732997);
            //user.EliminarUsuario(12321);
            user.ActualizarUsuario(user);

            var cliente = new Clientes()
            {
                Url = "http://192.168.1.13:8082",
                Apellido = "retamal",
                Correo = "alanageorgina@gmail.com",
                Dv = '4',
                FechaNacimiento = DateTime.Now,
                Nombre = "andres",
                PassWord = "asdsadsa",
                rol = 1,
                Rut = 17287315,
                UserName = "mincubill",
            };
            //user.CrearUsuario(user);
            //user.ObtenerUsuario(18732997);
            //user.EliminarUsuario(12321);
            user.ActualizarUsuario(user);
        }


        //[TestMethod]
        //public void RestGetTest()
        //{
        //    var url = new UriBuilder("http://127.0.0.1:8080");
        //    ConexionHelper.Cliente.BaseAddress = new Uri("http://127.0.0.1:8080");
        //    JsonHelper<Users>.Url = "http://127.0.0.1:8080";
        //    var result = JsonHelper<Users>.GetList("/usuarios/obtener-usuarios");
        //    Assert.AreEqual(3, result.Count);
        //}
    }
}
