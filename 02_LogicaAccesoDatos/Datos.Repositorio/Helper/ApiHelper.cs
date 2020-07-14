using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Datos.Repositorio.Helper
{
    public static class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }

        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            //ApiClient.BaseAddress = new Uri("http://localhost:6935/api/");
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        //public HttpClient Initial()
        //{
        //    var client = new HttpClient();
        //    //client.BaseAddress = new Uri("http://api-find.control-zeta.net/api/");
        //    client.BaseAddress = new Uri("http://localhost:6935/api/");
        //    //http://localhost:6935/swagger/index.html
        //    return client;
        //}
    }
}
