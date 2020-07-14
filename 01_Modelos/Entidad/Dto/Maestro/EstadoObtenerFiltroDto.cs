using Entidad.Dto.Comun;

namespace Entidad.Dto.Maestro
{
    public class EstadoObtenerFiltroDto: DataTableNet
    {
        public string Buscar { get; set; }
        public int IdTipoEstado { get; set; }
        public EstadoObtenerFiltroDto()
        {
            Buscar = string.Empty;
            IdTipoEstado = 0;
        }
    }
}
