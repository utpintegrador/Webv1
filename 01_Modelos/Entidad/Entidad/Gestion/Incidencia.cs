using System;
using System.Collections.Generic;
using System.Text;

namespace Entidad.Entidad.Gestion
{
    public class Incidencia
    {
        public Int32 IdIncidencia { get; set; }
        public Int32 IdCliente { get; set; }
        public String Asunto { get; set; }
        public Int32 IdTipoIncidencia { get; set; }
        public Int32 IdPrioridad { get; set; }
        public Int32 IdEstado { get; set; }
        public Int32? IdUsuarioRegistra { get; set; }
        public DateTime FechaRegistro { get; set; }
        public Int32? IdUsuarioFinaliza { get; set; }
        public DateTime? FechaFinalizacion { get; set; }

        public List<IncidenciaDetalle> ListaDetalle { get; set; }

        public Incidencia()
        {
            ListaDetalle = new List<IncidenciaDetalle>();
        }
    }
}
