using Dapper;
using Datos.Helper;
using Entidad.Configuracion.Proceso;
using Entidad.Dto.Gestion;
using Entidad.Entidad.Gestion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Datos.Repositorio.Gestion
{
    public class AdIncidenciaDetalle:Logger
    {
        public List<IncidenciaDetalleObtenerDto> Obtener(IncidenciaDetalleFiltroDto filtro)
        {

            List<IncidenciaDetalleObtenerDto> lista = new List<IncidenciaDetalleObtenerDto>();

            try
            {
                const string query = "Gestion.usp_IncidenciaDetalle_Obtener";
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    lista = cn.Query<IncidenciaDetalleObtenerDto>(query, new
                    {
                        filtro.IdIncidencia,
                        filtro.Descripcion,
                        NumeroPagina = filtro.NumberPage,
                        CantidadRegistros = filtro.Length,
                        ColumnaOrden = filtro.ColumnOrder,
                        DireccionOrden = filtro.OrderDirection
                    },
                        commandType: CommandType.StoredProcedure).ToList();

                }

            }
            catch (Exception ex)
            {
                Log(Level.Error, ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
            return lista;
        }

        public IncidenciaDetalle ObtenerPorId(int id)
        {

            IncidenciaDetalle entidad = new IncidenciaDetalle();

            try
            {
                const string query = "Gestion.usp_IncidenciaDetalle_ObtenerPorId";
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    entidad = cn.Query<IncidenciaDetalle>(query, new
                    {
                        IdIncidenciaDetalle = id
                    },
                        commandType: CommandType.StoredProcedure).FirstOrDefault();

                }

            }
            catch (Exception ex)
            {
                Log(Level.Error, ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
            return entidad;
        }

        public Int32 Registrar(IncidenciaDetalleRegistrarDto entidad)
        {
            Int32 respuesta = 0;
            try
            {
                const string query = "Gestion.usp_IncidenciaDetalle_Registrar";
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    respuesta = cn.Execute(query, new
                    {
                        entidad.IdIncidencia,
                        entidad.IdArea,
                        entidad.Descripcion,
                        entidad.IdUsuario
                    },
                        commandType: CommandType.StoredProcedure);

                }

            }
            catch (Exception ex)
            {
                Log(Level.Error, ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
            return respuesta;
        }

        public Int32 Modificar(IncidenciaDetalleModificarDto entidad)
        {
            Int32 respuesta = 0;
            try
            {
                const string query = "Gestion.usp_IncidenciaDetalle_Modificar";
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    respuesta = cn.Execute(query, new
                    {
                        entidad.IdIncidenciaDetalle,
                        entidad.IdIncidencia,
                        entidad.IdArea,
                        entidad.Descripcion,
                        entidad.IdUsuario
                    },
                        commandType: CommandType.StoredProcedure);

                }

            }
            catch (Exception ex)
            {
                Log(Level.Error, ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
            return respuesta;
        }

        public Int32 Eliminar(Int32 id)
        {
            Int32 respuesta = 0;
            try
            {
                const string query = "Gestion.usp_IncidenciaDetalle_Eliminar";
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    respuesta = cn.Execute(query, new
                    {
                        IdIncidenciaDetalle = id
                    },
                        commandType: CommandType.StoredProcedure);

                }

            }
            catch (Exception ex)
            {
                Log(Level.Error, ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
            return respuesta;
        }

        public List<IncidenciaDetalleObtenerDto> ObtenerHistorial(IncidenciaDetalleObtenerHistorialFiltroDto filtro)
        {

            List<IncidenciaDetalleObtenerDto> lista = new List<IncidenciaDetalleObtenerDto>();

            try
            {
                const string query = "Gestion.usp_IncidenciaDetalle_ObtenerHistorial";
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    lista = cn.Query<IncidenciaDetalleObtenerDto>(query, new
                    {
                        filtro.IdIncidencia,
                        filtro.IdIncidenciaDetalle
                    },
                        commandType: CommandType.StoredProcedure).ToList();

                }

            }
            catch (Exception ex)
            {
                Log(Level.Error, ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
            return lista;
        }
    }
}
