using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SigloXXI.Data;

namespace SigloXXI.Tests
{
    [TestClass]
    public class ReporteTest
    {
        public string _token;
        public void ObtenerToken(string usuario, string contrasena)
        {
            var user = new Usuario();
            user.IniciarSesion(usuario, contrasena);
            _token = user.Token;
        }
        [TestMethod]
        public void ObtenerMesConMasIngreso()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var reporte = new Reportes { Token = _token };
            reporte = reporte.ObtenerMesConMasIngreso();
            Assert.IsNotNull(reporte);
        }

        [TestMethod]
        public void MovimientosDelDia()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var reporte = new Reportes { Token = _token };
            var res = reporte.MovimientosDelDia("2019-11-28");
            Assert.IsNotNull(reporte);
        }

        [TestMethod]
        public void PlatilloMasPedidoDelMes()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var reporte = new Reportes { Token = _token };
            var res = reporte.PlatilloMasConsumidoPorMes(11, 2019);
            Assert.IsNotNull(reporte);
        }
    }
}
