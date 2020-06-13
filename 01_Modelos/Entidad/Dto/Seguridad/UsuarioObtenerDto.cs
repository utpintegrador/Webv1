using System;

namespace Entidad.Dto.Seguridad
{
    public class UsuarioObtenerDto
    {
        public Int32 Item { get; set; }
        public Int32 IdUsuario { get; set; }
        public String UserName { get; set; }
        public String Contrasenia { get; set; }
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        public Int32 IdEstado { get; set; }
        public Int32 TotalItems { get; set; }
    }
}
