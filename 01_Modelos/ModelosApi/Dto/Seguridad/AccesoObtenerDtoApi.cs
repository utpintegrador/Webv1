namespace ModelosApi.Dto.Seguridad
{
    public class AccesoObtenerDtoApi
    {
        public int Item { get; set; }
        public int IdAcceso { get; set; }
        public string Titulo { get; set; }
		public string UrlAcceso { get; set; }
        public string Icono { get; set; }
        public int? IdAccesoPadre { get; set; }
    }
}
