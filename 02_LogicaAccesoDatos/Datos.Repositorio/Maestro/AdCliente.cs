using Dapper;
using Datos.Helper;
using Entidad.Configuracion.Proceso;
using Entidad.Dto.Maestro;
using Entidad.Entidad.Maestro;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Datos.Repositorio.Maestro
{
    public class AdCliente: Logger
    {
        //public List<ClienteObtenerDto> Obtener(ClienteObtenerFiltroDto filtro)
        //{

        //    List<ClienteObtenerDto> lista = new List<ClienteObtenerDto>();

        //    try
        //    {
        //        const string query = "Maestro.usp_Cliente_Obtener";
        //        using (var cn = HelperClass.ObtenerConeccion())
        //        {
        //            if (cn.State == ConnectionState.Closed)
        //            {
        //                cn.Open();
        //            }

        //            lista = cn.Query<ClienteObtenerDto>(query, new
        //            {
        //                filtro.Buscar,
        //                filtro.IdEstado,
        //                //NumeroPagina = filtro.NumberPage,
        //                CantidadRegistros = filtro.Length,
        //                ColumnaOrden = filtro.ColumnOrder,
        //                DireccionOrden = filtro.OrderDirection
        //            },
        //            commandType: CommandType.StoredProcedure).ToList();

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Log(Level.Error, ex.InnerException == null ? ex.Message : ex.InnerException.Message);
        //    }
        //    return lista;
        //}

        ///// <summary>
        ///// Clientes que no fueron asignados hacia un cliente
        ///// </summary>
        ///// <param name="filtro"></param>
        ///// <returns></returns>
        //public List<ClienteObtenerPendientePorUsuarioDto> ObtenerPendientesPorUsuario(ClienteObtenerFiltroDto filtro)
        //{

        //    List<ClienteObtenerPendientePorUsuarioDto> lista = new List<ClienteObtenerPendientePorUsuarioDto>();

        //    try
        //    {
        //        const string query = "Maestro.usp_Cliente_ObtenerPendientesPorUsuario";
        //        using (var cn = HelperClass.ObtenerConeccion())
        //        {
        //            if (cn.State == ConnectionState.Closed)
        //            {
        //                cn.Open();
        //            }

        //            lista = cn.Query<ClienteObtenerPendientePorUsuarioDto>(query, new
        //            {
        //                filtro.Buscar,
        //                filtro.IdEstado,
        //                filtro.IdUsuario,
        //                ColumnaOrden = filtro.ColumnOrder,
        //                DireccionOrden = filtro.OrderDirection
        //            },
        //                commandType: CommandType.StoredProcedure).ToList();

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Log(Level.Error, ex.InnerException == null ? ex.Message : ex.InnerException.Message);
        //    }
        //    return lista;
        //}

        //public List<ClienteObtenerComboDto> ObtenerCombo(Int32 idEstado)
        //{
        //    List<ClienteObtenerComboDto> lista = new List<ClienteObtenerComboDto>();
        //    try
        //    {
        //        const string query = "Maestro.usp_Cliente_Combo";

        //        using (var cn = HelperClass.ObtenerConeccion())
        //        {
        //            if (cn.State == ConnectionState.Closed)
        //            {
        //                cn.Open();
        //            }

        //            lista = cn.Query<ClienteObtenerComboDto>(query, new
        //            {
        //                IdEstado = idEstado
        //            }, commandType: CommandType.StoredProcedure).ToList();

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log(Level.Error, ex.InnerException == null ? ex.Message : ex.InnerException.Message);
        //    }

            
        //    return lista;
        //}

        //public List<ClienteObtenerComboDto> ObtenerComboPorIdUsuario(Int32 idEstado, Int32 idUsuario)
        //{
        //    List<ClienteObtenerComboDto> lista = new List<ClienteObtenerComboDto>();
        //    try
        //    {
        //        const string query = "Maestro.usp_Cliente_ComboPorIdUsuario";

        //        using (var cn = HelperClass.ObtenerConeccion())
        //        {
        //            if (cn.State == ConnectionState.Closed)
        //            {
        //                cn.Open();
        //            }

        //            lista = cn.Query<ClienteObtenerComboDto>(query, new
        //            {
        //                IdEstado = idEstado,
        //                IdUsuario = idUsuario
        //            }, commandType: CommandType.StoredProcedure).ToList();

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log(Level.Error, ex.InnerException == null ? ex.Message : ex.InnerException.Message);
        //    }
            
        //    return lista;
        //}

        //public Cliente ObtenerPorId(int id)
        //{

        //    Cliente entidad = null;

        //    try
        //    {
        //        const string query = "Maestro.usp_Cliente_ObtenerPorId";
        //        using (var cn = HelperClass.ObtenerConeccion())
        //        {
        //            if (cn.State == ConnectionState.Closed)
        //            {
        //                cn.Open();
        //            }

        //            entidad = cn.Query<Cliente>(query, new
        //            {
        //                IdCliente = id
        //            },
        //            commandType: CommandType.StoredProcedure).FirstOrDefault();

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Log(Level.Error, ex.InnerException == null ? ex.Message : ex.InnerException.Message);
        //    }
        //    return entidad;
        //}

        //public Cliente ObtenerDetalle(int id)
        //{

        //    Cliente entidad = null;

        //    try
        //    {
        //        const string query = "Maestro.usp_Cliente_ObtenerPorId";
        //        using (var cn = HelperClass.ObtenerConeccion())
        //        {
        //            if (cn.State == ConnectionState.Closed)
        //            {
        //                cn.Open();
        //            }

        //            entidad = cn.Query<Cliente>(query, new
        //            {
        //                IdCliente = id
        //            },
        //            commandType: CommandType.StoredProcedure).FirstOrDefault();

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Log(Level.Error, ex.InnerException == null ? ex.Message : ex.InnerException.Message);
        //    }
        //    return entidad;
        //}

        //public Int32 Registrar(ClienteRegistrarDto entidad)
        //{
        //    Int32 respuesta = 0;
        //    try
        //    {
        //        const string query = "Maestro.usp_Cliente_Registrar";
        //        using (var cn = HelperClass.ObtenerConeccion())
        //        {
        //            if (cn.State == ConnectionState.Closed)
        //            {
        //                cn.Open();
        //            }

        //            respuesta = cn.Execute(query, new
        //            {
        //                entidad.NumeroDocumento,
        //                entidad.RazonSocial,
        //                entidad.Direccion,
        //                entidad.IdPais,
        //                entidad.IdUbigeo,
        //                entidad.IdUsuario,
        //                entidad.IdEstado
        //            },
        //            commandType: CommandType.StoredProcedure);

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Log(Level.Error, ex.InnerException == null ? ex.Message : ex.InnerException.Message);
        //    }
        //    return respuesta;
        //}

        //public Int32 Modificar(ClienteModificarDto entidad)
        //{
        //    Int32 respuesta = 0;
        //    try
        //    {
        //        const string query = "Maestro.usp_Cliente_Modificar";
        //        using (var cn = HelperClass.ObtenerConeccion())
        //        {
        //            if (cn.State == ConnectionState.Closed)
        //            {
        //                cn.Open();
        //            }

        //            respuesta = cn.Execute(query, new
        //            {
        //                entidad.IdCliente,
        //                entidad.NumeroDocumento,
        //                entidad.RazonSocial,
        //                entidad.Direccion,
        //                entidad.IdPais,
        //                entidad.IdUbigeo,
        //                entidad.IdUsuario,
        //                entidad.IdEstado
        //            },
        //            commandType: CommandType.StoredProcedure);

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Log(Level.Error, ex.InnerException == null ? ex.Message : ex.InnerException.Message);
        //    }
        //    return respuesta;
        //}

        //public Int32 Eliminar(Int32 id)
        //{
        //    Int32 respuesta = 0;
        //    try
        //    {
        //        const string query = "Maestro.usp_Cliente_Eliminar";
        //        using (var cn = HelperClass.ObtenerConeccion())
        //        {
        //            if (cn.State == ConnectionState.Closed)
        //            {
        //                cn.Open();
        //            }

        //            respuesta = cn.Execute(query, new
        //            {
        //                IdCliente = id
        //            },
        //                commandType: CommandType.StoredProcedure);

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Log(Level.Error, ex.InnerException == null ? ex.Message : ex.InnerException.Message);
        //    }
        //    return respuesta;
        //}
    }
}
