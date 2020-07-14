using ModelosApi.Request.Comun;
using System.ComponentModel.DataAnnotations;

namespace Entidad.Request.Maestro
{
    public class RequestProductoImagenObtenerPorIdProductoDtoApi : FiltroPaginacionApi
    {
        [Range(1, long.MaxValue, ErrorMessage = "{0}: debe tener un valor mayor o igual a {1}")]
        public long IdProducto { get; set; }
    }
}
