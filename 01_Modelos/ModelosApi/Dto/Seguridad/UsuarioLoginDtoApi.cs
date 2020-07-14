namespace ModelosApi.Dto.Seguridad
{
    public class UsuarioLoginDtoApi
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CorreoElectronico { get; set; }
        public string UrlImagen { get; set; }
    }
}
