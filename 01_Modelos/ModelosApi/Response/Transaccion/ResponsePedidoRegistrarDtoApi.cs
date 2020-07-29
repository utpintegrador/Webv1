using ModelosApi.Response.Comun;
using System.Collections.Generic;

namespace ModelosApi.Response.Transaccion
{
    public class ResponsePedidoRegistrarDtoApi
    {
        public int ProcesadoOk { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
        public long IdGenerado { get; set; }
        public int StatusCode { get; set; } = 200;
        public ResponsePedidoRegistrarDtoApi()
        {
            ProcesadoOk = 0;
            ListaError = new List<ErrorDtoApi>();
            IdGenerado = 0;
        }
    }
}
