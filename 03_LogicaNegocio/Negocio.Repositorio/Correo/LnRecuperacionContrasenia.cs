using Entidad.Configuracion.Proceso;
using ModelosApi.Request.Correo;
using Entidad.Vo;
using ModelosApi.Response.Comun;
using ModelosApi.Response.Correo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repositorio.Correo
{
    public class LnRecuperacionContrasenia: Logger
    {
        private readonly string _nombreControlador = "RecuperacionContrasenia";
        public async Task<ResponseRecuperacionContraseniaRegistrarDtoApi> Registrar(RequestRecuperacionContraseniaRegistrarDtoApi prm)
        {
            ResponseRecuperacionContraseniaRegistrarDtoApi resultado = new ResponseRecuperacionContraseniaRegistrarDtoApi();
            int statusCode = 0;
            try
            {
                //Dentro de AJAX => datatype: 'json', headers: {'Authorization': 'Basic ' + valor token }, ....
                var response = string.Empty;
                string url = string.Format("{0}{1}", ConstanteVo.UrlBaseApi, _nombreControlador);

                using (var client = new HttpClient())
                {
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
                    resultado = new ResponseRecuperacionContraseniaRegistrarDtoApi();
                    resultado = JsonConvert.DeserializeObject<ResponseRecuperacionContraseniaRegistrarDtoApi>(response);
                }
            }
            catch (Exception ex)
            {
                if (resultado == null) resultado = new ResponseRecuperacionContraseniaRegistrarDtoApi();
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
