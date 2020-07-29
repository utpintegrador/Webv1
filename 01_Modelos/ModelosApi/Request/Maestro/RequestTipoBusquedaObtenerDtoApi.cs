using ModelosApi.Request.Comun;

namespace ModelosApi.Request.Maestro
{
    public class RequestTipoBusquedaObtenerDtoApi : FiltroPaginacionApi
    {
        public string Buscar { get; set; }
    }
}
