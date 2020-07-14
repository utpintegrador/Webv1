using ModelosApi.Dto.Seguridad;
using ModelosApi.Response.Comun;
using System.Collections.Generic;

namespace Entidad.Response.Seguridad
{
    public class ResponseRolObtenerPorIdDtoApi
    {
        public int ProcesadoOk { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
        public RolObtenerPorIdDtoApi Cuerpo { get; set; }
        public ResponseRolObtenerPorIdDtoApi()
        {
            ProcesadoOk = 0;
            ListaError = new List<ErrorDtoApi>();
        }
    }
}
