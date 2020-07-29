using ModelosApi.Dto.Maestro;
using ModelosApi.Response.Comun;
using System.Collections.Generic;

namespace ModelosApi.Response.Maestro
{
    public class ResponseProductoObtenerPorIdUsuarioDtoApi
    {
        public int ProcesadoOk { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
        public List<ProductoObtenerPorIdUsuarioDtoApi> Cuerpo { get; set; }
        public long CantidadTotalRegistros { get; set; }
        public int StatusCode { get; set; } = 200;
        public ResponseProductoObtenerPorIdUsuarioDtoApi()
        {
            ProcesadoOk = 0;
            ListaError = new List<ErrorDtoApi>();
            CantidadTotalRegistros = 0;
        }
    }
}
