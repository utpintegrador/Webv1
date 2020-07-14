﻿using ModelosApi.Request.Comun;
using System.ComponentModel.DataAnnotations;

namespace Entidad.Request.Transaccion
{
    public class RequestPedidoObtenerPorIdNegocioVendedorDtoApi : FiltroPaginacionApi
    {
        [Range(1, long.MaxValue, ErrorMessage = "{0}: debe tener un valor mayor o igual a {1}")]
        public long IdNegocioVendedor { get; set; }
        public string Buscar { get; set; }
    }
}
