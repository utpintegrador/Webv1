using Entidad.Dto.Global;
using Entidad.Dto.Maestro;
using Entidad.Entidad.Maestro;
using System.Collections.Generic;
using System.ComponentModel;

namespace Entidad.Dto.Response.Maestro
{
    public class TipoEstadoResponseRegistrarDto
    {
        public bool ProcesadoOk { get; set; }
        [DisplayName("ListaErrores")]
        public List<ErrorDto> ListaError { get; set; }
        public int IdGenerado { get; set; }
        public TipoEstadoResponseRegistrarDto()
        {
            ProcesadoOk = false;
            ListaError = new List<ErrorDto>();
            IdGenerado = 0;
        }
    }
}
