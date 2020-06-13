using Entidad.Dto.Comun;
using System;

namespace Entidad.Dto.Maestro
{
    public class ClienteObtenerFiltroDto: DataTableNet
    {
        public String Buscar { get; set; }
        public Int32 IdEstado { get; set; }
        public Int32 IdUsuario { get; set; }
    }
}
