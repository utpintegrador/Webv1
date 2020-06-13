using Datos.Repositorio.Gestion;
using Entidad.Dto.Gestion;
using Entidad.Entidad.Gestion;
using System;
using System.Collections.Generic;

namespace Negocio.Repositorio.Gestion
{
    public class LnIncidenciaDetalle
    {
        private readonly AdIncidenciaDetalle _adIncidenciaDetalle = new AdIncidenciaDetalle();
        public List<IncidenciaDetalleObtenerDto> Obtener(IncidenciaDetalleFiltroDto filtro)
        {
            return _adIncidenciaDetalle.Obtener(filtro);
        }

        public IncidenciaDetalle ObtenerPorId(int id)
        {
            return _adIncidenciaDetalle.ObtenerPorId(id);
        }

        public Int32 Registrar(IncidenciaDetalleRegistrarDto entidad)
        {
            return _adIncidenciaDetalle.Registrar(entidad);
        }

        public Int32 Modificar(IncidenciaDetalleModificarDto entidad)
        {
            return _adIncidenciaDetalle.Modificar(entidad);
        }

        public Int32 Eliminar(Int32 id)
        {
            return _adIncidenciaDetalle.Eliminar(id);
        }

        public List<IncidenciaDetalleObtenerDto> ObtenerHistorial(IncidenciaDetalleObtenerHistorialFiltroDto filtro)
        {
            return _adIncidenciaDetalle.ObtenerHistorial(filtro);
        }
    }
}
