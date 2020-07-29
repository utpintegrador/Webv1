using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelosApi.Request.Grafico
{
    public class RequestGraficoObtenerResumenDtoApi
    {
        [Range(1, long.MaxValue, ErrorMessage = "{0}: parametro requerido")]
        public long IdUsuario { get; set; }

        [Range(2020, 2030, ErrorMessage = "{0}: parametro debe indicar número de año")]
        public int Anio { get; set; }

        [Range(1, 12, ErrorMessage = "{0}: parametro debe indicar número de mes")]
        public int Mes { get; set; }
    }
}
