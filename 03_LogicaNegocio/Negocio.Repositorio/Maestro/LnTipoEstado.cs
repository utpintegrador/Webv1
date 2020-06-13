using Datos.Repositorio.Maestro;
using Entidad.Dto.Maestro;
using Entidad.Entidad.Maestro;
using System.Collections.Generic;

namespace Negocio.Repositorio.Maestro
{
    public class LnTipoEstado
    {
        private readonly AdTipoEstado _adTipoEstado = new AdTipoEstado();

        public List<TipoEstadoObtenerDto> Obtener(TipoEstadoObtenerFiltroDto filtro)
        {
            filtro.Buscar = "";
            filtro.NumberPage = 1;
            filtro.Length = 200;
            filtro.ColumnOrder = "IdTipoEstado";
            filtro.OrderDirection = "desc";
            return _adTipoEstado.Obtener(filtro);
        }

        public TipoEstado ObtenerPorId(int id)
        {
            return _adTipoEstado.ObtenerPorId(id);
        }

        public int Registrar(TipoEstadoRegistrarDto modelo, ref int idNuevo)
        {
            return _adTipoEstado.Registrar(modelo, ref idNuevo);
        }

        public int Modificar(TipoEstadoModificarDto modelo)
        {
            return _adTipoEstado.Modificar(modelo);
        }

        public int Eliminar(int id)
        {
            return _adTipoEstado.Eliminar(id);
        }

        public List<TipoEstadoObtenerComboDto> ObtenerCombo()
        {
            return _adTipoEstado.ObtenerCombo();
        }

    }
}
