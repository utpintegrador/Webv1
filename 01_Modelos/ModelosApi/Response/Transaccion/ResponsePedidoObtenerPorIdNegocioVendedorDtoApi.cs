using ModelosApi.Dto.Transaccion;
using ModelosApi.Response.Comun;
using System.Collections.Generic;

namespace ModelosApi.Response.Transaccion
{
    public class ResponsePedidoObtenerPorIdNegocioVendedorDtoApi
    {
        public int ProcesadoOk { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
        public List<PedidoObtenerPorIdNegocioVendedorDtoApi> Cuerpo { get; set; }
        public long CantidadTotalRegistros { get; set; }
        public int StatusCode { get; set; } = 200;
        public ResponsePedidoObtenerPorIdNegocioVendedorDtoApi()
        {
            ProcesadoOk = 0;
            ListaError = new List<ErrorDtoApi>();
            CantidadTotalRegistros = 0;
        }
    }
}
