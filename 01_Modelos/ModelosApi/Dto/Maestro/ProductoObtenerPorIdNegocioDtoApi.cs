﻿namespace ModelosApi.Dto.Maestro
{
    public class ProductoObtenerPorIdNegocioDtoApi
    {
        public int Item { get; set; }
        public long IdProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public string DescripcionExtendida { get; set; }
        public decimal Precio { get; set; }
        public string DescripcionMoneda { get; set; }
        public string DescripcionCategoria { get; set; }
        public long IdNegocio { get; set; }
        public string Negocio { get; set; }
        public string DescripcionEstado { get; set; }
        public string UrlImagen { get; set; }
    }
}
