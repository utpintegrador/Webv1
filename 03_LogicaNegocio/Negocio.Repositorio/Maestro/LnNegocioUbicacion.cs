using Entidad.Configuracion.Proceso;
using Entidad.Dto.Comun;
using ModelosApi.Dto.Maestro;
using ModelosApi.Request.Maestro;
using Entidad.Vo;
using ModelosApi.Response.Comun;
using ModelosApi.Response.Maestro;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Entidad.Dto.Maestro;

namespace Negocio.Repositorio.Maestro
{
    public class LnNegocioUbicacion: Logger
    {
        private readonly string _nombreControlador = "NegocioUbicacion";

        public async Task<ResultDataTable> ObtenerPorIdNegocio(NegocioUbicacionObtenerPorIdNegocioFiltroDto prm)
        {
            ResultDataTable resultado = new ResultDataTable();
            long totalRegistros = 0;
            List<NegocioUbicacionObtenerPorIdNegocioDtoApi> lista = new List<NegocioUbicacionObtenerPorIdNegocioDtoApi>();
            int statusCode = 0;
            try
            {
                //Dentro de AJAX => datatype: 'json', headers: {'Authorization': 'Basic ' + valor token }, ....
                RequestNegocioUbicacionObtenerPorIdNegocioDtoApi filtroApi = new RequestNegocioUbicacionObtenerPorIdNegocioDtoApi
                {
                    IdNegocio = prm.IdNegocio,
                    Buscar = string.IsNullOrEmpty(prm.Buscar) ? string.Empty : prm.Buscar
                };

                if (prm.Start == null) prm.Start = 0;
                filtroApi.CantidadRegistros = prm.Length == null ? 10 : Convert.ToInt32(prm.Length);
                filtroApi.NumeroPagina = (Convert.ToInt32(prm.Start) / filtroApi.CantidadRegistros) + 1;
                if (prm.Order != null && prm.Order.Count > 0)
                {
                    filtroApi.ColumnaOrden = prm.Columns[prm.Order[0].Column].Name;
                    filtroApi.DireccionOrden = prm.Order[0].Dir;
                }

                var response = string.Empty;
                string url = string.Format("{0}{1}/ObtenerPorIdNegocio", ConstanteVo.UrlBaseApi, _nombreControlador);

                using (var client = new HttpClient())
                {
                    if (ConstanteVo.ActivarLLamadasConToken && !string.IsNullOrEmpty(ConfiguracionToken.ConfigToken))
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ConfiguracionToken.ConfigToken.Trim());
                    }

                    var content = new StringContent(JsonConvert.SerializeObject(filtroApi), Encoding.UTF8, "application/json");
                    HttpResponseMessage result = await client.PostAsync(new Uri(url), content);
                    if (result != null)
                    {
                        response = await result.Content.ReadAsStringAsync();
                        statusCode = (int)result.StatusCode;
                    }
                }

