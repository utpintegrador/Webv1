using System;

namespace Entidad.Dto.Maestro
{
    public class TipoEstadoObtenerDto
    {
        public Int32 Item { get; set; }
        public Int32 IdTipoEstado { get; set; }
        public String Nombre { get; set; }
        public String Observacion { get; set; }
        public Int32 TotalItems { get; set; }
    }
}
