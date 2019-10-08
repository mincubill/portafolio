using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SigloXXI.Data;
using SigloXXI.Models;
using System.Web.Mvc;

namespace SigloXXI.Controllers
{
    public class ProductoController : Controller
    {
        private string _token;
        public ActionResult VerProductos()
        {
            _token = Session["Token"].ToString();
            var prod = new Productos() { Token = _token };
            ViewData["Productos"] = prod.ObtenerProductos();
            return View();
        }
        [HttpGet]
        public ActionResult AgregarProductos()
        {
            _token = Session["Token"].ToString();
            var prod = new Productos() { Token = _token };
            return View();
        }

        [HttpPost]
        public ActionResult AgregarProductos(ProductoModel model)
        {
            var prod = new Productos()
            {
                Token = _token,
                Precio = model.Precio,
                Categoria = model.Categoria,
                Cantidad = model.Cantidad,
                Descripcion = model.Descripcion,
                Nombre = model.Nombre,
            };
            prod.CrearProducto(prod);
            return RedirectToAction("VerProductos");
        }

        [HttpGet]
        public ActionResult EditarProductos(int id)
        {
            var prod = new Productos();
            prod = prod.ObtenerProducto(id);
            ProductoModel model = new ProductoModel
            {
                Nombre = prod.Nombre,
                Cantidad = prod.Cantidad,
                Categoria = prod.Categoria,
                Descripcion = prod.Descripcion,
                Id = prod.Id,
                Precio = prod.Precio,
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult EditarProductos(ProductoModel model)
        {
            var prod = new Productos()
            {
                Precio = model.Precio,
                Id = model.Id,
                Categoria = model.Categoria,
                Cantidad = model.Cantidad,
                Descripcion = model.Descripcion,
                Nombre = model.Nombre,
            };
            prod.ActualizarProducto(prod);
            return RedirectToAction("VerProductos");
        }

        public ActionResult EliminarProductos(int id)
        {
            var prod = new Productos();
            prod.EliminarProducto(id);
            return RedirectToAction("VerProductos");
        }
    }
}