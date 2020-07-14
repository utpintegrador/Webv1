using Entidad.Configuracion.Proceso;
using Entidad.Dto.Comun;
using Entidad.Dto.Maestro;
using Entidad.Request.Maestro;
using Entidad.Vo;
using ModelosApi.Dto.Maestro;
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

namespace Negocio.Repositorio.Maestro
{
    public class LnTipoDocumentoIdentificacion: Logger
    {
        private readonly string _nombreControlador = "TipoDocumentoIdentificacion";
        public async Task<ResultDataTable> Obtener(TipoDocumentoIdentificacionObtenerFiltroDto prm)
        {
            ResultDataTable respuesta = new ResultDataTable();
            long totalRegistros = 0;
            List<TipoDocumentoIdentificacionObtenerDtoApi> lista = new List<TipoDocumentoIdentificacionObtenerDtoApi>();

            try
            {
                //Dentro de AJAX => datatype: 'json', headers: {'Authorization': 'Basic ' + valor token }, ....
                RequestTipoDocumentoIdentificacionObtenerDtoApi filtroApi = new RequestTipoDocumentoIdentificacionObtenerDtoApi
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
                    if (result.IsSuccessStatusCode)
                    {
                        response = await result.Content.ReadAsStringAsync();
                    }
                }

                ResponseTipoDocumentoIdentificacionObtenerDtoApi root = JsonConvert.DeserializeObject<ResponseTipoDocumentoIdentificacionObtenerDtoApi>(response);
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
                respuesta.error = exMessage;
            }
            finally
            {
                respuesta.data = lista;
                respuesta.draw = prm.Draw;
                respuesta.recordsTotal = (int)totalRegistros;
                respuesta.recordsFiltered = (int)totalRegistros;
            }

            return respuesta;

        }

        public async Task<ResponseTipoDocumentoIdentificacionObtenerPorIdDtoApi> ObtenerPorId(int id)
        {
            ResponseTipoDocumentoIdentificacionObtenerPorIdDtoApi resultado = new ResponseTipoDocumentoIdentificacionObtenerPorIdDtoApi();
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
                    if (result.IsSuccessStatusCode)
                    {
                        response = await result.Content.ReadAsStringAsync();
                    }
                }

