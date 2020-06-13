using System;

namespace Entidad.Dto.Seguridad
{
    public class UsuarioTokenDto
    {
        public string Token { get; set; }
        public DateTime Expiracion { get; set; }
    }
}
