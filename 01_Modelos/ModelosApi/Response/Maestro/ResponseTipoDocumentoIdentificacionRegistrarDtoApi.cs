using ModelosApi.Response.Comun;
using System.Collections.Generic;

namespace ModelosApi.Response.Maestro
{
    public class ResponseTipoDocumentoIdentificacionRegistrarDtoApi
    {
        public int ProcesadoOk { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
        public int IdGenerado { get; set; }
        public ResponseTipoDocumentoIdentificacionRegistrarDtoApi()
        {
            ProcesadoOk = 0;
            ListaError = new List<ErrorDtoApi>();
            IdGenerado = 0;
        }
    }
}
