using System.Collections.Generic;

namespace ModelosApi.Response.Comun
{
    public class ResponseValidacionModelo2DtoApi
    {
        public int ProcesadoOk { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
    }
}
