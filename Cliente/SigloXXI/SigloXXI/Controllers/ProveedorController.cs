using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SigloXXI.Data;
using SigloXXI.Models;
using System.Web.Mvc;

namespace SigloXXI.Controllers
{
    public class ProveedorController : Controller
    {
        public ActionResult VerProveedores()
        {
            var proveedores = new Proveedores();
            ViewData["Proveedores"] = prod.ObtenerProveedores();
            return View();
        }
        [HttpGet]
        public ActionResult AgregarProveedores()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarProveedores(ProveedorModel model)
        {
            var proveedores = new Proveedores()
            {
                Rut = model.Rut,
                Nombre = model.Nombre,
                Telefobo = model.Telefono,
                Direccion = model.Direccion,
                Correo = model.Correo,
                Nombre = model.Nombre,
            };
            proveedores.CrearProducto(proveedores);
            return RedirectToAction("VerProveedores");
        }

        [HttpGet]
        public ActionResult EditarProveedores(int rut)
        {
            var proveedores = new Proveedores();
            proveedores = proveedores.ObtenerProveedores(id);
            ProveedoresModel model = new ProveedoresModel
            {
                Rut = proveedores.Rut,
                Nombre = proveedores.Nombre,
                Telefobo = proveedores.Telefono,
                Direccion = proveedores.Direccion,
                Correo = proveedores.Correo,
                Nombre = proveedores.Nombre,
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult EditarProveedores(ProveedoresModel model)
        {
            var proveedores = new Proveedores()
            {
                Rut = model.Rut,
                Nombre = model.Nombre,
                Telefobo = model.Telefono,
                Direccion = model.Direccion,
                Correo = model.Correo,
                Nombre = model.Nombre,
            };
            proveedores.ActualizarProducto(proveedores);
            return RedirectToAction("VerProveedores");

        }

        public ActionResult EliminarProveedores(int id)
        {
            var proveedores = new Proveedores();
            proveedores.EliminarProveedor(id);
            return RedirectToAction("VerProveedores");
        }
    }
}