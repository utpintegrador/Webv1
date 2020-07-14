using ModelosApi.Request.Comun;

namespace Entidad.Request.Maestro
{
    public class RequestTipoDocumentoIdentificacionObtenerDtoApi : FiltroPaginacionApi
    {
        public string Buscar { get; set; }
    }
}
