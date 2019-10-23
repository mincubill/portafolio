﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigloXXI.Data
{
    public class PedidoHeader
    {
        public int id { get; set; }
        public int total { get; set; }
        public EstadoPedido estado { get; set; }
        public Proveedores proveedor { get; set; }
        public int documentoId { get; set; }
        public List<PedidoBody> pedidoBId { get; set; }
        public string Token { get; set; }
    
        public List<PedidoHeader> ObtenerPedidos()
        {
            JsonHelper<PedidoHeader>.Token = this.Token;
            var result = JsonHelper<PedidoHeader>.GetList("/pedidoh/obtener-pedidoh");
            return result;
        }

        public PedidoHeader ObtenerPedido(int id)
        {
            JsonHelper<PedidoHeader>.Token = this.Token;
            var queryParams = new Dictionary<string, string>();
            var res = JsonHelper<PedidoHeader>.Get(queryParams, "/pedidoh/buscar-pedidoh/" + id.ToString());
            return res;
        }

        public PedidoHeader RecibirPedido(int id)
        {
            JsonHelper<PedidoHeader>.Token = this.Token;
            var queryParams = new Dictionary<string, string>();
            var res = JsonHelper<PedidoHeader>.Get(queryParams, "/pedidoh/cambiar-estado-pedidoh/" + id.ToString());
            return res;
        }

        public void CalcularTotal()
        {
            if(pedidoBId != null)
            {
                foreach(var p in pedidoBId)
                {
                    total += p.cantidad * p.total;
                }
            }
        }

    }

    public enum EstadoPedido
    {
        NoRecibido = 2,
        Recibido = 1,
    }

}