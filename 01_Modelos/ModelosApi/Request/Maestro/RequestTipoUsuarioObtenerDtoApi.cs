using ModelosApi.Request.Comun;

namespace ModelosApi.Request.Maestro
{
    public class RequestTipoUsuarioObtenerDtoApi : FiltroPaginacionApi
    {
        public string Buscar { get; set; }
    }
}
