using ModelosApi.Request.Comun;

namespace Entidad.Request.Maestro
{
    public class RequestTipoBusquedaObtenerDtoApi : FiltroPaginacionApi
    {
        public string Buscar { get; set; }
    }
}
