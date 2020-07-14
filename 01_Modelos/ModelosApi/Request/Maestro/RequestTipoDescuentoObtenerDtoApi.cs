using ModelosApi.Request.Comun;

namespace Entidad.Request.Maestro
{
    public class RequestTipoDescuentoObtenerDtoApi : FiltroPaginacionApi
    {
        public string Buscar { get; set; }
    }
}
