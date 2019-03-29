using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Barrios.Fornecedores.Communication
{
    public class RestServiceBase
    {
        private const string MEDIA_TYPE = "application/json";

        public RestServiceBase() { }

        public async Task<T> GetAsync<T>(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                string content = await response.Content.ReadAsStringAsync();
                return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(content));
            }
        }
        public async Task<TResult> PostAsync<T, TResult>(string url, T entrada, string jwt)
        {
            var serializeObject = JsonConvert.SerializeObject(entrada);
            return await Task.Factory.StartNew(() => Post<T, TResult>(url, entrada, serializeObject,jwt));
        }

        public TResult Post<T, TResult>(string url, T entrada, string serializeObject, string jwt)
        {
            var content = new StringContent(serializeObject, Encoding.UTF8, MEDIA_TYPE);
            using (var httpClient = new HttpClient())
            {
                if(!string.IsNullOrEmpty(jwt))
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);

                var response = httpClient.PostAsync(url, content).Result;

                var httpStatusCodeRegex = "^(200|201|202|400)$";
                if (Regex.IsMatch(((int)response.StatusCode).ToString(), httpStatusCodeRegex))
                {
                    if (response.Content != null)
                    {
                        string responseContent = response.Content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<TResult>(responseContent);
                    }

                    return default(TResult);
                }
                throw new Exception(response.Content.ToString());
            }
        }
    }
}
