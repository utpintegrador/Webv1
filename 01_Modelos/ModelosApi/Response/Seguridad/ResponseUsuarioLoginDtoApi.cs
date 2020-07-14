using ModelosApi.Response.Comun;
using System;
using System.Collections.Generic;

namespace ModelosApi.Response.Seguridad
{
    public class ResponseUsuarioLoginDtoApi
    {
        public string Token { get; set; }
        public DateTime? Expiracion { get; set; }
        public long IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CorreoElectronico { get; set; }
        public string UrlImagen { get; set; }
        public List<ErrorDtoApi> ListaError { get; set; }
        public ResponseUsuarioLoginDtoApi()
        {
            ListaError = new List<ErrorDtoApi>();
        }

    }
}
