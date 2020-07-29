using ModelosApi.Response.Comun;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelosApi.Response.Maestro
{
    public class ResponseProductoDescuentoRegistrarDtoApi
    {
        public int ProcesadoOk { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
        public long IdGenerado { get; set; }
        public int StatusCode { get; set; } = 200;
        public ResponseProductoDescuentoRegistrarDtoApi()
        {
            ProcesadoOk = 0;
            ListaError = new List<ErrorDtoApi>();
            IdGenerado = 0;
        }
    }
}