                ResponseNegocioUbicacionObtenerPorIdNegocioDtoApi root = JsonConvert.DeserializeObject<ResponseNegocioUbicacionObtenerPorIdNegocioDtoApi>(response);
                if (root != null && root.Cuerpo != null)
                {
                    lista = root.Cuerpo;
                    totalRegistros = root.CantidadTotalRegistros;
                    if (lista.Any())
                    {
                        int indice = Convert.ToInt32(prm.Start) + 1;
                        foreach (var item in lista)
                        {
                            item.Item = indice;
                            indice++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string exMessage = (ex.InnerException == null ? ex.Message : ex.InnerException.Message).Replace(Environment.NewLine, " ");
                Log(Level.Error, exMessage);
                resultado.error = exMessage;
            }
            finally
            {
                resultado.data = lista;
                resultado.draw = prm.Draw;
                resultado.recordsTotal = (int)totalRegistros;
                resultado.recordsFiltered = (int)totalRegistros;
                if (resultado != null)
                {
                    resultado.StatusCode = statusCode;
                }
            }
            
            return resultado;

        }

        public async Task<ResultDataTable> ObtenerPorIdUsuario(NegocioUbicacionObtenerPorIdUsuarioFiltroDto prm)
        {
            ResultDataTable resultado = new ResultDataTable();
            long totalRegistros = 0;
            List<NegocioUbicacionObtenerPorIdUsuarioDtoApi> lista = new List<NegocioUbicacionObtenerPorIdUsuarioDtoApi>();
            int statusCode = 0;
            try
            {
                //Dentro de AJAX => datatype: 'json', headers: {'Authorization': 'Basic ' + valor token }, ....
                RequestNegocioUbicacionObtenerPorIdUsuarioDtoApi filtroApi = new RequestNegocioUbicacionObtenerPorIdUsuarioDtoApi
                {
                    IdUsuario = prm.IdUsuario,
                    IdNegocio = prm.IdNegocio,
                    Buscar = string.IsNullOrEmpty(prm.Buscar) ? string.Empty : prm.Buscar
                };

                if (prm.Start == null) prm.Start = 0;
                filtroApi.CantidadRegistros = prm.Length == null ? 10 : Convert.ToInt32(prm.Length);
                filtroApi.NumeroPagina = (Convert.ToInt32(prm.Start) / filtroApi.CantidadRegistros) + 1;
                if (prm.Order != null && prm.Order.Count > 0)
                {
                    filtroApi.ColumnaOrden = prm.Columns[prm.Order[0].Column].Name;
                    filtroApi.DireccionOrden = prm.Order[0].Dir;
                }

                var response = string.Empty;
                string url = string.Format("{0}{1}/ObtenerPorIdUsuario", ConstanteVo.UrlBaseApi, _nombreControlador);

                using (var client = new HttpClient())
                {
                    if (ConstanteVo.ActivarLLamadasConToken && !string.IsNullOrEmpty(ConfiguracionToken.ConfigToken))
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ConfiguracionToken.ConfigToken.Trim());
                    }

                    var content = new StringContent(JsonConvert.SerializeObject(filtroApi), Encoding.UTF8, "application/json");
                    HttpResponseMessage result = await client.PostAsync(new Uri(url), content);
                    if (result != null)
                    {
                        response = await result.Content.ReadAsStringAsync();
                        statusCode = (int)result.StatusCode;
                    }
                }

                ResponseNegocioUbicacionObtenerPorIdUsuarioDtoApi root = JsonConvert.DeserializeObject<ResponseNegocioUbicacionObtenerPorIdUsuarioDtoApi>(response);
                if (root != null && root.Cuerpo != null)
                {
                    lista = root.Cuerpo;
                    totalRegistros = root.CantidadTotalRegistros;
                    if (lista.Any())
                    {
                        int indice = Convert.ToInt32(prm.Start) + 1;
                        foreach (var item in lista)
                        {
                            item.Item = indice;
                            indice++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string exMessage = (ex.InnerException == null ? ex.Message : ex.InnerException.Message).Replace(Environment.NewLine, " ");
                Log(Level.Error, exMessage);
                resultado.error = exMessage;
            }
            finally
            {
                resultado.data = lista;
                resultado.draw = prm.Draw;
                resultado.recordsTotal = (int)totalRegistros;
                resultado.recordsFiltered = (int)totalRegistros;
                if (resultado != null)
                {
                    resultado.StatusCode = statusCode;
                }
            }

            return resultado;

        }

        public async Task<ResponseNegocioUbicacionObtenerPorIdDtoApi> ObtenerPorId(long id)
        {
            ResponseNegocioUbicacionObtenerPorIdDtoApi resultado = new ResponseNegocioUbicacionObtenerPorIdDtoApi();
            int statusCode = 0;
            try
            {
                var response = string.Empty;
                string url = string.Format("{0}{1}/{2}", ConstanteVo.UrlBaseApi, _nombreControlador, id);

                using (var client = new HttpClient())
                {
                    if (ConstanteVo.ActivarLLamadasConToken && !string.IsNullOrEmpty(ConfiguracionToken.ConfigToken))
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ConfiguracionToken.ConfigToken.Trim());
                    }

                    HttpResponseMessage result = await client.GetAsync(new Uri(url));
                    if (result != null)
                    {
                        response = await result.Content.ReadAsStringAsync();
                        statusCode = (int)result.StatusCode;
                    }
                }

                if (!string.IsNullOrEmpty(response))
                {
                    resultado = new ResponseNegocioUbicacionObtenerPorIdDtoApi();
                    resultado = JsonConvert.DeserializeObject<ResponseNegocioUbicacionObtenerPorIdDtoApi>(response);
                }
            }
            catch (Exception ex)
            {
                if (resultado == null) resultado = new ResponseNegocioUbicacionObtenerPorIdDtoApi();
                if (resultado.ListaError == null) resultado.ListaError = new List<ErrorDtoApi>();

                string exMessage = (ex.InnerException == null ? ex.Message : ex.InnerException.Message).Replace(Environment.NewLine, " ");
                Log(Level.Error, exMessage);
                resultado.ListaError.Add(new ErrorDtoApi
                {
                    Mensaje = exMessage
                });
            }
            finally
            {
                if (resultado != null)
                {
                    resultado.StatusCode = statusCode;
                }
            }

            return resultado;
        }

        public async Task<ResponseNegocioUbicacionEliminarDtoApi> Eliminar(long id)
        {
            ResponseNegocioUbicacionEliminarDtoApi resultado = new ResponseNegocioUbicacionEliminarDtoApi();
            int statusCode = 0;
            try
            {
                var response = string.Empty;
                string url = string.Format("{0}{1}/{2}", ConstanteVo.UrlBaseApi, _nombreControlador, id);

                using (var client = new HttpClient())
                {
                    if (ConstanteVo.ActivarLLamadasConToken && !string.IsNullOrEmpty(ConfiguracionToken.ConfigToken))
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ConfiguracionToken.ConfigToken.Trim());
                    }

                    HttpResponseMessage result = await client.DeleteAsync(new Uri(url));
                    if (result != null)
                    {
                        response = await result.Content.ReadAsStringAsync();
                        statusCode = (int)result.StatusCode;
                    }
                }

