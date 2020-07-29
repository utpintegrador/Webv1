using ModelosApi.Dto.Grafico;
using ModelosApi.Response.Comun;
using System.Collections.Generic;

namespace ModelosApi.Response.Grafico
{
    public class ResponseGraficoObtenerResumenWebDtoApi
    {
        public int ProcesadoOk { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
        public GraficoObtenerResumenDtoApi Cuerpo { get; set; }
        public int StatusCode { get; set; } = 200;
        public ResponseGraficoObtenerResumenWebDtoApi()
        {
            ProcesadoOk = 0;
            ListaError = new List<ErrorDtoApi>();
        }
    }
}
