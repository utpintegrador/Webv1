using System.ComponentModel.DataAnnotations;

namespace ModelosApi.Request.Maestro
{
    public class RequestProductoDescuentoRegistrarDtoApi
    {
        [Range(1, long.MaxValue, ErrorMessage = "{0}: debe tener un valor mayor o igual a {1}")]
        public long IdProducto { get; set; }

        [MaxLength(19, ErrorMessage = "{0}: longitud máxima debe ser de {1} caracteres")]
        public string FechaInicio { get; set; }

        [MaxLength(19, ErrorMessage = "{0}: longitud máxima debe ser de {1} caracteres")]
        public string FechaFin { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "{0}: debe tener un valor mayor o igual a {1}")]
        public int IdTipoDescuento { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "{0}: debe tener un valor mayor o igual a {1}")]
        public decimal Valor { get; set; }
    }
}
