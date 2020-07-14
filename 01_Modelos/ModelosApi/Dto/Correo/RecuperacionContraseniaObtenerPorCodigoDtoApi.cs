namespace ModelosApi.Dto.Correo
{
    public class RecuperacionContraseniaObtenerPorCodigoDtoApi
    {
        public long IdUsuario { get; set; }
        public string CorreoElectronico { get; set; }
        public string CodigoGenerado { get; set; }
    }
}
