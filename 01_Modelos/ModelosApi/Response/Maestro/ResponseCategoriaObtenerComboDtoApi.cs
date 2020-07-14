using ModelosApi.Dto.Maestro;
using ModelosApi.Response.Comun;
using System.Collections.Generic;

namespace ModelosApi.Response.Maestro
{
    public class ResponseCategoriaObtenerComboDtoApi
    {
        public int ProcesadoOk { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
        public List<CategoriaObtenerComboDtoApi> Cuerpo { get; set; }
        public ResponseCategoriaObtenerComboDtoApi()
        {
            ProcesadoOk = 0;
            ListaError = new List<ErrorDtoApi>();
        }
    }
}
