using System.Collections.Generic;

namespace ModelosApi.Request.Maestro
{
    public class RequestProductoEliminarMasivoDtoApi
    {
        public List<ObjetoProducto> ListaIdProducto { get; set; }
        public RequestProductoEliminarMasivoDtoApi()
        {
            ListaIdProducto = new List<ObjetoProducto>();
        }
    }

    public class ObjetoProducto
    {
        public long IdProducto { get; set; }
    }
}
