using ModelosApi.Dto.Transaccion;
using ModelosApi.Response.Comun;
using System.Collections.Generic;

namespace ModelosApi.Response.Transaccion
{
    public class ResponsePedidoObtenerNotaPedidoDtoApi
    {
        public int ProcesadoOk { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
        public PedidoObtenerNotaPedidoDtoApi Cuerpo { get; set; }
        public int StatusCode { get; set; } = 200;
        public ResponsePedidoObtenerNotaPedidoDtoApi()
        {
            ProcesadoOk = 0;
            ListaError = new List<ErrorDtoApi>();
        }
    }
}
