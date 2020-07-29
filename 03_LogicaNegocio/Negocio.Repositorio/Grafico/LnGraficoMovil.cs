using Entidad.Configuracion.Proceso;
using Entidad.Vo;
using ModelosApi.Request.Grafico;
using ModelosApi.Response.Comun;
using ModelosApi.Response.Grafico;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repositorio.Grafico
{
    public class LnGraficoMovil: Logger
    {
        private readonly string _nombreControlador = "GraficoMovil";

        public async Task<ResponseGraficoObtenerResumenComprasDtoApi> ObtenerResumenCompras(RequestGraficoObtenerResumenComprasDtoApi prm)
        {
            ResponseGraficoObtenerResumenComprasDtoApi resultado = new ResponseGraficoObtenerResumenComprasDtoApi();
            int statusCode = 0;
            try
            {
                //Dentro de AJAX => datatype: 'json', headers: {'Authorization': 'Basic ' + valor token }, ....
                var response = string.Empty;
                string url = string.Format("{0}{1}/ObtenerResumenCompras", ConstanteVo.UrlBaseApi, _nombreControlador);

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
                    resultado = new ResponseGraficoObtenerResumenComprasDtoApi();
                    resultado = JsonConvert.DeserializeObject<ResponseGraficoObtenerResumenComprasDtoApi>(response);
                }
            }
            catch (Exception ex)
            {
                if (resultado == null) resultado = new ResponseGraficoObtenerResumenComprasDtoApi();
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

        public async Task<ResponseGraficoObtenerResumenVentasDtoApi> ObtenerResumenVentas(RequestGraficoObtenerResumenVentasDtoApi prm)
        {
            ResponseGraficoObtenerResumenVentasDtoApi resultado = new ResponseGraficoObtenerResumenVentasDtoApi();
            int statusCode = 0;
            try
            {
                //Dentro de AJAX => datatype: 'json', headers: {'Authorization': 'Basic ' + valor token }, ....
                var response = string.Empty;
                string url = string.Format("{0}{1}/ObtenerResumenVentas", ConstanteVo.UrlBaseApi, _nombreControlador);

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
                    resultado = new ResponseGraficoObtenerResumenVentasDtoApi();
                    resultado = JsonConvert.DeserializeObject<ResponseGraficoObtenerResumenVentasDtoApi>(response);
                }
            }
            catch (Exception ex)
            {
                if (resultado == null) resultado = new ResponseGraficoObtenerResumenVentasDtoApi();
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
