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
    public class LnTipoDescuento: Logger
    {
        private readonly string _nombreControlador = "TipoDescuento";
        public async Task<ResultDataTable> Obtener(TipoDescuentoObtenerFiltroDto prm)
        {
            ResultDataTable resultado = new ResultDataTable();
            long totalRegistros = 0;
            List<TipoDescuentoObtenerDtoApi> lista = new List<TipoDescuentoObtenerDtoApi>();
            int statusCode = 0;
            try
            {
                //Dentro de AJAX => datatype: 'json', headers: {'Authorization': 'Basic ' + valor token }, ....
                RequestTipoDescuentoObtenerDtoApi filtroApi = new RequestTipoDescuentoObtenerDtoApi
                {
                    Buscar = string.IsNullOrEmpty(prm.Buscar) ? string.Empty : prm.Buscar,
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
                string url = string.Format("{0}{1}/Obtener", ConstanteVo.UrlBaseApi, _nombreControlador);

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

                ResponseTipoDescuentoObtenerDtoApi root = JsonConvert.DeserializeObject<ResponseTipoDescuentoObtenerDtoApi>(response);
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

        public async Task<ResponseTipoDescuentoObtenerPorIdDtoApi> ObtenerPorId(int id)
        {
            ResponseTipoDescuentoObtenerPorIdDtoApi resultado = new ResponseTipoDescuentoObtenerPorIdDtoApi();
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
                    resultado = new ResponseTipoDescuentoObtenerPorIdDtoApi();
                    resultado = JsonConvert.DeserializeObject<ResponseTipoDescuentoObtenerPorIdDtoApi>(response);
                }
            }
            catch (Exception ex)
            {
                if (resultado == null) resultado = new ResponseTipoDescuentoObtenerPorIdDtoApi();
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

        public async Task<ResponseTipoDescuentoModificarDtoApi> Modificar(RequestTipoDescuentoModificarDtoApi prm)
        {
            ResponseTipoDescuentoModificarDtoApi resultado = new ResponseTipoDescuentoModificarDtoApi();
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
                    resultado = new ResponseTipoDescuentoModificarDtoApi();
                    resultado = JsonConvert.DeserializeObject<ResponseTipoDescuentoModificarDtoApi>(response);
                }
            }
            catch (Exception ex)
            {
                if (resultado == null) resultado = new ResponseTipoDescuentoModificarDtoApi();
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

        public async Task<ResponseTipoDescuentoRegistrarDtoApi> Registrar(RequestTipoDescuentoRegistrarDtoApi prm)
        {
            ResponseTipoDescuentoRegistrarDtoApi resultado = new ResponseTipoDescuentoRegistrarDtoApi();
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
                    resultado = new ResponseTipoDescuentoRegistrarDtoApi();
                    resultado = JsonConvert.DeserializeObject<ResponseTipoDescuentoRegistrarDtoApi>(response);
                }
            }
            catch (Exception ex)
            {
                if (resultado == null) resultado = new ResponseTipoDescuentoRegistrarDtoApi();
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

        public async Task<ResponseTipoDescuentoEliminarDtoApi> Eliminar(int id)
        {
            ResponseTipoDescuentoEliminarDtoApi resultado = new ResponseTipoDescuentoEliminarDtoApi();
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
                    resultado = new ResponseTipoDescuentoEliminarDtoApi();
                    resultado = JsonConvert.DeserializeObject<ResponseTipoDescuentoEliminarDtoApi>(response);
                }
            }
            catch (Exception ex)
            {
                if (resultado == null) resultado = new ResponseTipoDescuentoEliminarDtoApi();
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

        public async Task<ResponseTipoDescuentoObtenerComboDtoApi> ObtenerCombo()
        {
            ResponseTipoDescuentoObtenerComboDtoApi resultado = new ResponseTipoDescuentoObtenerComboDtoApi();
            int statusCode = 0;
            try
            {
                //Dentro de AJAX => datatype: 'json', headers: {'Authorization': 'Basic ' + valor token }, ....

                var response = string.Empty;
                string url = string.Format("{0}{1}/ObtenerCombo", ConstanteVo.UrlBaseApi, _nombreControlador);

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
                    resultado = JsonConvert.DeserializeObject<ResponseTipoDescuentoObtenerComboDtoApi>(response);
                }
            }
            catch (Exception ex)
            {
                string exMessage = (ex.InnerException == null ? ex.Message : ex.InnerException.Message).Replace(Environment.NewLine, " ");
                Log(Level.Error, exMessage);
                if (resultado.ListaError == null) resultado.ListaError = new List<ErrorDtoApi>();
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
