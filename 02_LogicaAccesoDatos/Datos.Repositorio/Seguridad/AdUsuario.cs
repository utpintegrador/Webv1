﻿using Datos.Repositorio.Helper;
using Entidad.Configuracion.Proceso;
using Entidad.Dto.Maestro;
using Entidad.Entidad.Maestro;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Datos.Repositorio.Seguridad
{
    public class AdUsuario : Logger
    {
        //public AdUsuario()
        //{
            
        //}
        //public async Task<EstadoObtenerRootDto> Obtener()
        //{
        //    ApiHelper.InitializeClient();
        //    string url = "http://localhost:6935/api/Estado";
        //    using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
        //    {
        //        if (response.IsSuccessStatusCode)
        //        {
        //            EstadoObtenerRootDto estado = await response.Content.ReadAsAsync<EstadoObtenerRootDto>();
        //            return estado;
        //        }
        //        else
        //        {
        //            throw new Exception(response.ReasonPhrase);
        //        }
        //    }
        //}

        //private readonly ApiHelper _apiHelper = new ApiHelper();
        //public async Task<HttpResponseMessage> Obtener(string contenido)
        //{
        //    try
        //    {
        //        using (var httpClient = new HttpClient())
        //        {
        //            var response = await httpClient.PostAsync("http://localhost:6935/api/Usuario/Obtener", new StringContent(contenido, System.Text.Encoding.UTF8, "application/json"));
        //            response.EnsureSuccessStatusCode();
        //            return response;
        //        }

        //var httpClient = new HttpClient();
        //var response = await httpClient.PostAsync("http://localhost:6935/api/Usuario/Obtener", new StringContent(contenido, System.Text.Encoding.UTF8, "application/json"));
        //return response;

        //}
        //catch (Exception ex)
        //{
        //    Log(Level.Error, ex.InnerException == null ? ex.Message : ex.InnerException.Message);
        //}
        //return null;

        //var response = string.Empty;
        //try
        //{
        //    HttpClient cliente = _apiHelper.Initial();
        //    //HttpResponseMessage result = await cliente.PostAsync("Usuario/Obtener", content);
        //    HttpResponseMessage result = await cliente.PostAsync("Usuario/Obtener", content);
        //    if (result.IsSuccessStatusCode)
        //    {
        //        response = result.Content.ReadAsStringAsync().Result;
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Log(Level.Error, ex.InnerException == null ? ex.Message : ex.InnerException.Message);
        //}

        //return response;
        //}

        //public List<UsuarioObtenerDto> Obtener(UsuarioObtenerFiltroDto filtro)
        //{
        //    List<UsuarioObtenerDto> resultado = new List<UsuarioObtenerDto>();
        //    try
        //    {
        //        const string query = "Seguridad.usp_Usuario_Obtener";

        //        using (var cn = HelperClass.ObtenerConeccion())
        //        {
        //            if (cn.State == ConnectionState.Closed)
        //            {
        //                cn.Open();
        //            }

        //            resultado = cn.Query<UsuarioObtenerDto>(query,new {
        //                filtro.Buscar,
        //                filtro.IdEstado,
        //                NumeroPagina = filtro.NumberPage,
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

        //public Usuario ObtenerPorId(long id)
        //{
        //    Usuario resultado = new Usuario();
        //    try
        //    {
        //        const string query = "Seguridad.usp_Usuario_ObtenerPorId";

        //        using (var cn = HelperClass.ObtenerConeccion())
        //        {
        //            if (cn.State == ConnectionState.Closed)
        //            {
        //                cn.Open();
        //            }

        //            resultado = cn.QuerySingleOrDefault<Usuario>(query, new
        //            {
        //                IdUsuario = id
        //            }, commandType: CommandType.StoredProcedure);

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Log(Level.Error, (ex.InnerException == null ? ex.Message : ex.InnerException.Message));
        //    }
        //    return resultado;
        //}

        //public int Registrar(UsuarioRegistrarDto modelo)
        //{
        //    int resultado = 0;
        //    try
        //    {
        //        const string query = "Seguridad.usp_Usuario_Registrar";

        //        var p = new DynamicParameters();
        //        //p.Add("IdUsuario", 0, DbType.Int32, ParameterDirection.Output);
        //        p.Add("UserName", modelo.UserName);
        //        p.Add("Contrasenia", modelo.Contrasenia);
        //        p.Add("Nombre", modelo.Nombre);
        //        p.Add("ApellidoPaterno", modelo.ApellidoPaterno);
        //        p.Add("ApellidoMaterno", modelo.ApellidoMaterno);
        //        p.Add("IdEstado", modelo.IdEstado);

        //        using (var cn = HelperClass.ObtenerConeccion())
        //        {
        //            if (cn.State == ConnectionState.Closed)
        //            {
        //                cn.Open();
        //            }

        //            resultado = cn.Execute(query, commandType: CommandType.StoredProcedure, param: p);

        //            //idNuevo = p.Get<int>("IdUsuario");

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log(Level.Error, (ex.InnerException == null ? ex.Message : ex.InnerException.Message));
        //    }
        //    return resultado;
        //}

        //public int Modificar(UsuarioModificarDto modelo)
        //{
        //    int resultado = 0;
        //    try
        //    {
        //        const string query = "Seguridad.usp_Usuario_Modificar";

        //        using (var cn = HelperClass.ObtenerConeccion())
        //        {
        //            if (cn.State == ConnectionState.Closed)
        //            {
        //                cn.Open();
        //            }

        //            resultado = cn.Execute(query, new
        //            {
        //                modelo.IdUsuario,
        //                modelo.UserName,
        //                modelo.Contrasenia,
        //                modelo.Nombre,
        //                modelo.ApellidoPaterno,
        //                modelo.ApellidoMaterno,
        //                modelo.IdEstado//desconectarse o inactivarse
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
        //        const string query = "Seguridad.usp_Usuario_Eliminar";

        //        using (var cn = HelperClass.ObtenerConeccion())
        //        {
        //            if (cn.State == ConnectionState.Closed)
        //            {
        //                cn.Open();
        //            }

        //            resultado = cn.Execute(query, new
        //            {
        //                IdUsuario = id,
        //            }, commandType: CommandType.StoredProcedure);

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log(Level.Error, (ex.InnerException == null ? ex.Message : ex.InnerException.Message));
        //    }
        //    return resultado;
        //}

        //public List<UsuarioObtenerComboDto> ObtenerCombo(int idEstado)
        //{
        //    List<UsuarioObtenerComboDto> resultado = new List<UsuarioObtenerComboDto>();
        //    try
        //    {
        //        const string query = "Seguridad.usp_Usuario_Combo";

        //        using (var cn = HelperClass.ObtenerConeccion())
        //        {
        //            if (cn.State == ConnectionState.Closed)
        //            {
        //                cn.Open();
        //            }

        //            resultado = cn.Query<UsuarioObtenerComboDto>(query,new {
        //                IdEstado = idEstado
        //            }, commandType: CommandType.StoredProcedure).ToList();

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Log(Level.Error, (ex.InnerException == null ? ex.Message : ex.InnerException.Message));
        //    }
        //    return resultado;
        //}

        //public UsuarioLoginDto ObtenerPorLogin(UsuarioCredencialesDto modelo)
        //{
        //    UsuarioLoginDto resultado = new UsuarioLoginDto();
        //    try
        //    {
        //        const string query = "Seguridad.usp_Usuario_ObtenerPorLogeo";

        //        using (var cn = HelperClass.ObtenerConeccion())
        //        {
        //            if (cn.State == ConnectionState.Closed)
        //            {
        //                cn.Open();
        //            }

        //            /*los alias en el parametro son opcionales si la propiedad del modelo tiene la misma denominacion*/
        //            resultado = cn.QuerySingleOrDefault<UsuarioLoginDto>(query, new
        //            {
        //                UserName = modelo.Usuario,
        //                modelo.Contrasenia
        //            }, commandType: CommandType.StoredProcedure);

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Log(Level.Error, (ex.InnerException == null ? ex.Message : ex.InnerException.Message));
        //    }
        //    return resultado;
        //}

        //public int ModificarContrasenia(UsuarioCambioContraseniaDto modelo)
        //{
        //    int resultado = 0;
        //    try
        //    {
        //        const string query = "Seguridad.usp_Usuario_ModificarContrasenia";

        //        using (var cn = HelperClass.ObtenerConeccion())
        //        {
        //            if (cn.State == ConnectionState.Closed)
        //            {
        //                cn.Open();
        //            }

        //            resultado = cn.Execute(query, new
        //            {
        //                modelo.IdUsuario,
        //                modelo.Contrasenia
        //            }, commandType: CommandType.StoredProcedure);

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
