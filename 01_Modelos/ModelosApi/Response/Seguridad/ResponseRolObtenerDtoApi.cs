using ModelosApi.Dto.Seguridad;
using ModelosApi.Response.Comun;
using System.Collections.Generic;

namespace Entidad.Response.Seguridad
{
    public class ResponseRolObtenerDtoApi
    {
        public int ProcesadoOk { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
        public List<RolObtenerDtoApi> Cuerpo { get; set; }
        public int CantidadTotalRegistros { get; set; }
        public ResponseRolObtenerDtoApi()
        {
            ProcesadoOk = 0;
            ListaError = new List<ErrorDtoApi>();
            CantidadTotalRegistros = 0;
        }
    }
}
