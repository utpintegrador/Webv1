using ModelosApi.Request.Comun;
using System.ComponentModel.DataAnnotations;

namespace ModelosApi.Request.Maestro
{
    public class RequestNegocioUbicacionObtenerPorIdUsuarioDtoApi: FiltroPaginacionApi
    {
        [Range(1, long.MaxValue, ErrorMessage = "{0}: debe tener un valor mayor o igual a {1}")]
        public long IdUsuario { get; set; }
        public long IdNegocio { get; set; }
        public string Buscar { get; set; }
        public RequestNegocioUbicacionObtenerPorIdUsuarioDtoApi()
        {
            Buscar = string.Empty;
        }
    }
}
