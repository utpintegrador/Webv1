﻿using System;

namespace Entidad.Entidad.Seguridad
{
    public class Usuario
    {
        public long IdUsuario { get; set; }
        public string UserName { get; set; }
        public string Contrasenia { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int IdEstado { get; set; }

    }
}
