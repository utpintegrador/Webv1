using System.ComponentModel.DataAnnotations;

namespace ModelosApi.Request.Grafico
{
    public class RequestGraficoObtenerResumenComprasDtoApi
    {
        [Range(1, long.MaxValue, ErrorMessage = "{0}: el parametro es requerido")]
        public long IdUsuario { get; set; }
        public int CantidadMesesAtras { get; set; }
    }
}
