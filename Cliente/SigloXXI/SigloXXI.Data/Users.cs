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
        public string  Url { get; set; }

        public Users()
        {
            Url = "http://192.168.1.13:8082";
        }

        public Users IniciarSesion (string userName, string password)
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Users>.Url = Url;
            var result = JsonHelper<Users>.GetList("/usuarios/obtener-usuarios");
            return result.FirstOrDefault(u => u.UserName == userName && u.PassWord == password);
        }

        public bool CrearUsuario (Users usuario)
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Users>.Url = Url;
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
            return JsonHelper<Users>.Post(queryParams, "/usuarios/crear-usuario");
        }

        public bool ActualizarUsuario(Users usuario)
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Users>.Url = Url;
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
            return JsonHelper<Users>.Put(queryParams, "/usuarios/actualizar-usuario/"+usuario.Rut);
        }

        public List<Users> ObtenerUsuarios()
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Users>.Url = Url;
            var result = JsonHelper<Users>.GetList("/usuarios/obtener-usuarios");
            return result;
        }

        public Users ObtenerUsuario(int rut)
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Users>.Url = Url;
            var queryParams = new Dictionary<string, string>();
            var res = JsonHelper<Users>.Get(queryParams, "/usuarios/buscar-usuario/" + rut.ToString());
            return res;
        }

        public bool EliminarUsuario(int rut)
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Users>.Url = Url;
            var queryParams = new Dictionary<string, string>();
            return JsonHelper<Users>.Delete(queryParams, "/usuarios/eliminar-usuario/"+rut);
            
        }


    }
}
