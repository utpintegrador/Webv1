using System.Collections.Generic;

namespace Entidad.Dto.Dashboard
{
    public class DashboardCategoriaRootDto
    {
        public List<DashboardPeriodoOrdenDto> ListaPeriodo { get; set; }
        public List<DashboardCategoriaDto> ListaCategoria { get; set; }
        public DashboardCategoriaRootDto()
        {
            ListaPeriodo = new List<DashboardPeriodoOrdenDto>();
            ListaCategoria = new List<DashboardCategoriaDto>();
        }
    }
}
