using ModelosApi.Response.Comun;
using System.Collections.Generic;

namespace ModelosApi.Response.Seguridad
{
    public class ResponseAccesoEliminarDtoApi
    {
        public int ProcesadoOk { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
        public int StatusCode { get; set; } = 200;
        public ResponseAccesoEliminarDtoApi()
        {
            ProcesadoOk = 0;
            ListaError = new List<ErrorDtoApi>();
        }
    }
}
