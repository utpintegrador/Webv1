using Entidad.Dto.Comun;

namespace Entidad.Dto.Maestro
{
    public class TipoDocumentoIdentificacionObtenerFiltroDto: DataTableNet
    {
        public string Buscar { get; set; }
        public TipoDocumentoIdentificacionObtenerFiltroDto()
        {
            Buscar = string.Empty;
        }
    }
}
