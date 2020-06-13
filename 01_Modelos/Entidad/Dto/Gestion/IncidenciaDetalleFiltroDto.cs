using Entidad.Dto.Comun;
using System;

namespace Entidad.Dto.Gestion
{
    public class IncidenciaDetalleFiltroDto : DataTableNet
    {
        public Int32 IdIncidencia { get; set; }
        public Int32 IdIncidenciaDetalle { get; set; }
        public String Descripcion { get; set; }
        public Boolean RecortarDescripcion { get; set; }

        public IncidenciaDetalleFiltroDto()
        {
            RecortarDescripcion = false;
        }
    }
}
