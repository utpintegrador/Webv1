﻿namespace ModelosApi.Dto.Seguridad
{
    public class UsuarioObtenerComboDtoApi
    {
        public long IdUsuario { get; set; }
        public string CorreoElectronico { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DescripcionEstado { get; set; }

    }
}
