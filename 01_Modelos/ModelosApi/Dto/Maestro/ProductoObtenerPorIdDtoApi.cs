namespace ModelosApi.Dto.Maestro
{
    public class ProductoObtenerPorIdDtoApi
    {

        public long IdProducto { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionExtendida { get; set; }
        public decimal Precio { get; set; }
        public int IdMoneda { get; set; }
        public int IdCategoria { get; set; }
        public long IdNegocio { get; set; }
        public int IdEstado { get; set; }

    }
}
