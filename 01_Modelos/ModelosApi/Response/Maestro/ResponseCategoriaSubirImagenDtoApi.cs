using ModelosApi.Response.Comun;
using System.Collections.Generic;

namespace ModelosApi.Response.Maestro
{
    public class ResponseCategoriaSubirImagenDtoApi
    {
        public int ProcesadoOk { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
        public string UrlImagen { get; set; }
        public int StatusCode { get; set; } = 200;
        public ResponseCategoriaSubirImagenDtoApi()
        {
            ProcesadoOk = 0;
            ListaError = new List<ErrorDtoApi>();
            UrlImagen = string.Empty;
        }
    }
}
