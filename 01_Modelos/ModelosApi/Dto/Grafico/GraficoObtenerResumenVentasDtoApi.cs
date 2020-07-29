namespace ModelosApi.Dto.Grafico
{
    public class GraficoObtenerResumenVentasDtoApi
    {
        public int Anio { get; set; }
        public int Mes { get; set; }
        public string NombreMes { get; set; }
        public decimal Total { get; set; }
    }
}
