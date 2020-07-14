namespace ModelosApi.Dto.Seguridad
{
    public class UsuarioObtenerDtoApi
    {
        public int Item { get; set; }
        public long IdUsuario { get; set; }
        public string CorreoElectronico { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DescripcionEstado { get; set; }
        public string DescripcionTipoUsuario { get; set; }
        public string FechaRegistro { get; set; }
        public string FechaActualizacion { get; set; }
    }
}
