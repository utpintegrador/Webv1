using System.Collections.Generic;

namespace Entidad.Dto.Dashboard
{
    public class DashboardProductoDto
    {
        //public int Orden { get; set; }
        //public string Periodo { get; set; }
        public long IdProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public List<DashboardProductoDetalleDto> ListaValores { get; set; }
        public DashboardProductoDto()
        {
            ListaValores = new List<DashboardProductoDetalleDto>();
        }
    }
}
