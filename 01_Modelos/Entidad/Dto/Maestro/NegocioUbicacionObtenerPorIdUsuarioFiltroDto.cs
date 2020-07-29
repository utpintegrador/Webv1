using Entidad.Dto.Comun;

namespace Entidad.Dto.Maestro
{
    public class NegocioUbicacionObtenerPorIdUsuarioFiltroDto: DataTableNet
    {
        public long IdUsuario { get; set; }
        public long IdNegocio { get; set; }
        public string Buscar { get; set; }
        public NegocioUbicacionObtenerPorIdUsuarioFiltroDto()
        {
            IdNegocio = 0;
            Buscar = string.Empty;
        }
    }
}
