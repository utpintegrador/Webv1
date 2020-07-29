﻿using System.ComponentModel.DataAnnotations;

namespace ModelosApi.Request.Maestro
{
    public class RequestTipoDescuentoModificarDtoApi
    {
        [Range(1, int.MaxValue, ErrorMessage = "{0}: debe tener un valor mayor o igual a {1}")]
        public int IdTipoDescuento { get; set; }

        [Required(ErrorMessage = "{0}: parametro es requerido")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "{0}: longitud debe estar entre {2} y {1} caracteres")]
        public string Descripcion { get; set; }
    }
}
