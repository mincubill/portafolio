using SigloXXI.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SigloXXI.Models
{
    public class DocumentoModel
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Código: ")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Fecha: ")]
        public DateTime Fecha { get; set; }
        public TipoDocumento Tipo { get; set; }
        public string ProveedorRut { get; set; }
        public PedidoHeader Pedido { get; set; }
        public PedidoBody PedidoDetalle { get; set; }
        public List<Productos> Productos { get; set; }
        public List<PedidoHeader> Pedidos { get; set; }
        public List<OrdenHeader> Ordenes { get; set; }
        public List<Proveedores> Proveedores { get; set; }
    }
    public enum TipoDocumento
    {
        Boleta = 1,
        OrdenDeCompra = 2,
        NotaCredito = 3,
        NotaDebito = 4,
    }
}