using Entidad.Dto.Transaccion;
using ModelosApi.Response.Comun;
using System.Collections.Generic;

namespace Entidad.Response.Transaccion
{
    public class ResponsePedidoDetalleObtenerPorIdPedidoDtoApi
    {
        public int ProcesadoOk { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
        public List<PedidoDetalleObtenerPorIdPedidoDtoApi> Cuerpo { get; set; }
        public int CantidadTotalRegistros { get; set; }
        public ResponsePedidoDetalleObtenerPorIdPedidoDtoApi()
        {
            ProcesadoOk = 0;
            ListaError = new List<ErrorDtoApi>();
            CantidadTotalRegistros = 0;
        }
    }
}
