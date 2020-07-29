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
using ClosedXML.Excel;
using System.IO;

namespace Negocio.Repositorio.Maestro
{
    public class LnProducto: Logger
    {
        private readonly string _nombreControlador = "Producto";

        public async Task<ResultDataTable> Obtener(ProductoObtenerFiltroDto prm)
        {
            ResultDataTable resultado = new ResultDataTable();
            long totalRegistros = 0;
            List<ProductoObtenerPorIdUsuarioDtoApi> lista = new List<ProductoObtenerPorIdUsuarioDtoApi>();
            int statusCode = 0;
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
                    if (result != null)
                    {
                        response = await result.Content.ReadAsStringAsync();
                        statusCode = (int)result.StatusCode;
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

        public async Task<ResponseProductoObtenerPorIdConAtributosDto> ObtenerPorId(long id)
        {
            ResponseProductoObtenerPorIdConAtributosDto resultado = new ResponseProductoObtenerPorIdConAtributosDto();
            int statusCode = 0;
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
                    if (result != null)
                    {
                        response = await result.Content.ReadAsStringAsync();
                        statusCode = (int)result.StatusCode;
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
            finally
            {
                if (resultado != null)
                {
                    resultado.StatusCode = statusCode;
                }
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
            finally
            {
                if (resultado != null)
                {
                    resultado.StatusCode = statusCode;
                }
            }

            return resultado;

        }

        public async Task<ResponseProductoRegistrarDtoApi> Registrar(RequestProductoRegistrarDtoApi prm)
        {
            ResponseProductoRegistrarDtoApi resultado = new ResponseProductoRegistrarDtoApi();
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
            finally
            {
                if (resultado != null)
                {
                    resultado.StatusCode = statusCode;
                }
            }

            return resultado;

        }

        public async Task<ResponseProductoEliminarDtoApi> Eliminar(long id)
        {
            ResponseProductoEliminarDtoApi resultado = new ResponseProductoEliminarDtoApi();
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
            finally
            {
                if (resultado != null)
                {
                    resultado.StatusCode = statusCode;
                }
            }

            return resultado;
        }

        public async Task<ResponseProductoEliminarMasivoDtoApi> EliminarMasivo(RequestProductoEliminarMasivoDtoApi prm)
        {
            ResponseProductoEliminarMasivoDtoApi resultado = new ResponseProductoEliminarMasivoDtoApi();
            int statusCode = 0;
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
                    if (result != null)
                    {
                        response = await result.Content.ReadAsStringAsync();
                        statusCode = (int)result.StatusCode;
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
            finally
            {
                if (resultado != null)
                {
                    resultado.StatusCode = statusCode;
                }
            }

            return resultado;

        }

        public async Task<ResponseProductoImportarDtoApi> Importar(RequestProductoImportarDtoApi prm)
        {
            ResponseProductoImportarDtoApi resultado = new ResponseProductoImportarDtoApi();
            int statusCode = 400;
            try
            {
                XLWorkbook libro;
                using (Stream stream = new MemoryStream(prm.ArchivoBytes))
                {
                    libro = new XLWorkbook(stream);
                }

                List<string> listaValidacionEstructura = new List<string>();
                bool validacion = false;
                if(libro != null)
                {
                    if(ValidarEstructuraExcel(libro, ref listaValidacionEstructura))
                    {
                        //Validar fila por fila
                        validacion = ValidarDataExcel(libro, ref listaValidacionEstructura);
                    }
                }

                //solo debe continuar si la data es valida
                if (validacion)
                {
                    //Dentro de AJAX => datatype: 'json', headers: {'Authorization': 'Basic ' + valor token }, ....
                    var response = string.Empty;
                    string url = string.Format("{0}{1}/Importar", ConstanteVo.UrlBaseApi, _nombreControlador);

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
                        resultado = new ResponseProductoImportarDtoApi();
                        resultado = JsonConvert.DeserializeObject<ResponseProductoImportarDtoApi>(response);
                    }
                }
                else
                {
                    List<ErrorDtoApi> ListaErrorValidacion = new List<ErrorDtoApi>();
                    foreach (var itemValidacion in listaValidacionEstructura)
                    {
                        ListaErrorValidacion.Add(new ErrorDtoApi
                        {
                            Mensaje = itemValidacion
                        });
                    }
                    resultado.ListaError = ListaErrorValidacion;
                    resultado.StatusCode = statusCode;
                }
            }
            catch (Exception ex)
            {
                if (resultado == null) resultado = new ResponseProductoImportarDtoApi();
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

        private bool ValidarDataExcel(XLWorkbook libro, ref List<string> listaValidaciones)
        {
            if (listaValidaciones == null) listaValidaciones = new List<string>();
            if (libro != null)
            {
                try
                {
                    using (libro)
                    {
                        if (libro.Worksheets.Any(x => x.Name == "Productos"))
                        {
                            //Descripcion	DescripcionExtendida	Precio
                            IXLWorksheet hoja = libro.Worksheet("Productos");
                            IXLRange rango = hoja.RangeUsed();
                            int cantidadFilas = rango.Rows().Count();
                            string descripcionExtraido;
                            string descripcionExtendidaExtraido;
                            string precioExtraido;
                            for (int i = 1; i < cantidadFilas; i++)//desde uno porque no se requiere leer la cabecera
                            {
                                try
                                {
                                    descripcionExtraido = hoja.Cell(i + 1, 1).Value.ToString();//500 not null
                                    descripcionExtendidaExtraido = hoja.Cell(i + 1, 2).Value.ToString();//1000
                                    precioExtraido = hoja.Cell(i + 1, 3).Value.ToString();//not null numerico

                                    if (string.IsNullOrEmpty(descripcionExtraido))
                                    {
                                        listaValidaciones.Add(string.Format("Fila {0} ; Se requiere el parametro [Descripcion]", (i + 1).ToString()));
                                    }
                                    else
                                    {
                                        if (descripcionExtendidaExtraido.Trim().Length > 500 || descripcionExtendidaExtraido.Trim().Length < 2)
                                        {
                                            listaValidaciones.Add(
                                                string.Format("Fila {0} ; La longitud del campo [Descripcion] debe estar entre 2 y 500 carateres",
                                                (i + 1).ToString()));
                                        }
                                    }

                                    if (!string.IsNullOrEmpty(descripcionExtendidaExtraido))
                                    {
                                        if(descripcionExtendidaExtraido.Trim().Length > 1000)
                                        {
                                            listaValidaciones.Add(
                                                string.Format("Fila {0} ; La longitud máxima del campo [DescripcionExtendida] es de 1000 carateres", 
                                                (i + 1).ToString()));
                                        }
                                    }

                                    if (string.IsNullOrEmpty(precioExtraido))
                                    {
                                        listaValidaciones.Add(string.Format("Fila {0} ; Se requiere el parametro [Precio]", (i + 1).ToString()));
                                    }
                                    else
                                    {
                                        if (!Entidad.Utilitario.Util.EsDecimal(precioExtraido))
                                        {
                                            listaValidaciones.Add(string.Format("Fila {0} ; El parametro [Precio] debe ser un valor numerico", (i + 1).ToString()));
                                        }
                                        else
                                        {
                                            if(Convert.ToDecimal(precioExtraido) <= 0)
                                            {
                                                listaValidaciones.Add(string.Format("Fila {0} ; El parametro [Precio] debe tener un valor mayor a cero", (i + 1).ToString()));
                                            }
                                        }
                                    }
                                }
                                catch
                                {
                                    listaValidaciones.Add(string.Format("Fila {0} ; Error al leer los datos", (i + 1).ToString()));
                                }
                            }
                        }
                        else
                        {
                            listaValidaciones.Add("No se encontro la hoja [Productos]");
                        }
                    }
                }
                catch
                {
                    listaValidaciones.Add("[Catch] Error al intentar leer el archivo");
                }
            }
            else
            {
                listaValidaciones.Add("Error al intentar leer el archivo");
            }

            if (listaValidaciones.Any())
            {
                return false;
            }
            return true;
        }

        private bool ValidarEstructuraExcel(XLWorkbook libro, ref List<string> listaValidaciones)
        {
            listaValidaciones = new List<string>();
            if (libro != null)
            {
                try
                {
                    //using (libro)
                    //{
                        if(libro.Worksheets.Any(x=>x.Name == "Productos"))
                        {
                            //Descripcion	DescripcionExtendida	Precio
                            IXLWorksheet hoja = libro.Worksheet("Productos");
                            IXLRange rango = hoja.RangeUsed();
                            if(rango != null)
                            {
                                if (rango.Rows().Count() > 1)
                                {
                                    if (rango.Rows().Count() <= 51)
                                    {
                                        if (rango.RangeAddress.FirstAddress.RowNumber == 1 && rango.RangeAddress.FirstAddress.ColumnNumber == 1)
                                        {
                                            if (rango.Columns().Count() == 3)
                                            {
                                                if (hoja.Cell(1, 1).Value.ToString().ToLower() == "descripcion" &&
                                                    hoja.Cell(1, 2).Value.ToString().ToLower() == "descripcionextendida" &&
                                                    hoja.Cell(1, 3).Value.ToString().ToLower() == "precio")
                                                {
                                                    return true;
                                                }
                                                else
                                                {
                                                    listaValidaciones.Add("Las columnas esperadas son [Descripcion][DescripcionExtendida][Precio]");
                                                }
                                            }
                                            else
                                            {
                                                listaValidaciones.Add("Solo se admiten archivos de 3 columnas");
                                            }
                                        }
                                        else
                                        {
                                            listaValidaciones.Add("Los datos deben de iniciar desde las primeras filas y columnas");
                                        }
                                    }
                                    else
                                    {
                                        listaValidaciones.Add("Solo se admiten 50 productos por cada importación");
                                    }
                                }
                                else
                                {
                                    listaValidaciones.Add("El rango debe incluir como minimo una fila de registros");
                                }
                            }
                            else
                            {
                                listaValidaciones.Add("Error al hallar el rango usado");
                            }
                        }
                        else
                        {
                            listaValidaciones.Add("No se encontro la hoja [Productos]");
                        }
                    //}
                }
                catch(Exception ex)
                {
                    listaValidaciones.Add("[Catch] Error al intentar leer el archivo");
                }
            }
            else
            {
                listaValidaciones.Add("Error al intentar leer el archivo");
            }
            return false;
        }

    }
}
