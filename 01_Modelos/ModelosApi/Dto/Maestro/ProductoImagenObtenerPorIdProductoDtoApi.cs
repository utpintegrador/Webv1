namespace ModelosApi.Dto.Maestro
{
    public class ProductoImagenObtenerPorIdProductoDtoApi
    {
        public int Item { get; set; }
        public long IdProductoImagen { get; set; }
        public string UrlImagen { get; set; }
        public bool Predeterminado { get; set; }
    }
}
