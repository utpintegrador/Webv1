using Entidad.Dto.Comun;

namespace Entidad.Dto.Maestro
{
    public class ProductoObtenerFiltroDto: Paginacion
    {
        public long IdUsuario { get; set; }
        public int IdCategoria { get; set; }
        public string Descripcion { get; set; }
        
    }
}
