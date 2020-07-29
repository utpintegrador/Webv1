using ModelosApi.Dto.Maestro;
using ModelosApi.Response.Comun;
using System.Collections.Generic;

namespace ModelosApi.Response.Maestro
{
    public class ResponseEstadoObtenerComboCompradorDtoApi
    {
        public int ProcesadoOk { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
        public List<EstadoObtenerComboCompradorDtoApi> Cuerpo { get; set; }
        public int StatusCode { get; set; } = 200;
        public ResponseEstadoObtenerComboCompradorDtoApi()
        {
            ProcesadoOk = 0;
            ListaError = new List<ErrorDtoApi>();
        }
    }
}
