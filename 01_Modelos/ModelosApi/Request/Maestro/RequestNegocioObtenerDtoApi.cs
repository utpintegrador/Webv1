using ModelosApi.Request.Comun;

namespace Entidad.Request.Maestro
{
    public class RequestNegocioObtenerDtoApi : FiltroPaginacionApi
    {
        public string Buscar { get; set; }
        public int IdEstado { get; set; }
        public long IdUsuario { get; set; }
    }
}
