using ModelosApi.Dto.Maestro;
using ModelosApi.Response.Comun;
using System.Collections.Generic;

namespace ModelosApi.Response.Maestro
{
    public class ResponseTipoEstadoObtenerComboDtoApi
    {
        public int ProcesadoOk { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
        public List<TipoEstadoObtenerComboDtoApi> Cuerpo { get; set; }
        public ResponseTipoEstadoObtenerComboDtoApi()
        {
            ProcesadoOk = 0;
            ListaError = new List<ErrorDtoApi>();
        }
    }
}
