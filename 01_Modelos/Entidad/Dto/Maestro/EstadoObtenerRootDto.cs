using Entidad.Dto.Global;
using System.Collections.Generic;

namespace Entidad.Dto.Maestro
{
    public class EstadoObtenerRootDto
    {
        public int ProcesadoOk { get; set; }
        public List<EstadoObtenerDto> Cuerpo { get; set; }
        public List<ErrorDto> ListaError { get; set; }
        public EstadoObtenerRootDto()
        {
            ListaError = new List<ErrorDto>();
        }
    }
}
