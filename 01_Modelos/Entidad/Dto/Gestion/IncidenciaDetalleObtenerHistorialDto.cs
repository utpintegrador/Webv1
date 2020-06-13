using System;

namespace Entidad.Dto.Gestion
{
    public class IncidenciaDetalleObtenerHistorialDto
    {
        public Int32 IdIncidenciaDetalle { get; set; }
        public String NumeroDocumento { get; set; }
        public String RazonSocial { get; set; }
        public String Titulo { get; set; }
        public String UsuarioInicial { get; set; }
        public String FechaRegistroInicial { get; set; }
        public Int32 DiferenciaHorasCabecera { get; set; }
        public Int32 DiferenciaHorasDetalle { get; set; }
        public String UsuarioDetalle { get; set; }
        public String FechaRegistroDetalle { get; set; }
        public String Descripcion { get; set; }
        public String DescripcionArea { get; set; }
        public String DescripcionEstado { get; set; }
        public Int32 IdArea { get; set; }
    }
}
