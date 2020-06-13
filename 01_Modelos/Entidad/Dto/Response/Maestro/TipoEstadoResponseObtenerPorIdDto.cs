using Entidad.Dto.Global;
using Entidad.Entidad.Maestro;
using System.Collections.Generic;
using System.ComponentModel;

namespace Entidad.Dto.Response.Maestro
{
    public class TipoEstadoResponseObtenerPorIdDto
    {
        public bool ProcesadoOk { get; set; }
        [DisplayName("ListaErrores")]
        public List<ErrorDto> ListaError { get; set; }
        public TipoEstado Cuerpo { get; set; }
        public TipoEstadoResponseObtenerPorIdDto()
        {
            ProcesadoOk = false;
            ListaError = new List<ErrorDto>();
        }
    }
}
