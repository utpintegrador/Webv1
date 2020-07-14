using ModelosApi.Dto.Seguridad;
using ModelosApi.Response.Comun;
using System.Collections.Generic;

namespace Entidad.Response.Seguridad
{
    public class ResponseUsuarioObtenerComboDtoApi
    {
        public int ProcesadoOk { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
        public List<UsuarioObtenerComboDtoApi> Cuerpo { get; set; }
        public ResponseUsuarioObtenerComboDtoApi()
        {
            ProcesadoOk = 0;
            ListaError = new List<ErrorDtoApi>();
        }
    }
}
