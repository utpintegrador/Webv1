﻿using Entidad.Dto.Comun;
using System;

namespace Entidad.Dto.Seguridad
{
    public class UsuarioObtenerFiltroDto : DataTableNet
    {
        public String Buscar { get; set; }
        public Int32 IdEstado { get; set; }
        public Int32 IdRol { get; set; }
        public Int32 IdArea { get; set; }
    }
}