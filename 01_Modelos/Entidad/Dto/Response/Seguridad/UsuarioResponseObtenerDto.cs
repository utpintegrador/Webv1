using Entidad.Dto.Global;
using Entidad.Dto.Seguridad;
using System.Collections.Generic;
using System.ComponentModel;

namespace Entidad.Dto.Response.Seguridad
{
    public class UsuarioResponseObtenerDto
    {
        public bool ProcesadoOk { get; set; }
        [DisplayName("ListaErrores")]
        public List<ErrorDto> ListaError { get; set; }
        public List<UsuarioObtenerDto> Cuerpo { get; set; }
        public UsuarioResponseObtenerDto()
        {
            ProcesadoOk = false;
            ListaError = new List<ErrorDto>();
        }
    }
}
