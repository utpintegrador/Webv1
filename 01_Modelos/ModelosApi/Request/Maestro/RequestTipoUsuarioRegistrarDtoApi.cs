﻿using System.ComponentModel.DataAnnotations;

namespace ModelosApi.Request.Maestro
{
    public class RequestTipoUsuarioRegistrarDtoApi
    {
        [Required(ErrorMessage = "{0}: parametro es requerido")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "{0}: longitud debe estar entre {2} y {1} caracteres")]
        public string Descripcion { get; set; }
    }
}
