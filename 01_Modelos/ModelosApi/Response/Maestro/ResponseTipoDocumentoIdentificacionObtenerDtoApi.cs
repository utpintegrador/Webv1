using ModelosApi.Dto.Maestro;
using ModelosApi.Response.Comun;
using System.Collections.Generic;

namespace ModelosApi.Response.Maestro
{
    public class ResponseTipoDocumentoIdentificacionObtenerDtoApi
    {
        public int ProcesadoOk { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
        public List<TipoDocumentoIdentificacionObtenerDtoApi> Cuerpo { get; set; }
        public int CantidadTotalRegistros { get; set; }
        public ResponseTipoDocumentoIdentificacionObtenerDtoApi()
        {
            ProcesadoOk = 0;
            ListaError = new List<ErrorDtoApi>();
            CantidadTotalRegistros = 0;
        }
    }
}
