using ModelosApi.Dto.Maestro;
using ModelosApi.Response.Comun;
using System.Collections.Generic;

namespace ModelosApi.Response.Maestro
{
    public class ResponseEstadoObtenerComboVendedorDtoApi
    {
        public int ProcesadoOk { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
        public List<EstadoObtenerComboVendedorDtoApi> Cuerpo { get; set; }
        public int StatusCode { get; set; } = 200;
        public ResponseEstadoObtenerComboVendedorDtoApi()
        {
            ProcesadoOk = 0;
            ListaError = new List<ErrorDtoApi>();
        }
    }
}
