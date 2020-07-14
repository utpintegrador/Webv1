using ModelosApi.Request.Comun;

namespace Entidad.Request.Maestro
{
    public class RequestTipoEstadoObtenerDtoApi : FiltroPaginacionApi
    {
        public string Buscar { get; set; }
    }
}
