using ModelosApi.Dto.Maestro;
using ModelosApi.Response.Comun;
using System.Collections.Generic;

namespace ModelosApi.Response.Maestro
{
    public class ResponseNegocioObtenerCercanosDtoApi
    {
        public int ProcesadoOk { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
        public List<NegocioObtenerCercanosDtoApi> Cuerpo { get; set; }
        public int CantidadTotalRegistros { get; set; }
        public int StatusCode { get; set; } = 200;
        public ResponseNegocioObtenerCercanosDtoApi()
        {
            ProcesadoOk = 0;
            ListaError = new List<ErrorDtoApi>();
            CantidadTotalRegistros = 0;
        }
    }
}
