using Entidad.Dto.Comun;

namespace Entidad.Dto.Maestro
{
    public class MonedaObtenerFiltroDto: DataTableNet
    {
        public string Buscar { get; set; }
        public MonedaObtenerFiltroDto()
        {
            Buscar = string.Empty;
        }
    }
}
