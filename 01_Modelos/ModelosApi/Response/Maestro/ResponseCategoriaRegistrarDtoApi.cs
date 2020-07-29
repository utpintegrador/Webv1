using ModelosApi.Response.Comun;
using System.Collections.Generic;

namespace ModelosApi.Response.Maestro
{
    public class ResponseCategoriaRegistrarDtoApi
    {
        public int ProcesadoOk { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
        public int IdGenerado { get; set; }
        public int StatusCode { get; set; } = 200;
        public ResponseCategoriaRegistrarDtoApi()
        {
            ProcesadoOk = 0;
            ListaError = new List<ErrorDtoApi>();
            IdGenerado = 0;
        }
    }
}
