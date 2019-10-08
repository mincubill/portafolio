﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SigloXXI.Data;
using SigloXXI.Models;
using System.Web.Mvc;

namespace SigloXXI.Controllers
{
    public class PlatilloController : Controller
    {
        string _token;
        public ActionResult VerPlatillos()
        {
            _token = Session["Token"].ToString();
            var plat = new Platillo() { Token = _token };
            ViewData["Platillo"] = plat.ObtenerPlatillos();
            return View();
        }

        [HttpGet]
        public ActionResult AgregarPlatillo()
        {
            _token = Session["Token"].ToString();
            return View();
        }

        [HttpPost]
        public ActionResult AgregarPlatillo(PlatilloModel model)
        {
            _token = Session["Token"].ToString();
            var plat = new Platillo()
            {
                Token = _token,
                Id = model.Id,
                Nombre = model.Nombre,
                Tiempo = model.Tiempo,
            };
            plat.CrearPlatillo(plat);
            return RedirectToAction("VerPlatillos");
        }

        [HttpGet]
        public ActionResult EditarPlatillo(int id)
        {
            _token = Session["Token"].ToString();
            var plat = new Platillo() { Token = _token };
            plat = plat.ObtenerPlatillo(id);
            PlatilloModel model = new PlatilloModel
            {
                Id = plat.Id,
                Nombre = plat.Nombre,
                Tiempo = plat.Tiempo,
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult EditarPlatillo(PlatilloModel model)
        {
            _token = Session["Token"].ToString();
            var plat = new Platillo()
            {
                Token = _token,
                Id = model.Id,
                Nombre = model.Nombre,
                Tiempo = model.Tiempo,
            };
            plat.ActualizarPlatillo(plat);
            return RedirectToAction("VerPlatillos");
        }

        public ActionResult EliminarPlatillo(int id)
        {
            _token = Session["Token"].ToString();
            var plat = new Platillo() { Token = _token };
            plat.EliminarPlatillo(id);
            return RedirectToAction("VerPlatillos");
        }
    }
}