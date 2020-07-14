using Entidad.Dto.Comun;

namespace Entidad.Dto.Maestro
{
    public class TipoBusquedaObtenerFiltroDto: DataTableNet
    {
        public string Buscar { get; set; }
        public TipoBusquedaObtenerFiltroDto()
        {
            Buscar = string.Empty;
        }
    }
}
