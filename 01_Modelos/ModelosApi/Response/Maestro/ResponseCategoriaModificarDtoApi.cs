using ModelosApi.Response.Comun;
using System.Collections.Generic;

namespace ModelosApi.Response.Maestro
{
    public class ResponseCategoriaModificarDtoApi
    {
        public int ProcesadoOk { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
        public ResponseCategoriaModificarDtoApi()
        {
            ProcesadoOk = 0;
            ListaError = new List<ErrorDtoApi>();
        }
    }
}
