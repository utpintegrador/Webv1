﻿using System.ComponentModel.DataAnnotations;

namespace ModelosApi.Request.Transaccion
{
    public class RequestPedidoDetalleModificarDtoApi
    {
        [Range(1, long.MaxValue, ErrorMessage = "{0}: parametro es requerido")]
        public long IdPedidoDetalle { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "{0}: parametro es requerido")]
        public long IdPedido { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "{0}: parametro es requerido")]
        public long IdProducto { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "{0}: parametro es requerido")]
        public decimal Cantidad { get; set; }

        [Range(0.001, double.MaxValue, ErrorMessage = "{0}: parametro es requerido")]
        public decimal PrecioUnitario { get; set; }
    }
}
