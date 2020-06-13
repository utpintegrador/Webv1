using System;

namespace Entidad.Dto.Gestion
{
    public class IncidenciaModificarEstadoDto
    {
        public Int32 IdIncidencia { get; set; }
        public Int32 IdEstado { get; set; }
        public Int32 IdUsuario { get; set; }
        public Boolean Finalizado { get; set; }
    }
}
