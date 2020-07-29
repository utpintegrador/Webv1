using ModelosApi.Dto.Grafico;
using ModelosApi.Response.Comun;
using System.Collections.Generic;

namespace ModelosApi.Response.Grafico
{
    public class ResponseGraficoObtenerResumenComprasDtoApi
    {
        public int ProcesadoOk { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
        public List<GraficoObtenerResumenComprasDtoApi> Cuerpo { get; set; }
        public int StatusCode { get; set; } = 200;
        public ResponseGraficoObtenerResumenComprasDtoApi()
        {
            ProcesadoOk = 0;
            ListaError = new List<ErrorDtoApi>();
        }
    }
}
