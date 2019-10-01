using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SigloXXI.Data;
using SigloXXI.Models;
using System.Web.Mvc;

namespace SigloXXI.Controllers
{
    public class IngredienteController : Controller
    {
        public ActionResult VerIngredientes()
        {
            var ingredientes = new Ingredientes();
            ViewData["Ingredientes"] = prod.ObtenerIngredientes();
            return View();
        }
        [HttpGet]
        public ActionResult AgregarIngredientes()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarIngredientes(IngredienteModel model)
        {
            var ingredientes = new Ingredientes()
            {
                Precio = model.Precio,
                Id = model.Id,
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