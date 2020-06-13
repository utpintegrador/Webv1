using Datos.Repositorio.Gestion;
using Entidad.Dto.Gestion;
using Entidad.Entidad.Gestion;
using System.Collections.Generic;

namespace Negocio.Repositorio.Gestion
{
    public class LnIncidencia
    {
        private readonly AdIncidencia _adIncidencia = new AdIncidencia();
        public List<IncidenciaObtenerDto> Obtener()//IncidenciaObtenerFiltroDto filtro)
        {
            return _adIncidencia.Obtener();// filtro);
        }

        public List<IncidenciaComboDto> ObtenerCombo()
        {
            return _adIncidencia.ObtenerCombo();
        }

        public Incidencia ObtenerPorId(int id)
        {
            return _adIncidencia.ObtenerPorId(id);
        }

        public IncidenciaObtenerPorIdDetalladoDto ObtenerPorIdDetallado(int id)
        {
            return _adIncidencia.ObtenerPorIdDetallado(id);
        }

        public int Registrar(IncidenciaRegistrarDto modelo, ref int idNuevo)
        {
            return _adIncidencia.Registrar(modelo, ref idNuevo);
        }

        public int Modificar(IncidenciaModificarDto modelo)
        {
            return _adIncidencia.Modificar(modelo);
        }

        public int ModificarEstado(IncidenciaModificarEstadoDto modelo)
        {
            return _adIncidencia.ModificarEstado(modelo);
        }

        public int Eliminar(int id)
        {
            return _adIncidencia.Eliminar(id);
        }
    }
}
