using Entidad.Dto.Global;
using Entidad.Entidad.Seguridad;
using System.Collections.Generic;
using System.ComponentModel;

namespace Entidad.Dto.Response.Seguridad
{
    public class UsuarioResponseRegistrarDto
    {
        public bool ProcesadoOk { get; set; }
        [DisplayName("ListaErrores")]
        public List<ErrorDto> ListaError { get; set; }
        public long IdGenerado { get; set; }
        public UsuarioResponseRegistrarDto()
        {
            ProcesadoOk = false;
            ListaError = new List<ErrorDto>();
            IdGenerado = 0;
        }
    }
}
