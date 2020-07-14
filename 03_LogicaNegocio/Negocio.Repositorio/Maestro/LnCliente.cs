using Datos.Repositorio.Maestro;
using Entidad.Dto.Comun;
using Entidad.Dto.Maestro;
using Entidad.Entidad.Maestro;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Negocio.Repositorio.Maestro
{
    public class LnCliente
    {
        //private readonly AdCliente _adCliente = new AdCliente();
        //public ResultDataTable Obtener(ClienteObtenerFiltroDto filtro)
        //{
        //    ResultDataTable result;
        //    int totalRegistros = 0;
        //    List<ClienteObtenerDto> lista = new List<ClienteObtenerDto>();
        //    string mensajeError = "";

        //    //filtro.NumberPage++;
        //    if (filtro.Order.Count > 0)
        //    {
        //        filtro.ColumnOrder = filtro.Columns[filtro.Order[0].Column].Name;
        //        filtro.OrderDirection = filtro.Order[0].Dir;
        //    }
            

        //    try
        //    {
        //        lista = _adCliente.Obtener(filtro);
        //        if (lista.Any())
        //        {
        //            totalRegistros = lista.First().TotalItems;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        mensajeError = ex.Message;
        //    }
        //    finally
        //    {
        //        result = new ResultDataTable
        //        {
        //            draw = filtro.Draw,
        //            recordsTotal = totalRegistros,
        //            recordsFiltered = totalRegistros,
        //            data = lista,
        //            error = mensajeError
        //        };

        //    }

        //    return result;

        //}

        //public List<ClienteObtenerPendientePorUsuarioDto> ObtenerPendientesPorUsuario(ClienteObtenerFiltroDto filtro)
        //{

        //    filtro.Buscar = "";
        //    filtro.ColumnOrder = "IdCliente";
        //    filtro.OrderDirection = "desc";
        //    filtro.IdEstado = 1;
        //    filtro.IdUsuario = 1;

        //    return _adCliente.ObtenerPendientesPorUsuario(filtro);
        //}

        //public List<ClienteObtenerComboDto> ObtenerCombo(Int32 idEstado)
        //{
        //    return _adCliente.ObtenerCombo(idEstado);
        //}

        //public List<ClienteObtenerComboDto> ObtenerComboPorIdUsuario(Int32 idEstado, Int32 idUsuario)
        //{
        //    return _adCliente.ObtenerComboPorIdUsuario(idEstado, idUsuario);
        //}

        //public Cliente ObtenerPorId(int id)
        //{
        //    return _adCliente.ObtenerPorId(id);
        //}

        //public Int32 Registrar(ClienteRegistrarDto entidad)
        //{
        //    return _adCliente.Registrar(entidad);
        //}

        //public Int32 Modificar(ClienteModificarDto entidad)
        //{
        //    return _adCliente.Modificar(entidad);
        //}

        //public Int32 Eliminar(Int32 id)
        //{
        //    return _adCliente.Eliminar(id);
        //}
    }
}
