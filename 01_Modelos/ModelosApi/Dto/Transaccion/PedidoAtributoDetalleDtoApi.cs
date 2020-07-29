namespace ModelosApi.Dto.Transaccion
{
    public class PedidoAtributoDetalleDtoApi
    {
        public long? IdPedidoDetalle { get; set; }
        public decimal? Cantidad { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public decimal SubTotalPorItem { get; set; }
        public string DescripcionProducto { get; set; }
        public string UrlImagenProducto { get; set; }
    }
}
