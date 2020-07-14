using ModelosApi.Request.Comun;

namespace Entidad.Request.Maestro
{
    public class RequestEstadoObtenerDtoApi : FiltroPaginacionApi
    {
        public string Buscar { get; set; }
        public int IdTipoEstado { get; set; }
    }
}
