using Entidad.Configuracion.Proceso;
using ModelosApi.Request.Maestro;
using Entidad.Vo;
using ModelosApi.Response.Comun;
using ModelosApi.Response.Maestro;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repositorio.Maestro
{
    public class LnProductoImagen: Logger
    {
        private readonly string _nombreControlador = "ProductoImagen";

        public async Task<ResponseProductoEliminarImagenDtoApi> Eliminar(long id)
        {
            ResponseProductoEliminarImagenDtoApi resultado = new ResponseProductoEliminarImagenDtoApi();
            int statusCode = 0;
            try
            {
                var response = string.Empty;
                string url = string.Format("{0}{1}/Imagen/{2}", ConstanteVo.UrlBaseApi, _nombreControlador, id);

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
                    resultado = new ResponseProductoEliminarImagenDtoApi();
                    resultado = JsonConvert.DeserializeObject<ResponseProductoEliminarImagenDtoApi>(response);
                }
            }
            catch (Exception ex)
            {
                if (resultado == null) resultado = new ResponseProductoEliminarImagenDtoApi();
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

        public async Task<ResponseProductoSubirImagenDtoApi> SubirImagen(RequestProductoImagenModificarImagenMetodo1DtoApi prm)
        {
            ResponseProductoSubirImagenDtoApi resultado = new ResponseProductoSubirImagenDtoApi();
            int statusCode = 0;
            try
            {
                //Dentro de AJAX => datatype: 'json', headers: {'Authorization': 'Basic ' + valor token }, ....
                var response = string.Empty;
                string url = string.Format("{0}{1}/ImagenMetodo1", ConstanteVo.UrlBaseApi, _nombreControlador);

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

                resultado = JsonConvert.DeserializeObject<ResponseProductoSubirImagenDtoApi>(response);
            }
            catch (Exception ex)
            {
                resultado.ListaError.Add(new ErrorDtoApi
                {
                    Mensaje = (ex.InnerException == null ? ex.Message : ex.InnerException.Message).Replace(Environment.NewLine, " ")
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
