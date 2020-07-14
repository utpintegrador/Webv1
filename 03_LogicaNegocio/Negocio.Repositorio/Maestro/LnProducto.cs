using Entidad.Configuracion.Proceso;
using Entidad.Dto.Comun;
using Entidad.Dto.Maestro;
using Entidad.Request.Maestro;
using Entidad.Vo;
using ModelosApi.Dto.Maestro;
using ModelosApi.Request.Maestro;
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
    public class LnProducto: Logger
    {
        private readonly string _nombreControlador = "Producto";

        public async Task<ResultDataTable> Obtener(ProductoObtenerFiltroDto prm)
        {
            ResultDataTable respuesta = new ResultDataTable();
            long totalRegistros = 0;
            List<ProductoObtenerPorIdUsuarioDtoApi> lista = new List<ProductoObtenerPorIdUsuarioDtoApi>();

            try
            {
                //Dentro de AJAX => datatype: 'json', headers: {'Authorization': 'Basic ' + valor token }, ....
                RequestProductoObtenerPorIdUsuarioDtoApi filtroApi = new RequestProductoObtenerPorIdUsuarioDtoApi
                {
                    IdEstado = prm.IdEstado,
                    Buscar = string.IsNullOrEmpty(prm.Buscar) ? string.Empty: prm.Buscar,
                    IdUsuario = prm.IdUsuario,
                    IdNegocio = prm.IdNegocio,
                    IdMoneda = prm.IdMoneda,
                    IdCategoria = prm.IdCategoria
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
                    if (result.IsSuccessStatusCode)
                    {
                        response = await result.Content.ReadAsStringAsync();
                    }
                }

                ResponseProductoObtenerPorIdUsuarioDtoApi root = JsonConvert.DeserializeObject<ResponseProductoObtenerPorIdUsuarioDtoApi>(response);
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

        public async Task<ResponseProductoObtenerPorIdConAtributosDto> ObtenerPorId(long id)
        {
            ResponseProductoObtenerPorIdConAtributosDto resultado = new ResponseProductoObtenerPorIdConAtributosDto();
            try
            {
                var response = string.Empty;
                string url = string.Format("{0}{1}/ObtenerPorIdConAtributos/{2}", ConstanteVo.UrlBaseApi, _nombreControlador, id);

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
                    resultado = new ResponseProductoObtenerPorIdConAtributosDto();
                    resultado = JsonConvert.DeserializeObject<ResponseProductoObtenerPorIdConAtributosDto>(response);
                    if(resultado != null)
                    {
                        ProcesarCarruselImagenes(ref resultado);
                    }
                }
            }
            catch (Exception ex)
            {
                if (resultado == null) resultado = new ResponseProductoObtenerPorIdConAtributosDto();
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

        private void ProcesarCarruselImagenes(ref ResponseProductoObtenerPorIdConAtributosDto respuesta)
        {
            if (respuesta == null) return;
            if (respuesta.Cuerpo == null) return;
            if (respuesta.Cuerpo.ListaImagen == null) return;
            if (!respuesta.Cuerpo.ListaImagen.Any()) return;

            int cantidadPredeterminados = respuesta.Cuerpo.ListaImagen.Where(x => Convert.ToBoolean(x.Predeterminado)).Count();
            if (cantidadPredeterminados <= 1)
            {
                respuesta.Cuerpo.ListaImagen[0].Predeterminado = true;
                respuesta.Cuerpo.ListaImagen[0].Indice = 1;
            }
            else
            {
                //si hay mas de 2 predeterminados, solo deberia de haber uno
                int indice = 1;
                bool predeterminadoEncontrado = false;
                foreach (var ima in respuesta.Cuerpo.ListaImagen)
                {
                    ima.Indice = indice;

                    if (!predeterminadoEncontrado)
                    {
                        if (Convert.ToBoolean(ima.Predeterminado))
                        {
                            predeterminadoEncontrado = true;
                        }
                    }
                    else
                    {
                        ima.Predeterminado = false;
                    }

                    indice++;
                }
            }
            
        }

        public async Task<ResponseProductoModificarDtoApi> Modificar(RequestProductoModificarDtoApi prm)
        {
            ResponseProductoModificarDtoApi resultado = new ResponseProductoModificarDtoApi();

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
                    resultado = new ResponseProductoModificarDtoApi();
                    resultado = JsonConvert.DeserializeObject<ResponseProductoModificarDtoApi>(response);
                }
            }
            catch (Exception ex)
            {
                if (resultado == null) resultado = new ResponseProductoModificarDtoApi();
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

        public async Task<ResponseProductoRegistrarDtoApi> Registrar(RequestProductoRegistrarDtoApi prm)
        {
            ResponseProductoRegistrarDtoApi resultado = new ResponseProductoRegistrarDtoApi();

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
                    resultado = new ResponseProductoRegistrarDtoApi();
                    resultado = JsonConvert.DeserializeObject<ResponseProductoRegistrarDtoApi>(response);
                }
            }
            catch (Exception ex)
            {
                if (resultado == null) resultado = new ResponseProductoRegistrarDtoApi();
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

        public async Task<ResponseProductoEliminarDtoApi> Eliminar(long id)
        {
            ResponseProductoEliminarDtoApi resultado = new ResponseProductoEliminarDtoApi();
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
                    resultado = new ResponseProductoEliminarDtoApi();
                    resultado = JsonConvert.DeserializeObject<ResponseProductoEliminarDtoApi>(response);
                }
            }
            catch (Exception ex)
            {
                if (resultado == null) resultado = new ResponseProductoEliminarDtoApi();
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

        public async Task<ResponseProductoEliminarMasivoDtoApi> EliminarMasivo(RequestProductoEliminarMasivoDtoApi prm)
        {
            ResponseProductoEliminarMasivoDtoApi resultado = new ResponseProductoEliminarMasivoDtoApi();

            try
            {
                //Dentro de AJAX => datatype: 'json', headers: {'Authorization': 'Basic ' + valor token }, ....
                var response = string.Empty;
                string url = string.Format("{0}{1}/EliminarMasivo", ConstanteVo.UrlBaseApi, _nombreControlador);

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
                    resultado = new ResponseProductoEliminarMasivoDtoApi();
                    resultado = JsonConvert.DeserializeObject<ResponseProductoEliminarMasivoDtoApi>(response);
                }
            }
            catch (Exception ex)
            {
                if (resultado == null) resultado = new ResponseProductoEliminarMasivoDtoApi();
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

        //public List<ProductoObtenerDto> ObtenerListadoPorIdUsuario(ProductoObtenerFiltroDto filtro)
        //{
        //    List<ProductoObtenerDto> lista = new List<ProductoObtenerDto>();
        //    lista.Add(new ProductoObtenerDto
        //    {
        //        IdProducto = 1,
        //        Descripcion = "Producto 1",
        //        DescripcionExtendida = "Descripcion extendida 1",
        //        Precio = 4.5M,
        //        Estado = "Activo",
        //        Moneda = "Sol",
        //        Categoria = "Categoria 1",
        //        Negocio = "Negocio 1",
        //        UrlImagen = "https://encuentralo.s3.us-east-2.amazonaws.com/Categoria/1.jpg"
        //    });

        //    lista.Add(new ProductoObtenerDto
        //    {
        //        IdProducto = 2,
        //        Descripcion = "Producto 2",
        //        DescripcionExtendida = "Descripcion extendida 2",
        //        Precio = 5.9M,
        //        Estado = "Activo",
        //        Moneda = "Sol",
        //        Categoria = "Categoria 1",
        //        Negocio = "Negocio 1",
        //        UrlImagen = "https://encuentralo.s3.us-east-2.amazonaws.com/Categoria/2.jpg"
        //    });

        //    lista.Add(new ProductoObtenerDto
        //    {
        //        IdProducto = 3,
        //        Descripcion = "Producto 3",
        //        DescripcionExtendida = "Descripcion extendida 3",
        //        Precio = 1.2M,
        //        Estado = "Activo",
        //        Moneda = "Sol",
        //        Categoria = "Categoria 1",
        //        Negocio = "Negocio 1",
        //        UrlImagen = "https://encuentralo.s3.us-east-2.amazonaws.com/Categoria/3.jpg"
        //    });

        //    lista.Add(new ProductoObtenerDto
        //    {
        //        IdProducto = 4,
        //        Descripcion = "Producto 4",
        //        DescripcionExtendida = "Descripcion extendida 4",
        //        Precio = 3.6M,
        //        Estado = "Activo",
        //        Moneda = "Sol",
        //        Categoria = "Categoria 1",
        //        Negocio = "Negocio 1",
        //        UrlImagen = "https://encuentralo.s3.us-east-2.amazonaws.com/Categoria/4.jpg"
        //    });

        //    lista.Add(new ProductoObtenerDto
        //    {
        //        IdProducto = 5,
        //        Descripcion = "Producto 5",
        //        DescripcionExtendida = "Descripcion extendida 5",
        //        Precio = 0.1M,
        //        Estado = "Activo",
        //        Moneda = "Sol",
        //        Categoria = "Categoria 1",
        //        Negocio = "Negocio 1",
        //        UrlImagen = "https://encuentralo.s3.us-east-2.amazonaws.com/Categoria/5.jpg"
        //    });

        //    return lista;
        //}
    }
}
