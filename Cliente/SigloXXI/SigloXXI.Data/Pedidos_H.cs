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
        public string Url { get; set; }
        public Pedidos_H()
        {
            Url = "http://weasdf.ddns.net:8082";
        }

        public bool CrearPedido_H(Pedidos_H pedido_h)
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Users>.Url = Url;
            var queryParams = new Dictionary<string, string>
            {
                {"Id", pedido_h.Id.ToString() },
                {"Total",  pedido_h.Total.ToString()},
                {"Id Proveedor",  pedido_h.Proveedor_Id},
                {"Id Documento",  pedido_h.Documento_Id.ToString()},
            };
            return JsonHelper<Productos>.Post(queryParams, "/pedidos_h/crear-pedido_h");
        }

        public bool ActualizarPedido_H(Pedidos_H pedido_h)
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Users>.Url = Url;
            var queryParams = new Dictionary<string, string>
            {
                {"Id", pedido_h.Id.ToString() },
                {"Total",  pedido_h.Total.ToString()},
                {"Id Proveedor",  pedido_h.Proveedor_Id},
                {"Id Documento",  pedido_h.Documento_Id.ToString()},
            };
            return JsonHelper<Users>.Put(queryParams, "/pedidos_h/actualizar-pedido_h/" + pedido_h.Id);
        }

        public List<Pedidos_H> ObtenerPedidos_H()
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Pedidos_H>.Url = Url;
            var result = JsonHelper<Pedidos_H>.GetList("/pedidos_h/obtener-pedido_h");
            return result;
        }

        public Pedidos_H ObtenerPedidos_H(int id)
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Pedidos_H>.Url = Url;
            var queryParams = new Dictionary<string, string>();
            var res = JsonHelper<Pedidos_H>.Get(queryParams, "/pedidos_h/buscar-pedido_h/" + id.ToString());
            return res;
        }

        public bool EliminarPedidos_H(int id)
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Pedidos_H>.Url = Url;
            var queryParams = new Dictionary<string, string>();
            return JsonHelper<Pedidos_H>.Delete(queryParams, "/pedidos_h/eliminar-pedido_h/" + id.ToString());
        }
    }
}
