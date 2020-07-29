namespace ModelosApi.Request.Maestro
{
    public class RequestProductoImportarDtoApi
    {
        public long IdNegocio { get; set; }
        public int IdMoneda { get; set; }
        public int IdCategoria { get; set; }
        public string ExtensionSinPunto { get; set; }
        public byte[] ArchivoBytes { get; set; }

    }
}
