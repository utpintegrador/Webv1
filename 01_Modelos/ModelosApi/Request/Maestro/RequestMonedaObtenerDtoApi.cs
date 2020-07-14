using ModelosApi.Request.Comun;

namespace Entidad.Request.Maestro
{
    public class RequestMonedaObtenerDtoApi : FiltroPaginacionApi
    {
        public string Buscar { get; set; }
    }
}
