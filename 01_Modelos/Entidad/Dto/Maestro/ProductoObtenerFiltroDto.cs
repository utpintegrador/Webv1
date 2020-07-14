using Entidad.Dto.Comun;

namespace Entidad.Dto.Maestro
{
    public class ProductoObtenerFiltroDto : DataTableNet
    {
        public long IdUsuario { get; set; }
        public long IdNegocio { get; set; }
        public string Buscar { get; set; }
        public int IdEstado { get; set; }
        public int IdMoneda { get; set; }
        public int IdCategoria { get; set; }
        public ProductoObtenerFiltroDto()
        {
            IdNegocio = 0;
            Buscar = string.Empty;
            IdEstado = 0;
            IdMoneda = 0;
            IdCategoria = 0;
        }
    }
}
