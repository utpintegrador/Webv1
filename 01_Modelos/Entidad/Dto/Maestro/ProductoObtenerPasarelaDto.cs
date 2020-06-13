namespace Entidad.Dto.Maestro
{
    public class ProductoObtenerPasarelaDto
    {
        public long IdProducto { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionExtendida { get; set; }
        public string SimboloMoneda { get; set; }
        public decimal Precio { get; set; }
        public string NombreNegocio { get; set; }
        public string UrlImagen { get; set; }
        public decimal Cantidad { get; set; }
        public long IdNegocio { get; set; }

    }
}
