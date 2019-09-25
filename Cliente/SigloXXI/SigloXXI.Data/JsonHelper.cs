using Newtonsoft.Json;
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
        public static string Url { get; set; }

        public static T Get(Dictionary<string, string> queryParams, string metodo)
        {
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            var content = new FormUrlEncodedContent(queryParams);
            var res = ConexionHelper.Cliente.GetAsync(Url + metodo).Result
                .Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(res);
        }

        public static List<T> GetList(string metodo)
        {
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            var res = ConexionHelper.Cliente.GetStringAsync(Url + metodo).Result;
            return JsonConvert.DeserializeObject<List<T>>(res);
        }

        public static List<T> GetListPorId(Dictionary<string, string> queryParams, string metodo)
        {
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            var content = new FormUrlEncodedContent(queryParams);
            var res = ConexionHelper.Cliente.PostAsync(Url + metodo, content).Result
                .Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<List<T>>(res);
        }

        public static bool Post(Dictionary<string, string> param, string metodo)
        {
            try
            {
                ConexionHelper.Cliente.BaseAddress = new Uri(Url);
                var content = new FormUrlEncodedContent(param);
                var res = ConexionHelper.Cliente.PostAsync(Url + metodo, content).Result;
                if (res.StatusCode == System.Net.HttpStatusCode.Created)
                    return true;
                else
                    return false;
                //return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Put(Dictionary<string, string> param, string metodo)
        {
            try
            {
                ConexionHelper.Cliente.BaseAddress = new Uri(Url);
                var content = new FormUrlEncodedContent(param);
                var res = ConexionHelper.Cliente.PutAsync(Url + metodo, content).Result;
                if (res.StatusCode == System.Net.HttpStatusCode.Created)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool Delete(Dictionary<string, string> param, string metodo)
        {

            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            var content = new FormUrlEncodedContent(param);
            var res = ConexionHelper.Cliente.DeleteAsync(Url + metodo).Result;
            if (res.StatusCode == System.Net.HttpStatusCode.NoContent)
                return true;
            else
                return false;

        }
    }
}
