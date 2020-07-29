using Entidad.Configuracion.Proceso;
using ModelosApi.Request.Transaccion;
using ModelosApi.Response.Transaccion;
using Entidad.Vo;
using ModelosApi.Response.Comun;
using ModelosApi.Response.Transaccion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repositorio.Transaccion
{
    public class LnPedido: Logger
    {
        private readonly string _nombreControlador = "Pedido";
        public async Task<ResponsePedidoObtenerNotaPedidoDtoApi> ObtenerNotaPedidoPorId(long id)
        {
            ResponsePedidoObtenerNotaPedidoDtoApi resultado = new ResponsePedidoObtenerNotaPedidoDtoApi();
            int statusCode = 0;
            try
            {
                var response = string.Empty;
                string url = string.Format("{0}{1}/ObtenerNotaPedidoPorId/{2}", ConstanteVo.UrlBaseApi, _nombreControlador, id);

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
                    resultado = new ResponsePedidoObtenerNotaPedidoDtoApi();
                    resultado = JsonConvert.DeserializeObject<ResponsePedidoObtenerNotaPedidoDtoApi>(response);
                }
            }
            catch (Exception ex)
            {
                if (resultado == null) resultado = new ResponsePedidoObtenerNotaPedidoDtoApi();
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

            if(resultado != null)
            {
                if(resultado.Cuerpo != null)
                {
                    if (resultado.Cuerpo.ListaDetalle != null)
                    {
                        if (resultado.Cuerpo.ListaDetalle.Count > 0)
                        {
                            decimal acumulado = 0;
                            foreach (var item in resultado.Cuerpo.ListaDetalle)
                            {
                                item.SubTotalPorItem = Convert.ToDecimal(item.Cantidad) * Convert.ToDecimal(item.PrecioUnitario);
                                acumulado += item.SubTotalPorItem; 
                            }
                            resultado.Cuerpo.Total = acumulado;
                        }
                    }
                }
            }

            return resultado;
        }

        public async Task<ResponsePedidoObtenerPendientesAtencionPorIdUsuarioDtoApi> ObtenerPendientesAtencionPorIdUsuario(long id)
        {
            ResponsePedidoObtenerPendientesAtencionPorIdUsuarioDtoApi resultado = new ResponsePedidoObtenerPendientesAtencionPorIdUsuarioDtoApi();
            int statusCode = 0;
            try
            {
                var response = string.Empty;
                string url = string.Format("{0}{1}/ObtenerPendientesAtencionPorIdUsuario/{2}", ConstanteVo.UrlBaseApi, _nombreControlador, id);

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
                    resultado = new ResponsePedidoObtenerPendientesAtencionPorIdUsuarioDtoApi();
                    resultado = JsonConvert.DeserializeObject<ResponsePedidoObtenerPendientesAtencionPorIdUsuarioDtoApi>(response);
                }
            }
            catch (Exception ex)
            {
                if (resultado == null) resultado = new ResponsePedidoObtenerPendientesAtencionPorIdUsuarioDtoApi();
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

            //if (resultado != null)
            //{
            //    if (resultado.Cuerpo != null)
            //    {
            //        if (resultado.Cuerpo.ListaDetalle != null)
            //        {
            //            if (resultado.Cuerpo.ListaDetalle.Count > 0)
            //            {
            //                decimal acumulado = 0;
            //                foreach (var item in resultado.Cuerpo.ListaDetalle)
            //                {
            //                    item.SubTotalPorItem = Convert.ToDecimal(item.Cantidad) * Convert.ToDecimal(item.PrecioUnitario);
            //                    acumulado += item.SubTotalPorItem;
            //                }
            //                resultado.Cuerpo.Total = acumulado;
            //            }
            //        }
            //    }
            //}

            return resultado;
        }

        public async Task<ResponsePedidoObtenerPorIdDtoApi> ObtenerPorId(long id)
        {
            ResponsePedidoObtenerPorIdDtoApi resultado = new ResponsePedidoObtenerPorIdDtoApi();
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
                    resultado = new ResponsePedidoObtenerPorIdDtoApi();
                    resultado = JsonConvert.DeserializeObject<ResponsePedidoObtenerPorIdDtoApi>(response);
                }
            }
            catch (Exception ex)
            {
                if (resultado == null) resultado = new ResponsePedidoObtenerPorIdDtoApi();
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

        public async Task<ResponsePedidoModificarEstadoPorParteDeVendedorDtoApi> ModificarEstadoPorParteDeVendedor(RequestPedidoModificarEstadoPorParteDeVendedorDtoApi prm)
        {
            ResponsePedidoModificarEstadoPorParteDeVendedorDtoApi resultado = new ResponsePedidoModificarEstadoPorParteDeVendedorDtoApi();
            int statusCode = 0;
            try
            {
                //Dentro de AJAX => datatype: 'json', headers: {'Authorization': 'Basic ' + valor token }, ....
                var response = string.Empty;
                string url = string.Format("{0}{1}/ModificarEstadoPorParteDeVendedor", ConstanteVo.UrlBaseApi, _nombreControlador);

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
                    resultado = new ResponsePedidoModificarEstadoPorParteDeVendedorDtoApi();
                    resultado = JsonConvert.DeserializeObject<ResponsePedidoModificarEstadoPorParteDeVendedorDtoApi>(response);
                }
            }
            catch (Exception ex)
            {
                if (resultado == null) resultado = new ResponsePedidoModificarEstadoPorParteDeVendedorDtoApi();
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

        public async Task<ResponsePedidoModificarEstadoPorParteDeCompradorDtoApi> ModificarEstadoPorParteDeComprador(RequestPedidoModificarEstadoPorParteDeCompradorDtoApi prm)
        {
            ResponsePedidoModificarEstadoPorParteDeCompradorDtoApi resultado = new ResponsePedidoModificarEstadoPorParteDeCompradorDtoApi();
            int statusCode = 0;
            try
            {
                //Dentro de AJAX => datatype: 'json', headers: {'Authorization': 'Basic ' + valor token }, ....
                var response = string.Empty;
                string url = string.Format("{0}{1}/ModificarEstadoPorParteDeComprador", ConstanteVo.UrlBaseApi, _nombreControlador);

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
                    resultado = new ResponsePedidoModificarEstadoPorParteDeCompradorDtoApi();
                    resultado = JsonConvert.DeserializeObject<ResponsePedidoModificarEstadoPorParteDeCompradorDtoApi>(response);
                }
            }
            catch (Exception ex)
            {
                if (resultado == null) resultado = new ResponsePedidoModificarEstadoPorParteDeCompradorDtoApi();
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
