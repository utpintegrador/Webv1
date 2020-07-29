using ModelosApi.Dto.Seguridad;
using ModelosApi.Response.Comun;
using System.Collections.Generic;

namespace ModelosApi.Response.Seguridad
{
    public class ResponseAccesoObtenerPorIdUsuarioDtoApi
    {
        public int ProcesadoOk { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
        public AccesoRootDtoApi Cuerpo { get; set; }
        public int StatusCode { get; set; } = 200;
        public ResponseAccesoObtenerPorIdUsuarioDtoApi()
        {
            ProcesadoOk = 0;
            ListaError = new List<ErrorDtoApi>();
        }
    }
}
