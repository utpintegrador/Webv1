using System.Collections.Generic;

namespace Entidad.Dto.Dashboard
{
    public class DashboardCategoriaDto
    {
        public long IdCategoria { get; set; }
        public string DescripcionCategoria { get; set; }
        public List<DashboardCategoriaDetalleDto> ListaValores { get; set; }
        public DashboardCategoriaDto()
        {
            ListaValores = new List<DashboardCategoriaDetalleDto>();
        }
    }
}
