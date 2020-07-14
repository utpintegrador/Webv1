using Entidad.Dto.Comun;

namespace Entidad.Dto.Maestro
{
    public class NegocioObtenerCercanosFiltroDto: DataTableNet
    {
        public string Buscar { get; set; }
        public int CantidadKilometros { get; set; }
        public long IdUsuario { get; set; }
        public NegocioObtenerCercanosFiltroDto()
        {
            Buscar = string.Empty;
            CantidadKilometros = 0;
            IdUsuario = 0;
        }
    }
}
