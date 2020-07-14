using ModelosApi.Request.Comun;
using System.ComponentModel.DataAnnotations;

namespace Entidad.Request.Maestro
{
    public class RequestNegocioObtenerCercanosDtoApi : FiltroPaginacionApi
    {
        public string Buscar { get; set; }
        public int CantidadKilometros { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "{0}: debe tener un valor mayor o igual a {1}")]
        public long IdUsuario { get; set; }
    }
}
