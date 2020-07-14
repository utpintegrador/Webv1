﻿using ModelosApi.Response.Comun;
using System.Collections.Generic;

namespace ModelosApi.Response.Maestro
{
    public class ResponseNegocioModificarDtoApi
    {
        public int ProcesadoOk { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
        public ResponseNegocioModificarDtoApi()
        {
            ProcesadoOk = 0;
            ListaError = new List<ErrorDtoApi>();
        }
    }
}