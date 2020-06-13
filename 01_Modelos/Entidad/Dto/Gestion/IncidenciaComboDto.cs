using System;

namespace Entidad.Dto.Gestion
{
    public class IncidenciaComboDto
    {
        public Int32 IdIncidencia { get; set; }
        public Int32 IdCliente { get; set; }
        public string Asunto { get; set; }
        public Int32 IdTipoIncidencia { get; set; }
        public string DescripcionEstado { get; set; }
        public Int32 IdUsuarioRegistra { get; set; }
    }
}
