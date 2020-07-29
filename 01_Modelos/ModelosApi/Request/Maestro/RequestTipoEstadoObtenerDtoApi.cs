using ModelosApi.Request.Comun;

namespace ModelosApi.Request.Maestro
{
    public class RequestTipoEstadoObtenerDtoApi : FiltroPaginacionApi
    {
        public string Buscar { get; set; }
    }
}
