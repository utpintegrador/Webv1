using System;

namespace Entidad.Dto.Gestion
{
    public class IncidenciaDetalleRegistrarDto
    {
        public Int32 IdIncidencia { get; set; }
        public Int32 IdUsuario { get; set; }
        public Int32 IdArea { get; set; }
        public String Descripcion { get; set; }
    }
}
