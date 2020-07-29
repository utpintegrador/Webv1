namespace ModelosApi.Dto.Transaccion
{
    public class PedidoDetalleObtenerPorIdPedidoDtoApi
    {
        public int Item { get; set; }
        public long IdPedidoDetalle { get; set; }
        public string DescripcionProducto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
