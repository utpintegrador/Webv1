namespace ModelosApi.Dto.Maestro
{
    public class NegocioObtenerDtoApi
    {
        public int Item { get; set; }
        public long IdNegocio { get; set; }
        public string DocumentoIdentificacion { get; set; }
        public string Nombre { get; set; }
        public string Resenia { get; set; }
        public string DescripcionTipoDocumentoIdentificacion { get; set; }
        public string DescripcionEstado { get; set; }
        public string FechaRegistro { get; set; }
        public string CorreoElectronico { get; set; }
        public int CantidadUbicaciones { get; set; }
        public string Telefono { get; set; }

    }
}
