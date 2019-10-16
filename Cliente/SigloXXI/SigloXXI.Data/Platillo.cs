﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigloXXI.Data
{
    public class Platillo
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int tiempo { get; set; }
        public string Token { get; set; }

        public List<Ingredientes> ingredienteId { get; set; }

        public bool CrearPlatillo(Platillo platillo)
        {
            JsonHelper<Platillo>.Token = this.Token;
            return JsonHelper<Platillo>.Post(platillo, "/platillos/crear-platillo");
        }

        public bool ActualizarPlatillo(Platillo platillo)
        {
            
            var queryParams = new Dictionary<string, string>
            {
                {"id", platillo.id.ToString() },
                {"nombre",  platillo.nombre},
                {"tiempo",  platillo.tiempo.ToString()},
            };
            JsonHelper<Platillo>.Token = this.Token;
            return JsonHelper<Platillo>.Put(queryParams, "/productos/actualizar-producto/" + platillo.id);
        }

        public List<Platillo> ObtenerPlatillos()
        {
            JsonHelper<Platillo>.Token = this.Token;
            var result = JsonHelper<Platillo>.GetList("/platillos/obtener-platillo");
            return result;
        }

        public Platillo ObtenerPlatillo(int id)
        {
            JsonHelper<Platillo>.Token = this.Token;
            var queryParams = new Dictionary<string, string>();
            var res = JsonHelper<Platillo>.Get(queryParams, "/platillos/buscar-platillo/" + id.ToString());
            return res;
        }

        public bool EliminarPlatillo(int id)
        {
            JsonHelper<Platillo>.Token = this.Token;
            var queryParams = new Dictionary<string, string>();
            return JsonHelper<Platillo>.Delete(queryParams, "/platillos/eliminar-platillos/" + id.ToString());
        }
    }
}
