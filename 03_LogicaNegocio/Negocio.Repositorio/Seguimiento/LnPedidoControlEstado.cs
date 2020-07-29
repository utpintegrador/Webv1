using Entidad.Configuracion.Proceso;
using Entidad.Vo;
using ModelosApi.Response.Comun;
using ModelosApi.Response.Seguimiento;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Negocio.Repositorio.Seguimiento
{
    public class LnPedidoControlEstado: Logger
    {
        private readonly string _nombreControlador = "PedidoControlEstado";
        public async Task<ResponsePedidoControlEstadoObtenerPorIdPedidoDtoApi> ObtenerPorIdPedido(long idPedido)
        {
            ResponsePedidoControlEstadoObtenerPorIdPedidoDtoApi resultado = new ResponsePedidoControlEstadoObtenerPorIdPedidoDtoApi();
            int statusCode = 0;
            try
            {
                //Dentro de AJAX => datatype: 'json', headers: {'Authorization': 'Basic ' + valor token }, ....

                var response = string.Empty;
                string url = string.Format("{0}{1}/ObtenerPorIdPedido/{2}", ConstanteVo.UrlBaseApi, _nombreControlador, idPedido);

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
                    resultado = JsonConvert.DeserializeObject<ResponsePedidoControlEstadoObtenerPorIdPedidoDtoApi>(response);
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
