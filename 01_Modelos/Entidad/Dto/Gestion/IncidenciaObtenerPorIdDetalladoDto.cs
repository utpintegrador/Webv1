namespace Entidad.Dto.Gestion
{
    public class IncidenciaObtenerPorIdDetalladoDto
    {

        public string IdIncidencia { get; set; }
        public string Asunto { get; set; }
        public string NumeroDocumento { get; set; }
        public string RazonSocial { get; set; }
        public string DescripcionTipoIncidencia { get; set; }
        public string DescripcionPrioridad { get; set; }
        public string IdEstado { get; set; }
        public string DescripcionEstado { get; set; }

    }
}
