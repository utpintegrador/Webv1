using Entidad.Dto.Comun;

namespace Entidad.Dto.Maestro
{
    public class CategoriaObtenerFiltroDto: Paginacion
    {
        public long IdEstado { get; set; }
        public string Descripcion { get; set; }
    }
}
