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
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            var prod = new Productos() { Token = _token };
            ViewData["Productos"] = prod.ObtenerProductos();
            return View();
        }
        [HttpGet]
        public ActionResult AgregarProductos()
        {
            _token = Session["Token"].ToString();
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            var prod = new Productos() { Token = _token };
            return View();
        }

        [HttpPost]
        public ActionResult AgregarProductos(ProductoModel model)
        {
            _token = Session["Token"].ToString();
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            if(model.Precio < 0)
            {
                ViewData["error"] = "El precio debe ser mayor a 0";
                return View(model);
            }
            var prod = new Productos()
            {
                Token = _token,
                precio = model.Precio,
                categoria = model.Categoria,
                cantidad = model.Cantidad,
                descripcion = model.Descripcion,
                nombre = model.Nombre,
            };
            prod.CrearProducto(prod);
            return RedirectToAction("VerProductos");
        }

        [HttpGet]
        public ActionResult EditarProductos(int id)
        {
            _token = Session["Token"].ToString();
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            var prod = new Productos() { Token = _token };
            prod = prod.ObtenerProducto(id);
            ProductoModel model = new ProductoModel
            {
                Nombre = prod.nombre,
                Cantidad = prod.cantidad,
                Categoria = prod.categoria,
                Descripcion = prod.descripcion,
                Id = prod.id,
                Precio = prod.precio,
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult EditarProductos(ProductoModel model)
        {
            _token = Session["Token"].ToString();
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            if (model.Precio < 0)
            {
                ViewData["error"] = "El precio debe ser mayor a 0";
                return View(model);
            }
            var prod = new Productos()
            {
                Token = _token,
                precio = model.Precio,
                id = model.Id,
                categoria = model.Categoria,
                cantidad = model.Cantidad,
                descripcion = model.Descripcion,
                nombre = model.Nombre,
            };
            prod.ActualizarProducto(prod);
            return RedirectToAction("VerProductos");
        }

        public ActionResult EliminarProductos(int id)
        {
            _token = Session["Token"].ToString();
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            var prod = new Productos() { Token = _token }; 
            prod.EliminarProducto(id);
            return RedirectToAction("VerProductos");
        }
    }
}