namespace Entidad.Dto.Transaccion
{
    public class CarroItemObtenerDto
    {
        public long IdCarroItem { get; set; }
        public long IdProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public int IdMoneda { get; set; }
        public string DescripcionMoneda { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public string UrlImagen { get; set; }
    }
}
