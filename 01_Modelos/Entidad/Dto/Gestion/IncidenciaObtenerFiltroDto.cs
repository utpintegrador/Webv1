using Entidad.Dto.Comun;
using System;

namespace Entidad.Dto.Gestion
{
    public class IncidenciaObtenerFiltroDto: DataTableNet
    {
        public Int32 IdIncidencia { get; set; }
        public Int32 IdIncidenciaDetalle { get; set; }
        public Int32 IdCliente { get; set; }
        public String Asunto { get; set; }
        public Int32 IdTipoIncidencia { get; set; }
        public Int32 IdPrioridad { get; set; }
        public Int32 IdEstado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public Int32 IdUsuario { get; set; }
        public Boolean Finalizado { get; set; }
        public IncidenciaObtenerFiltroDto()
        {
            Finalizado = false;
        }
    }
}
