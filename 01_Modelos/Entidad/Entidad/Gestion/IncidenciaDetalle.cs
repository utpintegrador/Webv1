using System;

namespace Entidad.Entidad.Gestion
{
    public class IncidenciaDetalle
    {
        public Int32 IdIncidenciaDetalle { get; set; }
        public Int32 IdIncidencia { get; set; }
        public Int32 IdUsuario { get; set; }
        public Int32 IdArea { get; set; }
        public String Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
