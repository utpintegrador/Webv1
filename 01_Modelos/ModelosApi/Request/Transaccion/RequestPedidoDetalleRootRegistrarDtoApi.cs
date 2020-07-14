using System.Collections.Generic;

namespace Entidad.Request.Transaccion
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
