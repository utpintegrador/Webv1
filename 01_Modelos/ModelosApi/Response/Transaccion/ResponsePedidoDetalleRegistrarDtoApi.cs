using ModelosApi.Response.Comun;
using System.Collections.Generic;

namespace Entidad.Response.Transaccion
{
    public class ResponsePedidoDetalleRegistrarDtoApi
    {
        public int ProcesadoOk { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
        public ResponsePedidoDetalleRegistrarDtoApi()
        {
            ProcesadoOk = 0;
            ListaError = new List<ErrorDtoApi>();
        }
    }
}
