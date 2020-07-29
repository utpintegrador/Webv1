namespace ModelosApi.Dto.Grafico
{
    public class GraficoObtenerResumenDtoApi
    {
        public int CantidadProductosOfrecidos { get; set; }
        public int CantidadVentas { get; set; }
        public int CantidadCompras { get; set; }
        public decimal ValoracionObtenidaComoComprador { get; set; }
        public decimal ValoracionObtenidaComoVendedor { get; set; }
    }
}
