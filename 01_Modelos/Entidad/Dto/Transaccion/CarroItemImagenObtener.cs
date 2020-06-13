namespace Entidad.Dto.Transaccion
{
    public class CarroItemImagenObtener
    {
        public int Indice { get; set; }
        public string UrlImagen { get; set; }
        public string Descripcion { get; set; }
        public bool Predeterminado { get; set; }
        public CarroItemImagenObtener()
        {
            Predeterminado = false;
            Descripcion = string.Empty;
        }
    }
}
