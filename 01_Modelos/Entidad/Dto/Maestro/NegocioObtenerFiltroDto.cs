using Entidad.Dto.Comun;

namespace Entidad.Dto.Maestro
{
    public class NegocioObtenerFiltroDto: DataTableNet
    {
        public string Buscar { get; set; }
        public int IdEstado { get; set; }
        public long IdUsuario { get; set; }
        public NegocioObtenerFiltroDto()
        {
            Buscar = string.Empty;
            IdEstado = 0;
            IdUsuario = 0;
        }
    }
}
