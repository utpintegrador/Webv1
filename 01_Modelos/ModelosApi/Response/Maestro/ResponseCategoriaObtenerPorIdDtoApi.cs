using System.Collections.Generic;
using ModelosApi.Dto.Maestro;
using ModelosApi.Response.Comun;

namespace ModelosApi.Response.Maestro
{
    public class ResponseCategoriaObtenerPorIdDtoApi
    {
        public int ProcesadoOk { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
        public CategoriaObtenerPorIdDtoApi Cuerpo { get; set; }
        public ResponseCategoriaObtenerPorIdDtoApi()
        {
            ProcesadoOk = 0;
            ListaError = new List<ErrorDtoApi>();
        }
    }
}
