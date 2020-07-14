using ModelosApi.Request.Comun;

namespace Entidad.Request.Maestro
{
    public class RequestCategoriaObtenerDtoApi : FiltroPaginacionApi
    {
        public string Buscar { get; set; }
        public int IdEstado { get; set; }
    }
}
