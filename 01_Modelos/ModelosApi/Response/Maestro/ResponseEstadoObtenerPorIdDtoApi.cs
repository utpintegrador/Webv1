using ModelosApi.Dto.Maestro;
using ModelosApi.Response.Comun;
using System.Collections.Generic;

namespace ModelosApi.Response.Maestro
{
    public class ResponseEstadoObtenerPorIdDtoApi
    {
        public int ProcesadoOk { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
        public EstadoObtenerPorIdDtoApi Cuerpo { get; set; }
        public ResponseEstadoObtenerPorIdDtoApi()
        {
            ProcesadoOk = 0;
            ListaError = new List<ErrorDtoApi>();
        }
    }
}
