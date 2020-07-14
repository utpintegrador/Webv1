using Entidad.Dto.Comun;

namespace Entidad.Dto.Maestro
{
    public class TipoUsuarioObtenerFiltroDto: DataTableNet
    {
        public string Buscar { get; set; }
        public TipoUsuarioObtenerFiltroDto()
        {
            Buscar = string.Empty;
        }
    }
}
