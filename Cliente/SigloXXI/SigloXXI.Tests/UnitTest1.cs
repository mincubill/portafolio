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
        /*
        [TestMethod]
        public void RestPostTest()
        {
            var url = new UriBuilder("http://127.0.0.1:3000");
            ConexionHelper.Cliente.BaseAddress = new Uri("http://127.0.0.1:3000");
            var queryParams = new Dictionary<string, string>
            {
                { "qwe", "qwe" }
            };
            var content = new FormUrlEncodedContent(queryParams);
            var res = ConexionHelper.Cliente.PostAsync(url + "mostrarUsuario/", content).Result
                .Content.ReadAsStringAsync().Result;
            Assert.AreEqual("1", res);
        }
        */
        [TestMethod]
        public void RestGetTest()
        {
            var url = new UriBuilder("http://127.0.0.1:8080");
            ConexionHelper.Cliente.BaseAddress = new Uri("http://127.0.0.1:8080");
            JsonHelper<Users>.Url = "http://127.0.0.1:8080";
            var result = JsonHelper<Users>.GetList("/usuarios/obtener-usuarios");
            Assert.AreEqual(3, result.Count);
        }
    }
}
