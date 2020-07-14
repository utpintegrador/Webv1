using ModelosApi.Dto.Seguridad;
using ModelosApi.Response.Comun;
using System.Collections.Generic;

namespace Entidad.Response.Seguridad
{
    public class ResponseAccesoObtenerPorIdDtoApi
    {
        public int ProcesadoOk { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
        public AccesoObtenerPorIdDtoApi Cuerpo { get; set; }
        public ResponseAccesoObtenerPorIdDtoApi()
        {
            ProcesadoOk = 0;
            ListaError = new List<ErrorDtoApi>();
        }
    }
}
