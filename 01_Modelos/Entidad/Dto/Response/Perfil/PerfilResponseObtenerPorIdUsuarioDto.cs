using Entidad.Dto.Global;
using Entidad.Dto.Perfil;
using System.Collections.Generic;
using System.ComponentModel;

namespace Entidad.Dto.Response.Perfil
{
    public class PerfilResponseObtenerPorIdUsuarioDto
    {
        public bool ProcesadoOk { get; set; }
        [DisplayName("ListaErrores")]
        public List<ErrorDto> ListaError { get; set; }
        public PerfilObtenerDto Cuerpo { get; set; }
        public PerfilResponseObtenerPorIdUsuarioDto()
        {
            ProcesadoOk = false;
            ListaError = new List<ErrorDto>();
        }
    }
}
