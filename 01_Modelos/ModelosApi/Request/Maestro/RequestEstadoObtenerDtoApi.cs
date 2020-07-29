using ModelosApi.Request.Comun;

namespace ModelosApi.Request.Maestro
{
    public class RequestEstadoObtenerDtoApi : FiltroPaginacionApi
    {
        public string Buscar { get; set; }
        public int IdTipoEstado { get; set; }
    }
}
