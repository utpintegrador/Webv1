using ModelosApi.Request.Comun;

namespace ModelosApi.Request.Seguridad
{
    public class RequestAccesoObtenerDtoApi : FiltroPaginacionApi
    {
        public string Buscar { get; set; }
    }
}
