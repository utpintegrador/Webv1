using ModelosApi.Response.Comun;
using System.Collections.Generic;

namespace ModelosApi.Response.Maestro
{
    public class ResponseTipoEstadoModificarDtoApi
    {
        public int ProcesadoOk { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
        public ResponseTipoEstadoModificarDtoApi()
        {
            ProcesadoOk = 0;
            ListaError = new List<ErrorDtoApi>();
        }
    }
}
