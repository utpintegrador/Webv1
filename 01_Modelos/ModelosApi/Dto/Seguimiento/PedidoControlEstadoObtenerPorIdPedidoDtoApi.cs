namespace ModelosApi.Dto.Seguimiento
{
    public class PedidoControlEstadoObtenerPorIdPedidoDtoApi
    {
        public long IdPedidoControlEstado { get; set; }
        public string DescripcionEstado { get; set; }
        public string FechaRegistro { get; set; }
        public string CorreoElectronico { get; set; }
    }
}
