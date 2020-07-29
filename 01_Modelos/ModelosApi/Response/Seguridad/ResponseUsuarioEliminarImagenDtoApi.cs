﻿using ModelosApi.Response.Comun;
using System.Collections.Generic;

namespace ModelosApi.Response.Seguridad
{
    public class ResponseUsuarioEliminarImagenDtoApi
    {
        public int ProcesadoOk { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
        public string UrlImagen { get; set; }
        public int StatusCode { get; set; } = 200;
        public ResponseUsuarioEliminarImagenDtoApi()
        {
            ProcesadoOk = 0;
            ListaError = new List<ErrorDtoApi>();
            UrlImagen = string.Empty;
        }
    }
}
