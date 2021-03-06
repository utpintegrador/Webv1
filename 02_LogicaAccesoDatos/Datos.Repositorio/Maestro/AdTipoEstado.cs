﻿using Entidad.Entidad.Maestro;
using System;
using System.Data;
using System.Collections.Generic;
using Datos.Helper;
using Dapper;
using System.Linq;
using Entidad.Configuracion.Proceso;
using Entidad.Dto.Maestro;

namespace Datos.Repositorio.Maestro
{
    public class AdTipoEstado : Logger
    {
        //public List<TipoEstadoObtenerDto> Obtener(TipoEstadoObtenerFiltroDto filtro)
        //{
        //    List<TipoEstadoObtenerDto> resultado = new List<TipoEstadoObtenerDto>();
        //    try
        //    {
        //        const string query = "Maestro.usp_TipoEstado_Obtener";

        //        using (var cn = HelperClass.ObtenerConeccion())
        //        {
        //            if (cn.State == ConnectionState.Closed)
        //            {
        //                cn.Open();
        //            }

        //            resultado = cn.Query<TipoEstadoObtenerDto>(query, new
        //            {
        //                filtro.Buscar,
        //                //NumeroPagina = filtro.NumberPage,
        //                CantidadRegistros = filtro.Length,
        //                ColumnaOrden = filtro.ColumnOrder,
        //                DireccionOrden = filtro.OrderDirection
        //            }, commandType: CommandType.StoredProcedure).ToList();

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Log(Level.Error, (ex.InnerException == null ? ex.Message : ex.InnerException.Message));
        //    }
        //    return resultado;
        //}

        //public TipoEstado ObtenerPorId(int id)
        //{
        //    TipoEstado resultado = new TipoEstado();
        //    try
        //    {
        //        const string query = "Maestro.usp_TipoEstado_ObtenerPorId";

        //        using (var cn = HelperClass.ObtenerConeccion())
        //        {
        //            if (cn.State == ConnectionState.Closed)
        //            {
        //                cn.Open();
        //            }

        //            resultado = cn.QuerySingleOrDefault<TipoEstado>(query, new
        //            {
        //                IdTipoEstado = id
        //            }, commandType: CommandType.StoredProcedure);

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Log(Level.Error, (ex.InnerException == null ? ex.Message : ex.InnerException.Message));
        //    }
        //    return resultado;
        //}

        //public int Registrar(TipoEstadoRegistrarDto modelo, ref int idNuevo)
        //{
        //    int resultado = 0;
        //    try
        //    {
        //        const string query = "Maestro.usp_TipoEstado_Registrar";

        //        var p = new DynamicParameters();
        //        p.Add("IdTipoEstado", 0, DbType.Int32, ParameterDirection.Output);
        //        p.Add("Descripcion", modelo.Nombre);
        //        p.Add("Observacion", modelo.Observacion);

        //        using (var cn = HelperClass.ObtenerConeccion())
        //        {
        //            if (cn.State == ConnectionState.Closed)
        //            {
        //                cn.Open();
        //            }

        //            resultado = cn.Execute(query, commandType: CommandType.StoredProcedure, param: p);

        //            idNuevo = p.Get<int>("IdTipoEstado");

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log(Level.Error, (ex.InnerException == null ? ex.Message : ex.InnerException.Message));
        //    }
        //    return resultado;
        //}

        //public int Modificar(TipoEstadoModificarDto modelo)
        //{
        //    int resultado = 0;
        //    try
        //    {
        //        const string query = "Maestro.usp_TipoEstado_Modificar";

        //        using (var cn = HelperClass.ObtenerConeccion())
        //        {
        //            if (cn.State == ConnectionState.Closed)
        //            {
        //                cn.Open();
        //            }

        //            resultado = cn.Execute(query, new {
        //                modelo.IdTipoEstado,
        //                modelo.Nombre,
        //                modelo.Observacion
        //            }, commandType: CommandType.StoredProcedure);

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log(Level.Error, (ex.InnerException == null ? ex.Message : ex.InnerException.Message));
        //    }
        //    return resultado;
        //}

        //public int Eliminar(int id)
        //{
        //    int resultado = 0;
        //    try
        //    {
        //        const string query = "Maestro.usp_TipoEstado_Eliminar";

        //        using (var cn = HelperClass.ObtenerConeccion())
        //        {
        //            if (cn.State == ConnectionState.Closed)
        //            {
        //                cn.Open();
        //            }

        //            resultado = cn.Execute(query, new
        //            {
        //                IdTipoEstado = id,
        //            }, commandType: CommandType.StoredProcedure);

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log(Level.Error, (ex.InnerException == null ? ex.Message : ex.InnerException.Message));
        //    }
        //    return resultado;
        //}

        //public List<TipoEstadoObtenerComboDto> ObtenerCombo()
        //{
        //    List<TipoEstadoObtenerComboDto> resultado = new List<TipoEstadoObtenerComboDto>();
        //    try
        //    {
        //        const string query = "Maestro.usp_TipoEstado_Combo";

        //        using (var cn = HelperClass.ObtenerConeccion())
        //        {
        //            if (cn.State == ConnectionState.Closed)
        //            {
        //                cn.Open();
        //            }

        //            resultado = cn.Query<TipoEstadoObtenerComboDto>(query, commandType: CommandType.StoredProcedure).ToList();

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Log(Level.Error, (ex.InnerException == null ? ex.Message : ex.InnerException.Message));
        //    }
        //    return resultado;
        //}

    }
}