                if (!string.IsNullOrEmpty(response))
                {
                    resultado = new ResponseTipoDocumentoIdentificacionObtenerPorIdDtoApi();
                    resultado = JsonConvert.DeserializeObject<ResponseTipoDocumentoIdentificacionObtenerPorIdDtoApi>(response);
                }
            }
            catch (Exception ex)
            {
                if (resultado == null) resultado = new ResponseTipoDocumentoIdentificacionObtenerPorIdDtoApi();
                if (resultado.ListaError == null) resultado.ListaError = new List<ErrorDtoApi>();

                string exMessage = (ex.InnerException == null ? ex.Message : ex.InnerException.Message).Replace(Environment.NewLine, " ");
                Log(Level.Error, exMessage);
                resultado.ListaError.Add(new ErrorDtoApi
                {
                    Mensaje = exMessage
                });
            }

            return resultado;
        }

        public async Task<ResponseTipoDocumentoIdentificacionModificarDtoApi> Modificar(RequestTipoDocumentoIdentificacionModificarDtoApi prm)
        {
            ResponseTipoDocumentoIdentificacionModificarDtoApi resultado = new ResponseTipoDocumentoIdentificacionModificarDtoApi();

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
                    if (result.IsSuccessStatusCode)
                    {
                        response = await result.Content.ReadAsStringAsync();
                    }
                }

                if (!string.IsNullOrEmpty(response))
                {
                    resultado = new ResponseTipoDocumentoIdentificacionModificarDtoApi();
                    resultado = JsonConvert.DeserializeObject<ResponseTipoDocumentoIdentificacionModificarDtoApi>(response);
                }
            }
            catch (Exception ex)
            {
                if (resultado == null) resultado = new ResponseTipoDocumentoIdentificacionModificarDtoApi();
                if (resultado.ListaError == null) resultado.ListaError = new List<ErrorDtoApi>();

                string exMessage = (ex.InnerException == null ? ex.Message : ex.InnerException.Message).Replace(Environment.NewLine, " ");
                Log(Level.Error, exMessage);
                resultado.ListaError.Add(new ErrorDtoApi
                {
                    Mensaje = exMessage
                });
            }

            return resultado;

        }

        public async Task<ResponseTipoDocumentoIdentificacionRegistrarDtoApi> Registrar(RequestTipoDocumentoIdentificacionRegistrarDtoApi prm)
        {
            ResponseTipoDocumentoIdentificacionRegistrarDtoApi resultado = new ResponseTipoDocumentoIdentificacionRegistrarDtoApi();

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
                    if (result.IsSuccessStatusCode)
                    {
                        response = await result.Content.ReadAsStringAsync();
                    }
                }

                if (!string.IsNullOrEmpty(response))
                {
                    resultado = new ResponseTipoDocumentoIdentificacionRegistrarDtoApi();
                    resultado = JsonConvert.DeserializeObject<ResponseTipoDocumentoIdentificacionRegistrarDtoApi>(response);
                }
            }
            catch (Exception ex)
            {
                if (resultado == null) resultado = new ResponseTipoDocumentoIdentificacionRegistrarDtoApi();
                if (resultado.ListaError == null) resultado.ListaError = new List<ErrorDtoApi>();

                string exMessage = (ex.InnerException == null ? ex.Message : ex.InnerException.Message).Replace(Environment.NewLine, " ");
                Log(Level.Error, exMessage);
                resultado.ListaError.Add(new ErrorDtoApi
                {
                    Mensaje = exMessage
                });
            }

            return resultado;

        }

        public async Task<ResponseTipoDocumentoIdentificacionEliminarDtoApi> Eliminar(int id)
        {
            ResponseTipoDocumentoIdentificacionEliminarDtoApi resultado = new ResponseTipoDocumentoIdentificacionEliminarDtoApi();
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
                    if (result.IsSuccessStatusCode)
                    {
                        response = await result.Content.ReadAsStringAsync();
                    }
                }

                if (!string.IsNullOrEmpty(response))
                {
                    resultado = new ResponseTipoDocumentoIdentificacionEliminarDtoApi();
                    resultado = JsonConvert.DeserializeObject<ResponseTipoDocumentoIdentificacionEliminarDtoApi>(response);
                }
            }
            catch (Exception ex)
            {
                if (resultado == null) resultado = new ResponseTipoDocumentoIdentificacionEliminarDtoApi();
                if (resultado.ListaError == null) resultado.ListaError = new List<ErrorDtoApi>();

                string exMessage = (ex.InnerException == null ? ex.Message : ex.InnerException.Message).Replace(Environment.NewLine, " ");
                Log(Level.Error, exMessage);
                resultado.ListaError.Add(new ErrorDtoApi
                {
                    Mensaje = exMessage
                });
            }

            return resultado;
        }

        public async Task<ResponseTipoDocumentoIdentificacionObtenerComboDtoApi> ObtenerCombo()
        {
            ResponseTipoDocumentoIdentificacionObtenerComboDtoApi respuesta = new ResponseTipoDocumentoIdentificacionObtenerComboDtoApi();
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
                    if (result.IsSuccessStatusCode)
                    {
                        response = await result.Content.ReadAsStringAsync();
                    }
                }

                if (!string.IsNullOrEmpty(response))
                {
                    respuesta = JsonConvert.DeserializeObject<ResponseTipoDocumentoIdentificacionObtenerComboDtoApi>(response);
                }
            }
            catch (Exception ex)
            {
                string exMessage = (ex.InnerException == null ? ex.Message : ex.InnerException.Message).Replace(Environment.NewLine, " ");
                Log(Level.Error, exMessage);
                if (respuesta.ListaError == null) respuesta.ListaError = new List<ErrorDtoApi>();
                respuesta.ListaError.Add(new ErrorDtoApi
                {
                    Mensaje = exMessage
                });
            }

            return respuesta;

        }
    }
}
