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
        string _token;
        public ActionResult VerProveedores()
        {
            _token = Session["Token"].ToString();
            var proveedores = new Proveedores() { Token = _token };
            ViewData["Proveedores"] = proveedores.ObtenerProveedores();
            return View();
        }
        [HttpGet]
        public ActionResult AgregarProveedores()
        {
            _token = Session["Token"].ToString();
            return View();
        }

        [HttpPost]
        public ActionResult AgregarProveedores(ProveedorModel model)
        {
            _token = Session["Token"].ToString();
            var proveedores = new Proveedores()
            {
                Token = _token,
                rut = model.Rut,
                nombre = model.Nombre,
                telefono = model.Telefono,
                direccion = model.Direccion,
                correo = model.Correo,
            };
            proveedores.CrearProveedor(proveedores);
            return RedirectToAction("VerProveedores");
        }

        [HttpGet]
        public ActionResult EditarProveedores(string rut)
        {
            _token = Session["Token"].ToString();
            var proveedores = new Proveedores() { Token = _token };
            proveedores = proveedores.ObtenerProveedor(rut);
            ProveedorModel model = new ProveedorModel
            {
                Rut = proveedores.rut,
                Nombre = proveedores.nombre,
                Telefono = proveedores.telefono,
                Direccion = proveedores.direccion,
                Correo = proveedores.correo,
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult EditarProveedores(ProveedorModel model)
        {
            _token = Session["Token"].ToString();
            var proveedores = new Proveedores()
            {
                Token = _token,
                rut = model.Rut,
                nombre = model.Nombre,
                telefono = model.Telefono,
                direccion = model.Direccion,
                correo = model.Correo,
            };
            proveedores.ActualizarProveedor(proveedores);
            return RedirectToAction("VerProveedores");

        }

        public ActionResult EliminarProveedores(string id)
        {
            _token = Session["Token"].ToString();
            var proveedores = new Proveedores() { Token = _token };
            proveedores.EliminarProveedor(id);
            return RedirectToAction("VerProveedores");
        }
    }
}