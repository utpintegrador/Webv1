using ModelosApi.Response.Comun;
using System.Collections.Generic;

namespace Entidad.Response.Transaccion
{
    public class ResponsePedidoDetalleModificarDtoApi
    {
        public int ProcesadoOk { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
        public ResponsePedidoDetalleModificarDtoApi()
        {
            ProcesadoOk = 0;
            ListaError = new List<ErrorDtoApi>();
        }
    }
}
