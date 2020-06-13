namespace Entidad.Dto.Maestro
{
    public class ProductoObtenerDto
    {
        public long IdProducto { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionExtendida { get; set; }
        public decimal Precio { get; set; }
        public string UrlImagen { get; set; }
        //public int IdMoneda { get; set; }
        //public int IdCategoria { get; set; }
        //public long IdNegocio { get; set; }
        //public int IdEstado { get; set; }

        public string Moneda { get; set; }
        public string Categoria { get; set; }
        public string Negocio { get; set; }
        public string Estado { get; set; }
    }
}



