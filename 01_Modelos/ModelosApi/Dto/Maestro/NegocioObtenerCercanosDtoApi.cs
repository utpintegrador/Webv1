﻿namespace ModelosApi.Dto.Maestro
{
    public class NegocioObtenerCercanosDtoApi
    {
        public int Item { get; set; }
        public long IdNegocio { get; set; }
        public string DocumentoIdentificacion { get; set; }
        public string Nombre { get; set; }
        public string Resenia { get; set; }
        public string DescripcionTipoDocumentoIdentificacion { get; set; }
        public string DescripcionEstado { get; set; }
        public string FechaRegistro { get; set; }
        public string CorreoElectronico { get; set; }
        public decimal Longitud { get; set; }
        public decimal Latitud { get; set; }
        public string Telefono { get; set; }
    }
}
