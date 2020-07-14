using ModelosApi.Request.Comun;

namespace ModelosApi.Request.Seguridad
{
    public class RequestRolObtenerDtoApi : FiltroPaginacionApi
    {
        public string Buscar { get; set; }
    }
}
