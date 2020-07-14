using Entidad.Dto.Comun;

namespace Entidad.Dto.Maestro
{
    public class TipoDescuentoObtenerFiltroDto: DataTableNet
    {
        public string Buscar { get; set; }
        public TipoDescuentoObtenerFiltroDto()
        {
            Buscar = string.Empty;
        }
    }
}
