namespace ModelosApi.Dto.Maestro
{
    public class CategoriaObtenerDtoApi
    {
        public int Item { get; set; }
        public int IdCategoria { get; set; }
        public string Descripcion { get; set; }
        public string UrlImagen { get; set; }
        public string DescripcionEstado { get; set; }
        public string FechaRegistro { get; set; }
        public string FechaActualizacion { get; set; }
    }
}
