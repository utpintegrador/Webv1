using ModelosApi.Request.Comun;

namespace Entidad.Request.Maestro
{
    public class RequestTipoUsuarioObtenerDtoApi : FiltroPaginacionApi
    {
        public string Buscar { get; set; }
    }
}
