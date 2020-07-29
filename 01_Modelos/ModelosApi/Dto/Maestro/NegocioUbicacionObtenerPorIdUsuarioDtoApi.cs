namespace ModelosApi.Dto.Maestro
{
    public class NegocioUbicacionObtenerPorIdUsuarioDtoApi
    {
        public int Item { get; set; }
        public long IdNegocioUbicacion { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public bool Predeterminado { get; set; }
        public string NombreNegocio { get; set; }
    }
}
