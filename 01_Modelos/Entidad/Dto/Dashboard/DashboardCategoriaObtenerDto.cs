using System;

namespace Entidad.Dto.Dashboard
{
    public class DashboardCategoriaObtenerDto
    {
        public DateTime Periodo { get; set; }
        public int IdCategoria { get; set; }
        public string DescripcionCategoria { get; set; }
        public long Cantidad { get; set; }
    }
}
