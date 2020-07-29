using ModelosApi.Request.Comun;
using System.ComponentModel.DataAnnotations;

namespace ModelosApi.Request.Transaccion
{
    public class RequestPedidoObtenerVentasPorIdUsuarioDtoApi : FiltroPaginacionApi
    {
        [Range(1, long.MaxValue, ErrorMessage = "{0}: debe tener un valor mayor o igual a {1}")]
        public long IdUsuario { get; set; }
        public long IdNegocioVendedor { get; set; }
        public string Buscar { get; set; }
        public int IdEstado { get; set; }
        public int IdMoneda { get; set; }
        public string FechaDesde { get; set; }
        public string FechaHasta { get; set; }
        public RequestPedidoObtenerVentasPorIdUsuarioDtoApi()
        {
            Buscar = string.Empty;
        }
    }
}
