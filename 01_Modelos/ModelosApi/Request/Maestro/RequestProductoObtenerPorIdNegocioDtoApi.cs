using ModelosApi.Request.Comun;
using System.ComponentModel.DataAnnotations;

namespace Entidad.Request.Maestro
{
    public class RequestProductoObtenerPorIdNegocioDtoApi : FiltroPaginacionApi
    {
        [Range(1, long.MaxValue, ErrorMessage = "{0}: debe tener un valor mayor o igual a {1}")]
        public long IdNegocio { get; set; }
        public string Buscar { get; set; }
        public int IdEstado { get; set; }
        public int IdMoneda { get; set; }
        public int IdCategoria { get; set; }

        public RequestProductoObtenerPorIdNegocioDtoApi()
        {
            IdEstado = 1;
        }

    }
}
