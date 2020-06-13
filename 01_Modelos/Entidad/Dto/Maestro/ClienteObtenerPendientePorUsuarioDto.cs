using System;

namespace Entidad.Dto.Maestro
{
    public class ClienteObtenerPendientePorUsuarioDto
    {
        public Int32 Item { get; set; }
        public String IdCliente { get; set; }
        public String NumeroDocumento { get; set; }
        public String RazonSocial { get; set; }
        public String Direccion { get; set; }
        public int IdEstado { get; set; }
        public Int32 TotalItems { get; set; }
    }
}
