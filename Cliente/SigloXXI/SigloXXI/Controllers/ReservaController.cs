using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SigloXXI.Data;
using SigloXXI.Models;

namespace SigloXXI.Controllers
{
    public class ReservaController : Controller
    {
        string _token;
        Reserva _reserva;
        // GET: Reserva
        public ActionResult VerReservas()
        {
            _token = Session["Token"].ToString();
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            var reserva = new Reserva { Token = _token };
            ViewData["Reservas"] = reserva.ObtenerReservas();
            return View();
        }
        [HttpGet]
        public ActionResult AgregarReserva()
        {
            ViewData["error"] = "";
            _token = Session["Token"].ToString();
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            var reserva = new Reserva { Token = _token };
            var clientes = new Clientes { Token = _token };
            var mesas = new Mesas { Token = _token };
            ViewData["Clientes"] = clientes.ObtenerClientes();
            ViewData["Mesas"] = mesas.ObtenerMesas().Where(m => m.estado == EstadoMesa.Disponible).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult AgregarReserva(ReservaModel model)
        {
            _token = Session["Token"].ToString();
            var clientes = new Clientes { Token = _token };
            ViewData["Clientes"] = clientes.ObtenerClientes();
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            var reserva = new Reserva
            {
                Token = _token,
                cantidadPersonas = model.cantidadPersonas,
                clienteId = new Clientes { Token = _token }.ObtenerCliente(model.clienteId),
                //mesaId = new Mesas { Token = _token }.ObtenerMesa(model.mesaId),
                fecha = model.fecha,
                hora = model.hora,
                estado = EstadoReserva.NoOcupada,
            };
            //_reserva = reserva.CrearReserva(reserva);
            //return RedirectToAction("VerDetalleReserva");
            var res = reserva.CrearReserva(reserva);
            TempData["Reserva"] = res;
            return RedirectToAction("VerDetalleReserva", "Reserva");
        }
        [HttpPost]
        public ActionResult AgregarReservaSinClienteRegistrado(ReservaModel model)
        {
            var reserva = new Reserva
            {
                Token = _token,
                cantidadPersonas = model.cantidadPersonas,
                clienteId = new Clientes
                {
                    apellido = model.Cliente.apellido,
                    correo = model.Cliente.correo,
                    dv = model.Cliente.dv,
                    nombre = model.Cliente.nombre,
                    rut = model.Cliente.rut,
                    telefono = model.Cliente.telefono,
                },
               
                fecha = model.fecha,
                hora = model.hora,
                estado = EstadoReserva.NoOcupada,
            };
            var res = reserva.CrearReserva(reserva);
            TempData["Reserva"] = res;
            return RedirectToAction("VerDetalleReserva", "Reserva");
        }
        public ActionResult EditarReserva(int id)
        {
            _token = Session["Token"].ToString();
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            var mesas = new Mesas { Token = _token };
            ViewData["Mesas"] = mesas.ObtenerMesas().Where(m => m.estado == EstadoMesa.Disponible).ToList();
            var reserva = new Reserva { Token = _token }.ObtenterReserva(id);
            ViewData["Cliente"] = reserva.clienteId;
            ReservaModel model = new ReservaModel
            {
                id = reserva.id,
                cantidadPersonas = reserva.cantidadPersonas,
                clienteId = reserva.clienteId.rut,
                fecha = reserva.fecha,
                hora = reserva.hora,
                mesaId = reserva.mesaId.id,
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult EditarReserva(ReservaModel model)
        {
            _token = Session["Token"].ToString();
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            if (DateTime.Parse(model.fecha) < DateTime.Now)
            {
                ViewData["error"] = "Fecha no puede ser menor a la actual";
                return View(model);
            }
            var reserva = new Reserva()
            {
                Token = _token,
                id = model.id,
                fecha = model.fecha,
                hora = model.hora,
                cantidadPersonas = model.cantidadPersonas,
                mesaId = new Mesas { Token = _token }.ObtenerMesa(model.mesaId),
                clienteId = new Clientes { Token = _token }.ObtenerCliente(model.clienteId),
            };
            reserva.ActualizarReserva(reserva);
            return RedirectToAction("VerReservas");

        }
        public ActionResult EliminarReserva(int id)
        {
            _token = Session["Token"].ToString();
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            var reserva = new Reserva { Token = _token };
            reserva.EliminarReserva(id);
            return RedirectToAction("VerReservas");

        }

        public ActionResult ValidarReserva(int id)
        {
            _token = Session["Token"].ToString();
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            var reserva = new Reserva { Token = _token };
            reserva.ValidarReserva(id);
            return RedirectToAction("VerReservas");

        }

        public ActionResult VerDetalleReserva()
        {
            var res = (Reserva)TempData["Reserva"];
            ViewData["Detalle"] = res;
            return View("VerDetalleReserva");
        }
    }
}