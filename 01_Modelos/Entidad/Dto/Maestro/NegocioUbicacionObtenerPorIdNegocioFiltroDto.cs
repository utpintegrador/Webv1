using Entidad.Dto.Comun;

namespace Entidad.Dto.Maestro
{
    public class NegocioUbicacionObtenerPorIdNegocioFiltroDto: DataTableNet
    {
        public long IdNegocio { get; set; }
        public string Buscar { get; set; }
        public NegocioUbicacionObtenerPorIdNegocioFiltroDto()
        {
            IdNegocio = 0;
            Buscar = string.Empty;
        }
    }
}
