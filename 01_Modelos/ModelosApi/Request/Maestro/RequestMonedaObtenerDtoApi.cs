using ModelosApi.Request.Comun;

namespace ModelosApi.Request.Maestro
{
    public class RequestMonedaObtenerDtoApi : FiltroPaginacionApi
    {
        public string Buscar { get; set; }
    }
}
