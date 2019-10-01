using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SigloXXI.Models;
using SigloXXI.Data;

namespace SigloXXI.Controllers
{
    public class DocumentoController : Controller
    {
        public ActionResult VerDocumentos()
        {
            var documento = new Documentos();
            ViewData["Productos"] = documento.ObtenerDocumentos();
            return View();
        }
        [HttpGet]
        public ActionResult AgregarDocumentos()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarDocumentos(DocumentoModel model)
        {
            var documento = new Documentos()
            {
               
                Id = model.Id,
                Fecha = model.Fecha,
                Hora = model.Hora,
                Tipo = model.Tipo,
    };
            documento.CrearDocumento(documento);
            return RedirectToAction("VerDocumento");
        }

        [HttpGet]
        public ActionResult EditarDocumentos(int id)
        {
            var documentos = new Documentos();
            documentos = prod.ObtenerDocumento(id);
            ProductoModel model = new DocumentoModel
            {
                Id = documentos.Id,
                Fecha = documentos.Fecha,
                Hora = documentos.Hora,
                Tipo = documentos.Tipo,
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult EditarDocumentos(DocumentoModel model)
        {
            var documentos = new Documentos()
            {
                Id = model.Id,
                Fecha = model.Fecha,
                Hora = model.Hora,
                Tipo = model.Tipo,
            };
            prod.ActualizarDocumento(documentos);
            return RedirectToAction("VerDocumentos");

        }

        public ActionResult EliminarDocumentos(int id)
        {
            var documentos = new Documentos();
            documentos.EliminarDocumento(id);
            return RedirectToAction("VerDocumentos");
        }
    }
}