﻿using System.Collections.Generic;

namespace Entidad.Request.Transaccion
{
    public class RequestPedidoDetalleRootEliminarDtoApi
    {
        public List<long> ListaPedidoDetalle { get; set; }
        public RequestPedidoDetalleRootEliminarDtoApi()
        {
            ListaPedidoDetalle = new List<long>();
        }
    }
}