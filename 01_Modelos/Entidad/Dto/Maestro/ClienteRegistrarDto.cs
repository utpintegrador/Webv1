using System;
using System.ComponentModel.DataAnnotations;

namespace Entidad.Dto.Maestro
{
    public class ClienteRegistrarDto
    {
        [Required(ErrorMessage = "El campo es obligatorio")]
        public String NumeroDocumento { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public String RazonSocial { get; set; }
        public String Direccion { get; set; }
        public Int32 IdPais { get; set; }
        public Int32 IdUbigeo { get; set; }
        public Int32 IdUsuario { get; set; }
        public Int32 IdEstado { get; set; }
    }
}
