using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigloXXI.Data
{
    public class Users
    {
        public int Rut { get; set; }
        public char Dv { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int rol { get; set; }
        public string Correo { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public Users IniciarSesion (string userName, string password)
        {
            var url = new UriBuilder("http://127.0.0.1:8080");
            ConexionHelper.Cliente.BaseAddress = new Uri("http://127.0.0.1:8080");
            JsonHelper<Users>.Url = "http://127.0.0.1:8080";
            var result = JsonHelper<Users>.GetList("/usuarios/obtener-usuarios");
            return result.FirstOrDefault(u => u.UserName == userName && u.PassWord == password);
        }

        public bool CrearUsuario (Users usuario)
        {
            var url = new UriBuilder("http://127.0.0.1:8080");
            ConexionHelper.Cliente.BaseAddress = new Uri("http://127.0.0.1:8080");
            JsonHelper<Users>.Url = "http://127.0.0.1:8080";
            var queryParams = new Dictionary<string, string>
            {
                {"rut", usuario.Rut.ToString() },
                {"dv",  usuario.Dv.ToString()},
                {"username",  usuario.UserName},
                {"password",  usuario.PassWord},
                {"nombre",  usuario.Nombre},
                {"apellido",  usuario.Apellido},
                {"rol",  usuario.rol.ToString() },
                {"correo",  usuario.Correo},
                {"fechaNacimiento",  usuario.FechaNacimiento.ToShortDateString() },
            };
            JsonHelper<Users>.Post(queryParams, "/usuarios/crear-usuario");
            return false;
        }

        public List<Users> ObtenerUsuarios()
        {
            var url = new UriBuilder("http://127.0.0.1:8080");
            ConexionHelper.Cliente.BaseAddress = new Uri("http://127.0.0.1:8080");
            JsonHelper<Users>.Url = "http://127.0.0.1:8080";
            var result = JsonHelper<Users>.GetList("/usuarios/obtener-usuarios");
            return result;
        }
    }
}
