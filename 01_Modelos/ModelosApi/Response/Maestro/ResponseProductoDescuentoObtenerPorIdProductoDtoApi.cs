using ModelosApi.Dto.Maestro;
using ModelosApi.Response.Comun;
using System.Collections.Generic;

namespace ModelosApi.Response.Maestro
{
    public class ResponseProductoDescuentoObtenerPorIdProductoDtoApi
    {
        public int ProcesadoOk { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
        public List<ProductoDescuentoObtenerPorIdProductoDtoApi> Cuerpo { get; set; }
        public int CantidadTotalRegistros { get; set; }
        public int StatusCode { get; set; } = 200;
        public ResponseProductoDescuentoObtenerPorIdProductoDtoApi()
        {
            ProcesadoOk = 0;
            ListaError = new List<ErrorDtoApi>();
            CantidadTotalRegistros = 0;
        }
    }
}
