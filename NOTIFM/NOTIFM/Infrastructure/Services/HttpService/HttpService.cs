using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NOTIFM.Infrastructure.Services.RestService
{
    public class HttpService : IHttpService
    {
        static HttpClient _client;

        public HttpService()
        {
            _client = new HttpClient();
        }

        public async Task<M> PostHttpJsonRequest<R, M>(string apiUrl, R reqModel)
        {
            M model = default(M);

            if (_client.BaseAddress == null)
            {
                _client.BaseAddress = new Uri(apiUrl);
            }
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await _client.PostAsJsonAsync(apiUrl, reqModel);
            if (response.IsSuccessStatusCode)
            {
                var res = response.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<M>(res);
            }
            return model;
        }
    }
}
