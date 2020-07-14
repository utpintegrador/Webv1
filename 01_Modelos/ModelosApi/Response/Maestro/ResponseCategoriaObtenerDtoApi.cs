using System.Collections.Generic;
using ModelosApi.Dto.Maestro;
using ModelosApi.Response.Comun;

namespace ModelosApi.Response.Maestro
{
    public class ResponseCategoriaObtenerDtoApi
    {
        public int ProcesadoOk { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
        public List<CategoriaObtenerDtoApi> Cuerpo { get; set; }
        public int CantidadTotalRegistros { get; set; }
        public ResponseCategoriaObtenerDtoApi()
        {
            ProcesadoOk = 0;
            ListaError = new List<ErrorDtoApi>();
            CantidadTotalRegistros = 0;
        }
    }
}
