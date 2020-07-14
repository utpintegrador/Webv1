using Datos.Repositorio.Seguridad;
using Entidad.Configuracion.Proceso;
using Entidad.Dto.Comun;
using Entidad.Dto.Response.Seguridad;
using Entidad.Dto.Seguridad;
using Entidad.Vo;
using ModelosApi.Dto.Seguridad;
using ModelosApi.Request.Seguridad;
using ModelosApi.Response.Comun;
using ModelosApi.Response.Seguridad;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repositorio.Seguridad
{
    public class LnUsuario: Logger
    {
        private readonly string _nombreControlador = "Usuario";

        public async Task<ResultDataTable> Obtener(UsuarioObtenerFiltroDto prm)
        {
            ResultDataTable respuesta = new ResultDataTable();
            long totalRegistros = 0;
            List<UsuarioObtenerDtoApi> lista = new List<UsuarioObtenerDtoApi>();

            try
            {
                //Dentro de AJAX => datatype: 'json', headers: {'Authorization': 'Basic ' + valor token }, ....
                RequestUsuarioObtenerDtoApi filtroApi = new RequestUsuarioObtenerDtoApi
                {
                    IdEstado = prm.IdEstado,
                    Buscar = string.IsNullOrEmpty(prm.Buscar) ? string.Empty : prm.Buscar,
                    IdTipoUsuario = prm.IdTipoUsuario
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

                ResponseUsuarioObtenerDtoApi root = JsonConvert.DeserializeObject<ResponseUsuarioObtenerDtoApi>(response);
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

        public async Task<ResponseUsuarioObtenerPorIdDtoApi> ObtenerPorId(long id)
        {
            ResponseUsuarioObtenerPorIdDtoApi resultado = new ResponseUsuarioObtenerPorIdDtoApi();
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
                    resultado = new ResponseUsuarioObtenerPorIdDtoApi();
                    resultado = JsonConvert.DeserializeObject<ResponseUsuarioObtenerPorIdDtoApi>(response);
                }
            }
            catch (Exception ex)
            {
                if (resultado == null) resultado = new ResponseUsuarioObtenerPorIdDtoApi();
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

        public async Task<ResponseUsuarioModificarDtoApi> Modificar(RequestUsuarioModificarDtoApi prm)
        {
            ResponseUsuarioModificarDtoApi resultado = new ResponseUsuarioModificarDtoApi();

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
                    resultado = new ResponseUsuarioModificarDtoApi();
                    resultado = JsonConvert.DeserializeObject<ResponseUsuarioModificarDtoApi>(response);
                }
            }
            catch (Exception ex)
            {
                if (resultado == null) resultado = new ResponseUsuarioModificarDtoApi();
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

        public async Task<ResponseUsuarioModificarModoAdminDtoApi> ModificarModoAdmin(RequestUsuarioModificarModoAdminDtoApi prm)
        {
            ResponseUsuarioModificarModoAdminDtoApi resultado = new ResponseUsuarioModificarModoAdminDtoApi();

            try
            {
                //Dentro de AJAX => datatype: 'json', headers: {'Authorization': 'Basic ' + valor token }, ....
                var response = string.Empty;
                string url = string.Format("{0}{1}/ModificarModoAdmin", ConstanteVo.UrlBaseApi, _nombreControlador);

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
                    resultado = new ResponseUsuarioModificarModoAdminDtoApi();
                    resultado = JsonConvert.DeserializeObject<ResponseUsuarioModificarModoAdminDtoApi>(response);
                }
            }
            catch (Exception ex)
            {
                if (resultado == null) resultado = new ResponseUsuarioModificarModoAdminDtoApi();
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

        public async Task<ResponseUsuarioRegistrarDtoApi> Registrar(RequestUsuarioRegistrarDtoApi prm)
        {
            ResponseUsuarioRegistrarDtoApi resultado = new ResponseUsuarioRegistrarDtoApi();

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
                    resultado = new ResponseUsuarioRegistrarDtoApi();
                    resultado = JsonConvert.DeserializeObject<ResponseUsuarioRegistrarDtoApi>(response);
                }
            }
            catch (Exception ex)
            {
                if (resultado == null) resultado = new ResponseUsuarioRegistrarDtoApi();
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

        public async Task<ResponseUsuarioEliminarDtoApi> Eliminar(long id)
        {
            ResponseUsuarioEliminarDtoApi resultado = new ResponseUsuarioEliminarDtoApi();
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
                    resultado = new ResponseUsuarioEliminarDtoApi();
                    resultado = JsonConvert.DeserializeObject<ResponseUsuarioEliminarDtoApi>(response);
                }
            }
            catch (Exception ex)
            {
                if (resultado == null) resultado = new ResponseUsuarioEliminarDtoApi();
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







        public async Task<UsuarioResponseSubirImagenDto> SubirImagen(RequestUsuarioModificarImagenMetodo1DtoApi filtroApi)
        {
            UsuarioResponseSubirImagenDto respuesta = new UsuarioResponseSubirImagenDto();

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

                    var content = new StringContent(JsonConvert.SerializeObject(filtroApi), Encoding.UTF8, "application/json");
                    HttpResponseMessage result = await client.PostAsync(new Uri(url), content);
                    if (result.IsSuccessStatusCode)
                    {
                        response = await result.Content.ReadAsStringAsync();
                    }
                }

                ResponseUsuarioSubirImagenDtoApi root = JsonConvert.DeserializeObject<ResponseUsuarioSubirImagenDtoApi>(response);
                if (root != null)
                {
                    respuesta.UrlImagen = root.UrlImagen;
                    respuesta.ProcesadoOk = root.ProcesadoOk;
                }
            }
            catch (Exception ex)
            {
                respuesta.ListaError.Add(new Entidad.Dto.Global.ErrorDto
                {
                    Mensaje = (ex.InnerException == null ? ex.Message : ex.InnerException.Message)
                });
            }

            return respuesta;

        }

        public async Task<UsuarioResponseSubirImagenDto> EliminarImagen(long id)
        {
            UsuarioResponseSubirImagenDto respuesta = new UsuarioResponseSubirImagenDto();
            try
            {
                //Dentro de AJAX => datatype: 'json', headers: {'Authorization': 'Basic ' + valor token }, ....

                var response = string.Empty;
                string url = string.Format("{0}{1}/Imagen/{2}", ConstanteVo.UrlBaseApi, _nombreControlador, id);

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
                    respuesta = JsonConvert.DeserializeObject<UsuarioResponseSubirImagenDto>(response);
                }
            }
            catch (Exception ex)
            {
                Log(Level.Error, ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }

            return respuesta;

        }


        /*En otro entregable completar*/

        public async Task<ResponseUsuarioLoginDtoApi> ObtenerPorLogin(UsuarioLoginFiltroDto modelo)
        {
            ResponseUsuarioLoginDtoApi respuesta = new ResponseUsuarioLoginDtoApi();
            RequestUsuarioCredencialesDtoApi filtroApi = new RequestUsuarioCredencialesDtoApi
            {
                Contrasenia = modelo.Contrasenia,
                CorreoElectronico = modelo.CorreoElectronico
            };
            try
            {
                var response = string.Empty;
                string url = string.Format("{0}{1}", ConstanteVo.UrlBaseApi, "Login");

                using (var client = new HttpClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(filtroApi), Encoding.UTF8, "application/json");
                    HttpResponseMessage result = await client.PostAsync(new Uri(url), content);

                    if (result.IsSuccessStatusCode)
                    {
                        response = await result.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        switch (result.StatusCode)
                        {
                            case HttpStatusCode.BadRequest:
                                respuesta = null;
                                break;
                            default:
                                break;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(response))
                {
                    ResponseUsuarioLoginDtoApi root = JsonConvert.DeserializeObject<ResponseUsuarioLoginDtoApi>(response);
                    if (root != null)
                    {
                        respuesta = root;
                    }
                }
            }
            catch (Exception ex)
            {
                Log(Level.Error, ex.InnerException == null ? ex.Message : ex.InnerException.Message);
                respuesta = null;
            }

            return respuesta;
        }

        public int ModificarContrasenia(UsuarioCambioContraseniaDto modelo)
        {
            return 0;
        }

    }
}
