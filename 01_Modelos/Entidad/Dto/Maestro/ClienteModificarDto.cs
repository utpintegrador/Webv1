using System;

namespace Entidad.Dto.Maestro
{
    public class ClienteModificarDto
    {
        public Int32 IdCliente { get; set; }
        public String NumeroDocumento { get; set; }
        public String RazonSocial { get; set; }
        public String Direccion { get; set; }
        public Int32 IdPais { get; set; }
        public Int32 IdUbigeo { get; set; }
        public Int32 IdUsuario { get; set; }
        public Int32 IdEstado { get; set; }
    }
}
