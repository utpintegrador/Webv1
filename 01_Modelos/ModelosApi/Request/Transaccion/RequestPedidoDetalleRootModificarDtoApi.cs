﻿using System.Collections.Generic;

namespace ModelosApi.Request.Transaccion
{
    public class RequestPedidoDetalleRootModificarDtoApi
    {
        public List<RequestPedidoDetalleModificarDtoApi> ListaPedidoDetalle { get; set; }
        public RequestPedidoDetalleRootModificarDtoApi()
        {
            ListaPedidoDetalle = new List<RequestPedidoDetalleModificarDtoApi>();
        }
    }
}
