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
        [HttpGet]
        public ActionResult AgregarCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarCliente(ClienteModel model)
        {
            var cliente = new Clientes
            {
                Url = "http://weasdf.ddns.net:8082",
                Apellido = model.Apellido,
                Correo = model.Correo,
                Dv = model.Dv,   
                Nombre = model.Nombre,
                Telefono = model.Telefono,
                Rut = model.Rut,
            };
            cliente.CrearCliente(cliente);
            return RedirectToAction("VerClientes");
        }

        [HttpGet]
        public ActionResult VerClientes()
        {
            var cliente = new Clientes() { Url = "http://weasdf.ddns.net:8082" };
            ViewData["Clientes"] = user.ObtenerClientes();
            return View();
        }

        [HttpGet]
        public ActionResult EditarClientes(string rut)
        {
            var cliente = new Clientes() { Url = "http://weasdf.ddns.net:8082" };
            cliente = cliente.ObtenerCliente(int.Parse(rut));
            ViewData["Cliente"] = cliente;
            ClienteModel model = new ClienteModel()
            {
                Apellido = cliente.Apellido,
                Correo = cliente.Correo,
                Dv = cliente.Dv,
                Nombre = cliente.Nombre,
                Rut = cliente.Rut,
                Telefono = cliente.Telefono,
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult EditarClientes(ClienteModel model)
        {
            var cliente = new Clientes
            {
                Url = "http://weasdf.ddns.net:8082",
                Apellido = model.Apellido,
                Correo = model.Correo,
                Dv = model.Dv,
                Nombre = model.Nombre,
                Rut = model.Rut,
                Telefono = model.Telefono,
            };
            cliente.ActualizarCliente(cliente);
            return RedirectToAction("VerClientes");
        }


        public ActionResult EliminarClientes(string rut)
        {
            var cliente = new Clientes() { Url = "http://weasdf.ddns.net:8082" };
            cliente.EliminarCliente(int.Parse(rut));
            return RedirectToAction("VerClientes");

        }
    }
}