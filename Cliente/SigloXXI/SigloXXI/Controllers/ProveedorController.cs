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
                Rut = model.Rut,
                Nombre = model.Nombre,
                Telefono = model.Telefono,
                Direccion = model.Direccion,
                Correo = model.Correo,
            };
            proveedores.CrearProveedor(proveedores);
            return RedirectToAction("VerProveedores");
        }

        [HttpGet]
        public ActionResult EditarProveedores(int rut)
        {
            _token = Session["Token"].ToString();
            var proveedores = new Proveedores() { Token = _token };
            proveedores = proveedores.ObtenerProveedor(rut);
            ProveedorModel model = new ProveedorModel
            {
                Rut = proveedores.Rut,
                Nombre = proveedores.Nombre,
                Telefono = proveedores.Telefono,
                Direccion = proveedores.Direccion,
                Correo = proveedores.Correo,
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
                Rut = model.Rut,
                Nombre = model.Nombre,
                Telefono = model.Telefono,
                Direccion = model.Direccion,
                Correo = model.Correo,
            };
            proveedores.ActualizarProveedor(proveedores);
            return RedirectToAction("VerProveedores");

        }

        public ActionResult EliminarProveedores(int id)
        {
            _token = Session["Token"].ToString();
            var proveedores = new Proveedores() { Token = _token };
            proveedores.EliminarProveedor(id);
            return RedirectToAction("VerProveedores");
        }
    }
}