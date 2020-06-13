using System;

namespace Entidad.Dto.Gestion
{
    public class IncidenciaDetalleObtenerDto
    {
        public Int32 Item { get; set; }
        public Int32 IdIncidencia { get; set; }
        public Int32 IdIncidenciaDetalle { get; set; }
        public String UserName { get; set; }
        public String NombreArea { get; set; }
        public String Descripcion { get; set; }
        public String FechaRegistro { get; set; }
        public Int32 TotalItems { get; set; }
    }
}
