using ModelosApi.Dto.Correo;
using ModelosApi.Response.Comun;
using System.Collections.Generic;

namespace ModelosApi.Response.Correo
{
    public class ResponseRecuperacionContraseniaRegistrarDtoApi
    {
        public int ProcesadoOk { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
        public RecuperacionContraseniaObtenerRegistradoDtoApi Cuerpo { get; set; }
        public int StatusCode { get; set; } = 200;
        public ResponseRecuperacionContraseniaRegistrarDtoApi()
        {
            ProcesadoOk = 0;
            ListaError = new List<ErrorDtoApi>();
        }
    }
}
