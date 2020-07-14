namespace ModelosApi.Request.Comun
{
    public class FiltroPaginacionApi
    {
        public int NumeroPagina { get; set; }
        public int CantidadRegistros { get; set; }
        public string ColumnaOrden { get; set; }
        public string DireccionOrden { get; set; }
        public FiltroPaginacionApi()
        {
            NumeroPagina = 1;
            CantidadRegistros = 10;
            DireccionOrden = "desc";
        }
    }
}
