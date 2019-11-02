using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SigloXXI.Data;

namespace SigloXXI.Tests
{
    [TestClass]
    public class ReservasTest
    {
        public string _token;
        public void ObtenerToken(string usuario, string contrasena)
        {
            var user = new Usuario();
            user.IniciarSesion(usuario, contrasena);
            _token = user.Token;
        }
        [TestMethod]
        public void CrearReserva()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var reserva = new Reserva
            {
                Token = _token,
                cantidadPersonas = 2,
                clienteId = new Clientes { Token = _token}.ObtenerClientes()[0],
                fecha = DateTime.Now.ToString("yyyy-MM-dd"),
                hora = DateTime.Now.ToString("HH:mm"),
                mesaId = new Mesas { Token = _token }.ObtenerMesas()[0],
                estado = EstadoReserva.NoOcupada,
            };
            Assert.AreEqual(true, reserva.CrearReserva(reserva));
            
        }
        [TestMethod]
        public void ObtenerReserva()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var reserva = new Reserva { Token = _token };
            var data = reserva.ObtenterReserva(1);
            Assert.IsNotNull(data);
        }
        [TestMethod]
        public void ObtenerReservas()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var reserva = new Reserva { Token = _token };
            var data = reserva.ObtenerReservas();
            Assert.IsNotNull(data);
        }
        [TestMethod]
        public void ActualizarReserva()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var reserva = new Reserva { Token = _token }.ObtenterReserva(1);
            reserva.Token = _token;
            reserva.estado = EstadoReserva.Ocupada;
            Assert.AreEqual(true,reserva.ActualizarReserva(reserva));
        }
        [TestMethod]
        public void EliminarReserva()
        {
            ObtenerToken("ADMINISTRADOR", "ASDF");
            var reserva = new Reserva { Token = _token };
            Assert.AreEqual(true, reserva.EliminarReserva(62));
        }
    }
}
