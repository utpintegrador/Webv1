﻿using System.ComponentModel.DataAnnotations;

namespace Entidad.Request.Maestro
{
    public class RequestProductoImagenModificarImagenMetodo1DtoApi
    {
        [Range(1, int.MaxValue, ErrorMessage = "{0}: debe tener un valor mayor o igual a {1}")]
        public long IdProducto { get; set; }

        [Required(ErrorMessage = "{0}: parametro es requerido")]
        public string ExtensionSinPunto { get; set; }

        [Required(ErrorMessage = "{0}: parametro es requerido")]
        public byte[] ArchivoBytes { get; set; }
    }
}
