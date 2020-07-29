namespace ModelosApi.Dto.Maestro
{
    public class ProductoDescuentoObtenerPorIdProductoDtoApi
    {
        public int Item { get; set; }
        public long IdProductoDescuento { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string DescripcionTipoDescuento { get; set; }
        public decimal Valor { get; set; }
        public string DescripcionEstado { get; set; }
    }
}
