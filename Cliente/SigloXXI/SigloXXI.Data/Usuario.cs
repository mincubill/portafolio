using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigloXXI.Data
{
    public class Usuario
    {
        public int Rut { get; set; }
        public char Dv { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public RolUsuario rol { get; set; }
        public string Correo { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public string Token{ get; set; }

        public Usuario IniciarSesion (string userName, string password)
        {
            if(JsonHelper<Usuario>.GetToken(userName, password))
            {
                Token = JsonHelper<Usuario>.Token;
                var result = JsonHelper<Usuario>.GetList("/usuarios/obtener-usuarios");
                var temp = result.FirstOrDefault(u => u.UserName == userName);
                temp.Token = this.Token;
                return temp;
            }
            return null;
        }

        public Usuario CrearUsuario (Usuario usuario)
        {
            var queryParams = new Dictionary<string, string>
            {
                {"rut", usuario.Rut.ToString() },
                {"dv",  usuario.Dv.ToString()},
                {"username",  usuario.UserName},
                {"password",  usuario.PassWord},
                {"nombre",  usuario.Nombre},
                {"apellido",  usuario.Apellido},
                {"rol",  ((int)(usuario.rol)).ToString() },
                {"correo",  usuario.Correo},
                {"fechaNacimiento",  usuario.FechaNacimiento.ToString("yyyy-MM-dd") },
            };
            return JsonHelper<Usuario>.Post(queryParams, "/usuarios/crear-usuario");
        }

        public Usuario ActualizarUsuario(Usuario usuario)
        {
            var queryParams = new Dictionary<string, string>
            {
                {"rut", usuario.Rut.ToString() },
                {"dv",  usuario.Dv.ToString()},
                {"username",  usuario.UserName},
                {"password",  usuario.PassWord},
                {"nombre",  usuario.Nombre},
                {"apellido",  usuario.Apellido},
                {"rol",  ((int)(usuario.rol)).ToString() },
                {"correo",  usuario.Correo},
                {"fechaNacimiento",  usuario.FechaNacimiento.ToString("yyyy-MM-dd") },
            };
            return JsonHelper<Usuario>.Put(queryParams, "/usuarios/actualizar-usuario/"+usuario.Rut);
        }

        public List<Usuario> ObtenerUsuarios()
        {
            var result = JsonHelper<Usuario>.GetList("/usuarios/obtener-usuarios");
            return result;
        }

        public Usuario ObtenerUsuario(int rut)
        {
            var queryParams = new Dictionary<string, string>();
            var res = JsonHelper<Usuario>.Get(queryParams, "/usuarios/buscar-usuario/" + rut.ToString());
            return res;
        }

        public bool EliminarUsuario(int rut)
        {
            var queryParams = new Dictionary<string, string>();
            return JsonHelper<Usuario>.Delete(queryParams, "/usuarios/eliminar-usuario/"+rut);
        }
    }
    public enum RolUsuario
    {
        administrador = 1,
        finanzas = 2,
        bodega = 3,
        cocina = 4,
        bartender = 5,
        mesero = 6,
    }
}
