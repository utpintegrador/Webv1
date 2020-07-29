using System.Collections.Generic;

namespace ModelosApi.Response.Comun
{
    public class ResponseValidacionModeloDtoApi
    {
        public int ProcesadoOk { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
        public long IdGenerado { get; set; }
        public object Cuerpo { get; set; }
    }
}
