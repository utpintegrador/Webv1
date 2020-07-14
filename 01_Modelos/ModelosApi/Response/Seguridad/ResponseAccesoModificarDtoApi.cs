using ModelosApi.Response.Comun;
using System.Collections.Generic;

namespace Entidad.Response.Seguridad
{
    public class ResponseAccesoModificarDtoApi
    {
        public int ProcesadoOk { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
        public ResponseAccesoModificarDtoApi()
        {
            ProcesadoOk = 0;
            ListaError = new List<ErrorDtoApi>();
        }
    }
}
