﻿namespace ModelosApi.Dto.Correo
{
    public class RecuperacionContraseniaObtenerRegistradoDtoApi
    {
        public int NumeroRespuesta { get; set; }
        public string DescripcionRespuesta { get; set; }
        public string CorreoElectronico { get; set; }
        public string Codigo { get; set; }
        public long IdUsuario { get; set; }
    }
}
