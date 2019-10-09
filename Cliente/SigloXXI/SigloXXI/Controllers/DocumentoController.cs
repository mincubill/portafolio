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
        string _token;
        public ActionResult VerDocumentos()
        {
            _token = Session["Token"].ToString();
            var documento = new Documentos() { Token = _token};
            ViewData["Documentos"] = documento.ObtenerDocumentos();
            return View();
        }
        [HttpGet]
        public ActionResult AgregarDocumentos()
        {
            _token = Session["Token"].ToString();
            return View();
        }

        [HttpPost]
        public ActionResult AgregarDocumentos(DocumentoModel model)
        {
            _token = Session["Token"].ToString();
            var documento = new Documentos()
            {
                Token = _token,
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
            _token = Session["Token"].ToString();
            var documentos = new Documentos() { Token = _token };
            documentos = documentos.ObtenerDocumento(id);
            DocumentoModel model = new DocumentoModel
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
            _token = Session["Token"].ToString();
            var documentos = new Documentos()
            {
                Token = _token,
                Id = model.Id,
                Fecha = model.Fecha,
                Hora = model.Hora,
                Tipo = model.Tipo,
            };
            documentos.ActualizarDocumento(documentos);
            return RedirectToAction("VerDocumentos");

        }

        public ActionResult EliminarDocumentos(int id)
        {
            _token = Session["Token"].ToString();
            var documentos = new Documentos() { Token = _token };
            documentos.EliminarDocumento(id);
            return RedirectToAction("VerDocumentos");
        }
    }
}