using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SigloXXI.Data
{
    public static class JsonHelper<T>
    {
        public static string Token { get; set; }

        public static string Url { get; set; } = "http://192.168.1.13:8082";
        //public static string Url { get; set; } = "http://weasdf.ddns.net:8082";

        public static T Get(Dictionary<string, string> queryParams, string metodo)
        {
            if (!string.IsNullOrEmpty(Token))
            {
                try
                {
                    var cliente = new RestClient(Url + metodo);
                    var request = new RestRequest(Method.GET);
                    request.AddHeader("cache-control", "no-cache");
                    request.AddHeader("content-type", "application/x-www-form-urlencoded");
                    request.AddHeader("Authorization", $"Bearer {Token}");
                    IRestResponse response = cliente.Execute(request);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return JsonConvert.DeserializeObject<T>(response.Content);
                    }
                    else
                    {
                        throw new ArgumentException("Error al obetener datos - respuesta: " + response.Content);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            else
            {
                throw new ArgumentException("No hay token disponible");
            }
        }

        public static T GetNoToken(Dictionary<string, string> queryParams, string metodo)
        {
            try
            {
                var cliente = new RestClient(Url + metodo);
                var request = new RestRequest(Method.GET);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("content-type", "application/x-www-form-urlencoded");
                IRestResponse response = cliente.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<T>(response.Content);
                }
                else
                {
                    throw new ArgumentException("Error al obetener datos - respuesta: " + response.Content);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static List<T> GetList(string metodo)
        {
            try
            {
                if (!string.IsNullOrEmpty(Token))
                {
                    var cliente = new RestClient(Url + metodo);
                    var request = new RestRequest(Method.GET);
                    request.AddHeader("cache-control", "no-cache");
                    request.AddHeader("content-type", "application/json");
                    request.AddHeader("Authorization", $"Bearer {Token}");
                    IRestResponse response = cliente.Execute(request);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return JsonConvert.DeserializeObject<List<T>>(response.Content);
                    }
                    else
                    {
                        throw new ArgumentException("Error al obetener datos - respuesta: " + response.Content);
                    }
                }
                else
                {
                    throw new ArgumentException("No hay token disponible");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static List<T> GetListNoToke(string metodo)
        {
            try
            {

                var cliente = new RestClient(Url + metodo);
                var request = new RestRequest(Method.GET);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("content-type", "application/json");
                IRestResponse response = cliente.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<List<T>>(response.Content);
                }
                else
                {
                    throw new ArgumentException("Error al obetener datos - respuesta: " + response.Content);
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static T Post(Dictionary<string, string> param, string metodo)
        {
            try
            {
                if (!string.IsNullOrEmpty(Token))
                {
                    var cliente = new RestClient(Url + metodo);
                    var request = new RestRequest(Method.POST);
                    request.AddHeader("cache-control", "no-cache");
                    request.AddHeader("content-type", "application/json");
                    request.AddHeader("Authorization", $"Bearer {Token}");
                    request.RequestFormat = DataFormat.Json;
                    request.AddJsonBody(JsonConvert.SerializeObject(param));
                    IRestResponse response = cliente.Execute(request);
                    if (response.StatusCode == System.Net.HttpStatusCode.Created)
                    {
                        return JsonConvert.DeserializeObject<T>(response.Content);
                        //return true;
                    }
                    else
                    {
                        throw new ArgumentException("Error al ingresar datos - respuesta: " + response.Content);
                    }
                }
                else
                {
                    throw new ArgumentException("No hay token");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static T Post(object param, string metodo)
        {
            try
            {
                if (!string.IsNullOrEmpty(Token))
                {
                    var cliente = new RestClient(Url + metodo);
                    var request = new RestRequest(Method.POST);
                    request.AddHeader("cache-control", "no-cache");
                    request.AddHeader("content-type", "application/json");
                    request.AddHeader("Authorization", $"Bearer {Token}");
                    request.RequestFormat = DataFormat.Json;
                    var data = JsonConvert.SerializeObject(param);
                    request.AddJsonBody(JsonConvert.SerializeObject(param));
                    IRestResponse response = cliente.Execute(request);
                    if (response.StatusCode == System.Net.HttpStatusCode.Created)
                    {
                        return JsonConvert.DeserializeObject<T>(response.Content);
                        //return true;
                    }
                    else
                    {
                        throw new ArgumentException("Error al ingresar datos - respuesta: " + response.Content);
                    }
                }
                else
                {
                    throw new ArgumentException("No hay token");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static T PostNoToken(object param, string metodo)
        {
            try
            {

                var cliente = new RestClient(Url + metodo);
                var request = new RestRequest(Method.POST);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("content-type", "application/json");
                request.RequestFormat = DataFormat.Json;
                var data = JsonConvert.SerializeObject(param);
                request.AddJsonBody(JsonConvert.SerializeObject(param));
                IRestResponse response = cliente.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    return JsonConvert.DeserializeObject<T>(response.Content);
                    //return true;
                }
                else
                {
                    throw new ArgumentException("Error al ingresar datos - respuesta: " + response.Content);
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static T Put(Dictionary<string, string> param, string metodo)
        {
            try
            {
                if (!string.IsNullOrEmpty(Token))
                {
                    var cliente = new RestClient(Url + metodo);
                    var request = new RestRequest(Method.PUT);
                    request.AddHeader("cache-control", "no-cache");
                    request.AddHeader("content-type", "application/json");
                    request.AddHeader("Authorization", $"Bearer {Token}");
                    request.RequestFormat = DataFormat.Json;
                    request.AddJsonBody(JsonConvert.SerializeObject(param));
                    var data = JsonConvert.SerializeObject(param);
                    IRestResponse response = cliente.Execute(request);
                    if (response.StatusCode == System.Net.HttpStatusCode.Created)
                    {
                        return JsonConvert.DeserializeObject<T>(response.Content);
                        //return true;
                    }
                    else
                    {
                        throw new ArgumentException("Error al actualizar datos - respuesta: " + response.Content);
                    }
                }
                else
                {
                    throw new ArgumentException("No hay token");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static T Put(object param, string metodo)
        {
            try
            {
                if (!string.IsNullOrEmpty(Token))
                {
                    var cliente = new RestClient(Url + metodo);
                    var request = new RestRequest(Method.PUT);
                    request.AddHeader("cache-control", "no-cache");
                    request.AddHeader("content-type", "application/json");
                    request.AddHeader("Authorization", $"Bearer {Token}");
                    request.RequestFormat = DataFormat.Json;
                    var data = JsonConvert.SerializeObject(param);
                    request.AddJsonBody(JsonConvert.SerializeObject(param));
                    IRestResponse response = cliente.Execute(request);
                    if (response.StatusCode == System.Net.HttpStatusCode.Created)
                    {
                        return JsonConvert.DeserializeObject<T>(response.Content);
                        //return true;
                    }
                    else
                    {
                        throw new ArgumentException("Error al actualizar datos - respuesta: " + response.Content);
                    }
                }
                else
                {
                    throw new ArgumentException("No hay token");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static bool Delete(Dictionary<string, string> param, string metodo)
        {
            try
            {
                if (!string.IsNullOrEmpty(Token))
                {
                    var cliente = new RestClient(Url + metodo);
                    var request = new RestRequest(Method.DELETE);
                    request.AddHeader("cache-control", "no-cache");
                    request.AddHeader("content-type", "application/json");
                    request.AddHeader("Authorization", $"Bearer {Token}");
                    IRestResponse response = cliente.Execute(request);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return true;
                    }
                    else
                    {
                        throw new ArgumentException("Error al eliminar datos - respuesta: " + response.Content);
                    }
                }
                else
                {
                    throw new ArgumentException("No hay token");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static bool GetToken(string usuario, string contrasena)
        {
            try
            {
                var cliente = new RestClient(Url + "/oauth/token");
                cliente.Authenticator = new HttpBasicAuthenticator(".net", "123");
                var request = new RestRequest(Method.POST);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("content-type", "application/x-www-form-urlencoded");
                request.AddParameter($"application/x-www-form-urlencoded",
                    $"grant_type=password&username={usuario}&password={contrasena}",
                    ParameterType.RequestBody);
                IRestResponse response = cliente.Execute(request);
                var data = (JObject)JsonConvert.DeserializeObject(response.Content);
                Token = data["access_token"].ToString();
                if (!string.IsNullOrEmpty(Token))
                    return true;
                else
                    throw new ArgumentException("Error al obtener token - Respuesta: " + response.Content);
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        public static string ParseParametros(Dictionary<string, string> param)
        {
            var data = "";
            foreach (var p in param.Keys)
            {
                data += $"{p}={param[p]}";
                if (param.Count > 1)
                {
                    data += "&";
                }
            }
            if (data[data.Length - 1] == '&')
            {
                data = data.Remove(data.Length - 1);
            }
            return data;
        }
    }
}
