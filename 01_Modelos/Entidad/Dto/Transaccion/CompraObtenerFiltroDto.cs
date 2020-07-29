using Entidad.Dto.Comun;

namespace Entidad.Dto.Transaccion
{
    public class CompraObtenerFiltroDto: DataTableNet
    {
        public long IdNegocioComprador { get; set; }
        public string Buscar { get; set; }
        public int IdEstado { get; set; }
        public int IdMoneda { get; set; }
        public CompraObtenerFiltroDto()
        {
            Buscar = string.Empty;
        }
    }
}
