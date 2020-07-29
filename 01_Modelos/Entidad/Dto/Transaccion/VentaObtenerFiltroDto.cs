using Entidad.Dto.Comun;

namespace Entidad.Dto.Transaccion
{
    public class VentaObtenerFiltroDto : DataTableNet
    {
        public long IdNegocioVendedor { get; set; }
        public string Buscar { get; set; }
        public int IdEstado { get; set; }
        public int IdMoneda { get; set; }
        public VentaObtenerFiltroDto()
        {
            Buscar = string.Empty;
        }
    }
}
