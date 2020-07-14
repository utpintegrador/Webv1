using ModelosApi.Response.Comun;
using System.Collections.Generic;

namespace Entidad.Response.Seguridad
{
    public class ResponseRolModificarDtoApi
    {
        public int ProcesadoOk { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
        public ResponseRolModificarDtoApi()
        {
            ProcesadoOk = 0;
            ListaError = new List<ErrorDtoApi>();
        }
    }
}
