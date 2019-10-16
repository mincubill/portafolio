﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SigloXXI.Data;
using SigloXXI.Models;
using System.Web.Mvc;


namespace SigloXXI.Controllers
{
    public class MesasController : Controller
    {
        string _token;
        public ActionResult VerMesasDisponibles()
        {
            _token = Session["Token"].ToString();
            var mesa = new Mesas() { Token = _token };
            ViewData["Mesas"] = mesa.ObtenerMesas();
            return View();
        }

        [HttpGet]
        public ActionResult AgregarMesa()
        {
            _token = Session["Token"].ToString();
            return View();
        }

        [HttpPost]
        public ActionResult AgregarMesa(MesaModel model)
        {
            _token = Session["Token"].ToString();
            var mesa = new Mesas()
            {
                Token = _token,
                id = model.Id,
                numero = model.Numero,
                capacidad = model.Capacidad,
            };
            mesa.CrearMesa(mesa);
            return RedirectToAction("VerMesasDisponibles");
        }

        [HttpGet]
        public ActionResult EditarMesa(int id)
        {
            _token = Session["Token"].ToString();
            var mesa = new Mesas() { Token = _token };
            mesa = mesa.ObtenerMesa(id);
            MesaModel model = new MesaModel
            {
                Id = mesa.id,
                Numero = mesa.numero,
                Capacidad = mesa.capacidad,
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult EditarMesa(MesaModel model)
        {
            _token = Session["Token"].ToString();
            var mesa = new Mesas()
            {
                Token = _token,
                id = model.Id,
                numero = model.Numero,
                capacidad = model.Capacidad,
            };
            mesa.ActualizarMesa(mesa);
            return RedirectToAction("VerMesasDisponibles");
        }

        public ActionResult EliminarMesa(int id)
        {
            _token = Session["Token"].ToString();
            var mesa = new Mesas() { Token = _token };
            mesa.EliminarMesa(id);
            return RedirectToAction("VerMesasDisponibles");
        }
    }
}