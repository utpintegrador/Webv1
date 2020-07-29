using System.Collections.Generic;

namespace ModelosApi.Request.Transaccion
{
    public class RequestPedidoDetalleRootRegistrarDtoApi
    {
        public List<RequestPedidoDetalleRegistrarDtoApi> ListaPedidoDetalle { get; set; }
        public RequestPedidoDetalleRootRegistrarDtoApi()
        {
            ListaPedidoDetalle = new List<RequestPedidoDetalleRegistrarDtoApi>();
        }
    }
}