                if (!string.IsNullOrEmpty(response))
                {
                    resultado = new ResponseNegocioUbicacionEliminarDtoApi();
                    resultado = JsonConvert.DeserializeObject<ResponseNegocioUbicacionEliminarDtoApi>(response);
                }
            }
            catch (Exception ex)
            {
                if (resultado == null) resultado = new ResponseNegocioUbicacionEliminarDtoApi();
                if (resultado.ListaError == null) resultado.ListaError = new List<ErrorDtoApi>();

                string exMessage = (ex.InnerException == null ? ex.Message : ex.InnerException.Message).Replace(Environment.NewLine, " ");
                Log(Level.Error, exMessage);
                resultado.ListaError.Add(new ErrorDtoApi
                {
                    Mensaje = exMessage
                });
            }
            finally
            {
                if (resultado != null)
                {
                    resultado.StatusCode = statusCode;
                }
            }

            return resultado;
        }

        public async Task<ResponseNegocioUbicacionModificarDtoApi> Modificar(RequestNegocioUbicacionModificarDtoApi prm)
        {
            ResponseNegocioUbicacionModificarDtoApi resultado = new ResponseNegocioUbicacionModificarDtoApi();
            int statusCode = 0;
            try
            {
                //Dentro de AJAX => datatype: 'json', headers: {'Authorization': 'Basic ' + valor token }, ....
                var response = string.Empty;
                string url = string.Format("{0}{1}", ConstanteVo.UrlBaseApi, _nombreControlador);

                using (var client = new HttpClient())
                {
                    if (ConstanteVo.ActivarLLamadasConToken && !string.IsNullOrEmpty(ConfiguracionToken.ConfigToken))
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ConfiguracionToken.ConfigToken.Trim());
                    }

                    var content = new StringContent(JsonConvert.SerializeObject(prm), Encoding.UTF8, "application/json");
                    HttpResponseMessage result = await client.PutAsync(new Uri(url), content);
                    if (result != null)
                    {
                        response = await result.Content.ReadAsStringAsync();
                        statusCode = (int)result.StatusCode;
                    }
                }

                if (!string.IsNullOrEmpty(response))
                {
                    resultado = new ResponseNegocioUbicacionModificarDtoApi();
                    resultado = JsonConvert.DeserializeObject<ResponseNegocioUbicacionModificarDtoApi>(response);
                }
            }
            catch (Exception ex)
            {
                if (resultado == null) resultado = new ResponseNegocioUbicacionModificarDtoApi();
                if (resultado.ListaError == null) resultado.ListaError = new List<ErrorDtoApi>();

                string exMessage = (ex.InnerException == null ? ex.Message : ex.InnerException.Message).Replace(Environment.NewLine, " ");
                Log(Level.Error, exMessage);
                resultado.ListaError.Add(new ErrorDtoApi
                {
                    Mensaje = exMessage
                });
            }
            finally
            {
                if (resultado != null)
                {
                    resultado.StatusCode = statusCode;
                }
            }

            return resultado;

        }

        public async Task<ResponseNegocioUbicacionRegistrarDtoApi> Registrar(RequestNegocioUbicacionRegistrarDtoApi prm)
        {
            ResponseNegocioUbicacionRegistrarDtoApi resultado = new ResponseNegocioUbicacionRegistrarDtoApi();
            int statusCode = 0;
            try
            {
                //Dentro de AJAX => datatype: 'json', headers: {'Authorization': 'Basic ' + valor token }, ....
                var response = string.Empty;
                string url = string.Format("{0}{1}", ConstanteVo.UrlBaseApi, _nombreControlador);

                using (var client = new HttpClient())
                {
                    if (ConstanteVo.ActivarLLamadasConToken && !string.IsNullOrEmpty(ConfiguracionToken.ConfigToken))
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ConfiguracionToken.ConfigToken.Trim());
                    }

                    var content = new StringContent(JsonConvert.SerializeObject(prm), Encoding.UTF8, "application/json");
                    HttpResponseMessage result = await client.PostAsync(new Uri(url), content);
                    if (result != null)
                    {
                        response = await result.Content.ReadAsStringAsync();
                        statusCode = (int)result.StatusCode;
                    }
                }

                if (!string.IsNullOrEmpty(response))
                {
                    resultado = new ResponseNegocioUbicacionRegistrarDtoApi();
                    resultado = JsonConvert.DeserializeObject<ResponseNegocioUbicacionRegistrarDtoApi>(response);
                }
            }
            catch (Exception ex)
            {
                if (resultado == null) resultado = new ResponseNegocioUbicacionRegistrarDtoApi();
                if (resultado.ListaError == null) resultado.ListaError = new List<ErrorDtoApi>();

                string exMessage = (ex.InnerException == null ? ex.Message : ex.InnerException.Message).Replace(Environment.NewLine, " ");
                Log(Level.Error, exMessage);
                resultado.ListaError.Add(new ErrorDtoApi
                {
                    Mensaje = exMessage
                });
            }
            finally
            {
                if (resultado != null)
                {
                    resultado.StatusCode = statusCode;
                }
            }

            return resultado;

        }

    }
}
