using Entidad.Configuracion.Proceso;
using Entidad.Vo;
using ModelosApi.Response.Comun;
using ModelosApi.Response.Seguridad;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Negocio.Repositorio.Seguridad
{
    public class LnAcceso: Logger
    {
        private readonly string _nombreControlador = "Acceso";
        public async Task<ResponseAccesoObtenerPorIdUsuarioDtoApi> ObtenerPorIdUsuario(long id)
        {
            ResponseAccesoObtenerPorIdUsuarioDtoApi resultado = new ResponseAccesoObtenerPorIdUsuarioDtoApi();
            int statusCode = 0;
            try
            {
                var response = string.Empty;
                string url = string.Format("{0}{1}/ObtenerPorIdUsuario/{2}", ConstanteVo.UrlBaseApi, _nombreControlador, id);

                using (var client = new HttpClient())
                {
                    HttpResponseMessage result = await client.GetAsync(new Uri(url));
                    if (result != null)
                    {
                        response = await result.Content.ReadAsStringAsync();
                        statusCode = (int)result.StatusCode;
                    }
                }

                if (!string.IsNullOrEmpty(response))
                {
                    resultado = new ResponseAccesoObtenerPorIdUsuarioDtoApi();
                    resultado = JsonConvert.DeserializeObject<ResponseAccesoObtenerPorIdUsuarioDtoApi>(response);
                }
            }
            catch (Exception ex)
            {
                if (resultado == null) resultado = new ResponseAccesoObtenerPorIdUsuarioDtoApi();
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
