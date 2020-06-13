using Entidad.Dto.Global;
using System.Collections.Generic;
using System.ComponentModel;

namespace Entidad.Dto.Response.Perfil
{
    public class PerfilResponseObtenerPorIdDto
    {
        public bool ProcesadoOk { get; set; }
        [DisplayName("ListaErrores")]
        public List<ErrorDto> ListaError { get; set; }
        public Entidad.Perfil.Perfil Cuerpo { get; set; }
        public PerfilResponseObtenerPorIdDto()
        {
            ProcesadoOk = false;
            ListaError = new List<ErrorDto>();
        }
    }
}
