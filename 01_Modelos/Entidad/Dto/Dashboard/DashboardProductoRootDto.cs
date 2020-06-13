using System.Collections.Generic;

namespace Entidad.Dto.Dashboard
{
    public class DashboardProductoRootDto
    {
        public List<DashboardPeriodoOrdenDto> ListaPeriodo { get; set; }
        public List<DashboardProductoDto> ListaProducto { get; set; }
        public DashboardProductoRootDto()
        {
            ListaPeriodo = new List<DashboardPeriodoOrdenDto>();
            ListaProducto = new List<DashboardProductoDto>();
        }
    }
}
