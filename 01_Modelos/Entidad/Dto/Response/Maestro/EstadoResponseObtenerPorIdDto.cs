using Entidad.Dto.Global;
using Entidad.Entidad.Maestro;
using System.Collections.Generic;
using System.ComponentModel;

namespace Entidad.Dto.Response.Maestro
{
    public class EstadoResponseObtenerPorIdDto
    {
        public bool ProcesadoOk { get; set; }
        [DisplayName("ListaErrores")]
        public List<ErrorDto> ListaError { get; set; }
        public Estado Cuerpo { get; set; }
        public EstadoResponseObtenerPorIdDto()
        {
            ProcesadoOk = false;
            ListaError = new List<ErrorDto>();
        }
    }
}
