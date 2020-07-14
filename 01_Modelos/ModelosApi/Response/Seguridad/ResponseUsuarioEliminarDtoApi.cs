using ModelosApi.Response.Comun;
using System.Collections.Generic;

namespace ModelosApi.Response.Seguridad
{
    public class ResponseUsuarioEliminarDtoApi
    {
        public int ProcesadoOk { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
        public ResponseUsuarioEliminarDtoApi()
        {
            ProcesadoOk = 0;
            ListaError = new List<ErrorDtoApi>();
        }
    }
}
