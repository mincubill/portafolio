using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SigloXXI.Data;
using SigloXXI.Models;
using System.Web.Mvc;

namespace SigloXXI.Controllers
{
    public class ClienteController : Controller
    {
        string _token;
        [HttpGet]
        public ActionResult AgregarCliente()
        {
            _token = Session["Token"].ToString();
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public ActionResult AgregarCliente(ClienteModel model)
        {
            _token = Session["Token"].ToString();
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            var cliente = new Clientes
            {
                Token = _token,
                Correo = model.Correo,
                Dv = model.Dv,
                Nombre = model.Nombre,
                Apellido = model.Apellido,
                Telefono = model.Telefono,
                Rut = model.Rut,
            };
            cliente.CrearCliente(cliente);
            return RedirectToAction("VerClientes");
        }

        [HttpGet]
        public ActionResult VerClientes()
        {
            _token = Session["Token"].ToString();
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            var cliente = new Clientes() { Token = _token };
            ViewData["Clientes"] = cliente.ObtenerClientes();
            return View();
        }

        [HttpGet]
        public ActionResult EditarClientes(string Rut)
        {
            _token = Session["Token"].ToString();
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            var cliente = new Clientes() { Token = _token };
            cliente = cliente.ObtenerCliente(int.Parse(Rut));
            ViewData["Cliente"] = cliente;
            ClienteModel model = new ClienteModel()
            {
                Correo = cliente.Correo,
                Dv = cliente.Dv,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Rut = cliente.Rut,
                Telefono = cliente.Telefono,
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult EditarClientes(ClienteModel model)
        {
            _token = Session["Token"].ToString();
            var cliente = new Clientes
            {
                Token = _token,
                Correo = model.Correo,
                Dv = model.Dv,
                Nombre = model.Nombre,
                Rut = model.Rut,
                Telefono = model.Telefono,
            };
            cliente.ActualizarClientes(cliente);
            return RedirectToAction("VerClientes");
        }


        public ActionResult EliminarClientes(string rut)
        {
            _token = Session["Token"].ToString();
            var cliente = new Clientes() { Token = _token };
            cliente.EliminarCliente(int.Parse(rut));
            return RedirectToAction("VerClientes");

        }
    }
}