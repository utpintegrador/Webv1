using ModelosApi.Request.Comun;

namespace ModelosApi.Request.Seguridad
{
    public class RequestUsuarioObtenerDtoApi : FiltroPaginacionApi
    {
        public string Buscar { get; set; }
        public int IdEstado { get; set; }
        public int IdTipoUsuario { get; set; }

        public RequestUsuarioObtenerDtoApi()
        {
            Buscar = string.Empty;
            IdEstado = 0;
            IdTipoUsuario = 0;
        }
    }
}
