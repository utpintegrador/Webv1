using System;

namespace Entidad.Dto.Maestro
{
    public class ClienteObtenerDto
    {
        public Int32 Item { get; set; }
        public String IdCliente { get; set; }
        public String NumeroDocumento { get; set; }
        public String RazonSocial { get; set; }
        public string DescripcionEstado { get; set; }
        public Int32 TotalItems { get; set; }
    }
}
