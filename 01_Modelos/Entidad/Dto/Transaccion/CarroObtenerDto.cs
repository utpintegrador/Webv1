using System;
using System.Collections.Generic;

namespace Entidad.Dto.Transaccion
{
    public class CarroObtenerDto
    {
        public long IdCarro { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long IdUsuario { get; set; }
        public List<CarroItemObtenerDto> ListaCarroItem { get; set; }
        public CarroObtenerDto()
        {
            ListaCarroItem = new List<CarroItemObtenerDto>();
        }
    }
}
