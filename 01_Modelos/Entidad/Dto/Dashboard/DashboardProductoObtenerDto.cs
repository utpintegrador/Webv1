using System;

namespace Entidad.Dto.Dashboard
{
    public class DashboardProductoObtenerDto
    {
        public DateTime Periodo { get; set; }
        public long IdProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public long Cantidad { get; set; }
    }
}
