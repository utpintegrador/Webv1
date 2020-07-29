using ModelosApi.Dto.Maestro;
using ModelosApi.Response.Comun;
using System.Collections.Generic;

namespace ModelosApi.Response.Maestro
{
    public class ResponseNegocioUbicacionObtenerPorIdNegocioDtoApi
    {
        public int ProcesadoOk { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
        public List<NegocioUbicacionObtenerPorIdNegocioDtoApi> Cuerpo { get; set; }
        public int CantidadTotalRegistros { get; set; }
        public int StatusCode { get; set; } = 200;
        public ResponseNegocioUbicacionObtenerPorIdNegocioDtoApi()
        {
            ProcesadoOk = 0;
            ListaError = new List<ErrorDtoApi>();
            CantidadTotalRegistros = 0;
        }
    }
}
