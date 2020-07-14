using Entidad.Dto.Comun;

namespace Entidad.Dto.Maestro
{
    public class CategoriaObtenerFiltroDto: DataTableNet
    {
        public int IdEstado { get; set; }
        public string Buscar { get; set; }
        public CategoriaObtenerFiltroDto()
        {
            Buscar = string.Empty;
            IdEstado = 0;
        }
    }
}
