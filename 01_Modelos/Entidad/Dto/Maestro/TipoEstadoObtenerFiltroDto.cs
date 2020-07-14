using Entidad.Dto.Comun;
using System;

namespace Entidad.Dto.Maestro
{
    public class TipoEstadoObtenerFiltroDto : DataTableNet
    {
        public String Buscar { get; set; }
        public TipoEstadoObtenerFiltroDto()
        {
            Buscar = string.Empty;
        }
    }
}
