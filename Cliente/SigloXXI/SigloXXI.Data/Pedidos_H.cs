using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigloXXI.Data
{
    public class Pedidos_H
    {
        public int Id { get; set; }
        public int Total { get; set; }
        public string Proveedor_Id { get; set; }
        public int Documento_Id { get; set; }
        public string Token { get; set; }

        public bool CrearPedido_H(Pedidos_H pedido_h)
        {
            var queryParams = new Dictionary<string, string>
            {
                {"Id", pedido_h.Id.ToString() },
                {"Total",  pedido_h.Total.ToString()},
                {"Id Proveedor",  pedido_h.Proveedor_Id},
                {"Id Documento",  pedido_h.Documento_Id.ToString()},
            };
            JsonHelper<Pedidos_H>.Token = this.Token;
            return JsonHelper<Pedidos_H>.Post(queryParams, "/pedidos_h/crear-pedido_h");
        }

        public bool ActualizarPedido_H(Pedidos_H pedido_h)
        {
            var queryParams = new Dictionary<string, string>
            {
                {"Id", pedido_h.Id.ToString() },
                {"Total",  pedido_h.Total.ToString()},
                {"Id Proveedor",  pedido_h.Proveedor_Id},
                {"Id Documento",  pedido_h.Documento_Id.ToString()},
            };
            JsonHelper<Pedidos_H>.Token = this.Token;
            return JsonHelper<Pedidos_H>.Put(queryParams, "/pedidos_h/actualizar-pedido_h/" + pedido_h.Id);
        }

        public List<Pedidos_H> ObtenerPedidos_H()
        {
            JsonHelper<Pedidos_H>.Token = this.Token;
            var result = JsonHelper<Pedidos_H>.GetList("/pedidos_h/obtener-pedido_h");
            return result;
        }

        public Pedidos_H ObtenerPedidos_H(int id)
        {
            JsonHelper<Pedidos_H>.Token = this.Token;
            var queryParams = new Dictionary<string, string>();
            var res = JsonHelper<Pedidos_H>.Get(queryParams, "/pedidos_h/buscar-pedido_h/" + id.ToString());
            return res;
        }

        public bool EliminarPedidos_H(int id)
        {
            JsonHelper<Pedidos_H>.Token = this.Token;
            var queryParams = new Dictionary<string, string>();
            return JsonHelper<Pedidos_H>.Delete(queryParams, "/pedidos_h/eliminar-pedido_h/" + id.ToString());
        }
    }
}