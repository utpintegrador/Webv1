using ModelosApi.Dto.Maestro;
using ModelosApi.Response.Comun;
using System.Collections.Generic;

namespace ModelosApi.Response.Maestro
{
    public class ResponseProductoImagenObtenerPorIdProductoDtoApi
    {
        public int ProcesadoOk { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
        public List<ProductoImagenObtenerPorIdProductoDtoApi> Cuerpo { get; set; }
        public int CantidadTotalRegistros { get; set; }
        public ResponseProductoImagenObtenerPorIdProductoDtoApi()
        {
            ProcesadoOk = 0;
            ListaError = new List<ErrorDtoApi>();
            CantidadTotalRegistros = 0;
        }
    }
}
