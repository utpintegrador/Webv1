using System.Collections.Generic;

namespace ModelosApi.Dto.Seguridad
{
    public class AccesoGrupoDtoApi
    {
        public int Orden { get; set; }
        public string Titulo { get; set; }
        public string UrlAcceso { get; set; }
        public string Icono { get; set; }
        public string EstiloDeGrupo { get; set; }
        public List<AccesoItemDtoApi> ListaItem { get; set; }
    }
}
