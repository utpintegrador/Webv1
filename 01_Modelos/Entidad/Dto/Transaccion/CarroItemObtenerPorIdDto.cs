using System.Collections.Generic;

namespace Entidad.Dto.Transaccion
{
    public class CarroItemObtenerPorIdDto
    {
        public string Descripcion { get; set; }
        public string DescripcionExtendida { get; set; }
        public decimal Precio { get; set; }
        public string Moneda { get; set; }
        public string Categoria { get; set; }
        public string Negocio { get; set; }
        public List<CarroItemImagenObtener> ListaImagen { get; set; }
    }
}
