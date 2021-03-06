﻿using System;

namespace Entidad.Dto.Gestion
{
    public class IncidenciaModificarDto
    {
        public Int32 IdIncidencia { get; set; }
        public Int32 IdCliente { get; set; }
        public String Asunto { get; set; }
        public Int32 IdTipoIncidencia { get; set; }
        public Int32 IdPrioridad { get; set; }
        public Int32 IdEstado { get; set; }
        public Int32? IdUsuarioRegistra { get; set; }

    }
}
