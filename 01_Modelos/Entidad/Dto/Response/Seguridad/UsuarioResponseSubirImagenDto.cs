using Entidad.Dto.Global;
using System.Collections.Generic;
using System.ComponentModel;

namespace Entidad.Dto.Response.Seguridad
{
    public class UsuarioResponseSubirImagenDto
    {
        public int ProcesadoOk { get; set; }
        [DisplayName("ListaErrores")]
        public List<ErrorDto> ListaError { get; set; }
        public string UrlImagen { get; set; }
        public int StatusCode { get; set; }
        public UsuarioResponseSubirImagenDto()
        {
            ProcesadoOk = 0;
            ListaError = new List<ErrorDto>();
            UrlImagen = string.Empty;
        }
    }
}
