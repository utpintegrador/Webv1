using ModelosApi.Response.Comun;
using System.Collections.Generic;

namespace ModelosApi.Response.Transaccion
{
    public class ResponsePedidoDetalleRegistrarDtoApi
    {
        public int ProcesadoOk { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
        public int StatusCode { get; set; } = 200;
        public ResponsePedidoDetalleRegistrarDtoApi()
        {
            ProcesadoOk = 0;
            ListaError = new List<ErrorDtoApi>();
        }
    }
}
