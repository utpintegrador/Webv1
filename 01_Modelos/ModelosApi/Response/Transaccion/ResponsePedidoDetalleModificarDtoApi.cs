using ModelosApi.Response.Comun;
using System.Collections.Generic;

namespace ModelosApi.Response.Transaccion
{
    public class ResponsePedidoDetalleModificarDtoApi
    {
        public int ProcesadoOk { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
        public int StatusCode { get; set; } = 200;
        public ResponsePedidoDetalleModificarDtoApi()
        {
            ProcesadoOk = 0;
            ListaError = new List<ErrorDtoApi>();
        }
    }
}
