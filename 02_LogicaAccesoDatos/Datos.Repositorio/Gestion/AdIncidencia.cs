using Dapper;
using Datos.Helper;
using Entidad.Configuracion.Proceso;
using Entidad.Dto.Gestion;
using Entidad.Entidad.Gestion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Datos.Repositorio.Gestion
{
    public class AdIncidencia: Logger
    {
        public List<IncidenciaObtenerDto> Obtener()//IncidenciaObtenerFiltroDto filtro)
        {
            List<IncidenciaObtenerDto> resultado = new List<IncidenciaObtenerDto>();
            try
            {
                const string query = "Gestion.usp_Incidencia_Obtener";

                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    resultado = cn.Query<IncidenciaObtenerDto>(query,
                    //    new {
                    //    filtro.IdCliente,
                    //    filtro.Asunto,
                    //    filtro.IdTipoIncidencia,
                    //    filtro.IdPrioridad,
                    //    filtro.IdEstado,
                    //    filtro.FechaInicio,
                    //    filtro.FechaFin,
                    //    NumeroPagina = filtro.NumberPage,
                    //    CantidadRegistros = filtro.Length,
                    //    ColumnaOrden = filtro.ColumnOrder,
                    //    DireccionOrden = filtro.OrderDirection
                    //}, 
                    commandType: CommandType.StoredProcedure).ToList();

                }

            }
            catch (Exception ex)
            {
                Log(Level.Error, (ex.InnerException == null ? ex.Message : ex.InnerException.Message));
            }
            return resultado;
        }

        public List<IncidenciaComboDto> ObtenerCombo()
        {
            List<IncidenciaComboDto> resultado = new List<IncidenciaComboDto>();
            try
            {
                const string query = "Gestion.usp_Incidencia_Combo";

                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    resultado = cn.Query<IncidenciaComboDto>(query, commandType: CommandType.StoredProcedure).ToList();

                }

            }
            catch (Exception ex)
            {
                Log(Level.Error, (ex.InnerException == null ? ex.Message : ex.InnerException.Message));
            }
            return resultado;
        }

        public Incidencia ObtenerPorId(int id)
        {
            Incidencia resultado = new Incidencia();
            try
            {
                const string query = "Gestion.usp_Incidencia_ObtenerPorId";

                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    resultado = cn.QuerySingleOrDefault<Incidencia>(query, new
                    {
                        IdIncidencia = id
                    }, commandType: CommandType.StoredProcedure);

                }

            }
            catch (Exception ex)
            {
                Log(Level.Error, (ex.InnerException == null ? ex.Message : ex.InnerException.Message));
            }
            return resultado;
        }

        public IncidenciaObtenerPorIdDetalladoDto ObtenerPorIdDetallado(int id)
        {
            IncidenciaObtenerPorIdDetalladoDto resultado = new IncidenciaObtenerPorIdDetalladoDto();
            try
            {
                const string query = "Gestion.usp_Incidencia_ObtenerPorId_Detallado";

                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    resultado = cn.QuerySingleOrDefault<IncidenciaObtenerPorIdDetalladoDto>(query, new
                    {
                        IdIncidencia = id
                    }, commandType: CommandType.StoredProcedure);

                }

            }
            catch (Exception ex)
            {
                Log(Level.Error, (ex.InnerException == null ? ex.Message : ex.InnerException.Message));
            }
            return resultado;
        }

        public int Registrar(IncidenciaRegistrarDto modelo, ref int idNuevo)
        {
            int resultado = 0;
            try
            {
                const string query = "Gestion.usp_Incidencia_Registrar";

                var p = new DynamicParameters();
                p.Add("IdIncidencia", 0, DbType.Int32, ParameterDirection.Output);
                p.Add("Descripcion", modelo.IdCliente);
                p.Add("Descripcion", modelo.Asunto);
                p.Add("Descripcion", modelo.IdTipoIncidencia);
                p.Add("Descripcion", modelo.IdPrioridad);
                p.Add("Descripcion", modelo.IdEstado);
                p.Add("Descripcion", modelo.IdUsuarioRegistra);

                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    resultado = cn.Execute(query, commandType: CommandType.StoredProcedure, param: p);

                    idNuevo = p.Get<int>("IdIncidencia");

                }
            }
            catch (Exception ex)
            {
                Log(Level.Error, (ex.InnerException == null ? ex.Message : ex.InnerException.Message));
            }
            return resultado;
        }

        public int Modificar(IncidenciaModificarDto modelo)
        {
            int resultado = 0;
            try
            {
                const string query = "Gestion.usp_Incidencia_Modificar";

                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    resultado = cn.Execute(query, new
                    {
                        modelo.IdIncidencia,
                        modelo.IdCliente,
                        modelo.Asunto,
                        modelo.IdTipoIncidencia,
                        modelo.IdPrioridad,
                        modelo.IdEstado,
                        modelo.IdUsuarioRegistra
                    }, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception ex)
            {
                Log(Level.Error, (ex.InnerException == null ? ex.Message : ex.InnerException.Message));
            }
            return resultado;
        }

        public int ModificarEstado(IncidenciaModificarEstadoDto modelo)
        {
            int resultado = 0;
            try
            {
                const string query = "Gestion.usp_Incidencia_ModificarEstado";

                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    resultado = cn.Execute(query, new
                    {
                        modelo.IdIncidencia,
                        modelo.IdEstado,
                        modelo.IdUsuario,
                        modelo.Finalizado
                    }, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception ex)
            {
                Log(Level.Error, (ex.InnerException == null ? ex.Message : ex.InnerException.Message));
            }
            return resultado;
        }

        public int Eliminar(int id)
        {
            int resultado = 0;
            try
            {
                const string query = "Gestion.usp_Incidencia_Eliminar";

                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    resultado = cn.Execute(query, new
                    {
                        IdIncidencia = id,
                    }, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception ex)
            {
                Log(Level.Error, (ex.InnerException == null ? ex.Message : ex.InnerException.Message));
            }
            return resultado;
        }
    }
}
