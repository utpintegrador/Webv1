using Entidad.Dto.Comun;

namespace Entidad.Dto.Transaccion
{
    public class CompraObtenerPorIdUsuarioFiltroDto: DataTableNet
    {
        public long IdUsuario { get; set; }
        public long IdNegocioComprador { get; set; }
        public string Buscar { get; set; }
        public int IdEstado { get; set; }
        public int IdMoneda { get; set; }
        public string FechaDesde { get; set; }
        public string FechaHasta { get; set; }
        public CompraObtenerPorIdUsuarioFiltroDto()
        {
            Buscar = string.Empty;
        }
    }
}
