using ModelosApi.Request.Comun;
using System.ComponentModel.DataAnnotations;

namespace ModelosApi.Request.Maestro
{
    public class RequestProductoObtenerPorIdUsuarioDtoApi : FiltroPaginacionApi
    {
        [Range(1, long.MaxValue, ErrorMessage = "{0}: debe tener un valor mayor o igual a {1}")]
        public long IdUsuario { get; set; }
        public long IdNegocio { get; set; }
        public string Buscar { get; set; }
        public int IdEstado { get; set; }
        public int IdMoneda { get; set; }
        public int IdCategoria { get; set; }

        public RequestProductoObtenerPorIdUsuarioDtoApi()
        {
            IdEstado = 1;
            Buscar = string.Empty;
        }
    }
}
