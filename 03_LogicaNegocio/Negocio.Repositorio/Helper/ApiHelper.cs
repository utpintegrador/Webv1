using System;
using System.Net.Http;

namespace Negocio.Repositorio.Helper
{
    public class ApiHelper
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://api-find.control-zeta.net/api/");
            return client;
        }
    }
}
