using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppWeb.CustomHandler;
using Entidad.Configuracion.Proceso;
using ModelosApi.Dto.Maestro;
using ModelosApi.Request.Maestro;
using Entidad.Vo;
using Microsoft.AspNetCore.Mvc;
using Negocio.Repositorio.Maestro;
using Entidad.Dto.Maestro;
using Microsoft.AspNetCore.Http;
using ModelosApi.Response.Comun;
using System.IO;
using System;
using ModelosApi.Response.Maestro;

namespace AppWeb.Controllers
{
    public class ProductoController : Controller
    {
        private readonly LnProducto _lnProducto = new LnProducto();
        // GET: Producto
        public ActionResult Index()
        {
            return View();
        }

        [Route("/Producto/{id}/Imagenes")]
        public ActionResult Imagenes(long id)
        {
            //Problema: Verificar que el producto le pertenezca al IdUsuario que ha iniciado sesion
            //Solucion: seria bueno que se envie un parametro mas con el IdUsuario, esto evitaria que un usuario ingrese a un producto que no es de él
            //Método: cuando traes el Producto, que tambien lo traiga con el IdUsuario
            ProductoAtributoDto entidad = new ProductoAtributoDto
            {
                IdProducto = id
            };
            return View(entidad);
        }

        [HttpPost]
        [ActionName("ObtenerData")]
        public ActionResult ObtenerData(ProductoObtenerFiltroDto prm)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();

                if (string.IsNullOrEmpty(ConfiguracionToken.ConfigToken))
                {
                    return RedirectToAction("Login", "Home");
                }
            }

            var t = Task.Run(() => _lnProducto.Obtener(prm));
            t.Wait();

            return Json(t.Result);
        }

        // GET: Producto/Details/5
        public ActionResult Details(long id)
        {
            return View();
        }

        // GET: Producto/Details/5
        public ActionResult ObtenerPorId(long id)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();

                if (string.IsNullOrEmpty(ConfiguracionToken.ConfigToken))
                {
                    return RedirectToAction("Login", "Home");
                }
            }

            var t = Task.Run(() => _lnProducto.ObtenerPorId(id));
            t.Wait();

            return Json(t.Result);
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [ValidationActionFilter]
        public ActionResult Registrar(RequestProductoRegistrarDtoApi prm)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();

                if (string.IsNullOrEmpty(ConfiguracionToken.ConfigToken))
                {
                    return RedirectToAction("Login", "Home");
                }
            }

            var t = Task.Run(() => _lnProducto.Registrar(prm));
            t.Wait();

            return Json(t.Result);
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(long id)
        {
            return View();
        }

        // POST: Producto/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [ValidationActionFilter]
        public ActionResult Modificar(RequestProductoModificarDtoApi prm)//int id, IFormCollection collection)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();

                if (string.IsNullOrEmpty(ConfiguracionToken.ConfigToken))
                {
                    return RedirectToAction("Login", "Home");
                }
            }

            var t = Task.Run(() => _lnProducto.Modificar(prm));
            t.Wait();

            return Json(t.Result);
        }

        // POST: Producto/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Eliminar(long id)//, IFormCollection collection)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();

                if (string.IsNullOrEmpty(ConfiguracionToken.ConfigToken))
                {
                    return RedirectToAction("Login", "Home");
                }
            }

            var t = Task.Run(() => _lnProducto.Eliminar(id));
            t.Wait();

            return Json(t.Result);
        }

        [HttpPost]
        public ActionResult EliminarSeleccionados(string arrayObjeto)//RequestProductoEliminarMasivoDtoApi prm)
        {
            if(arrayObjeto != null)
            {
                var prm = Newtonsoft.Json.JsonConvert.DeserializeObject<RequestProductoEliminarMasivoDtoApi>(arrayObjeto);
                if(prm != null)
                {
                    if (prm.ListaIdProducto != null)
                    {
                        if (prm.ListaIdProducto.Any())
                        {
                            if (ConstanteVo.ActivarLLamadasConToken)
                            {
                                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();

                                if (string.IsNullOrEmpty(ConfiguracionToken.ConfigToken))
                                {
                                    return RedirectToAction("Login", "Home");
                                }
                            }

                            var t = Task.Run(() => _lnProducto.EliminarMasivo(prm));
                            t.Wait();

                            return Json(t.Result);
                        }
                    }
                }
            }
            return BadRequest();
        }

        [HttpPost]
        public ActionResult SubirArchivo(IFormFile file)
        {
            string urlImagenNueva = string.Empty;
            ResponseProductoImportarDtoApi respuesta = new ResponseProductoImportarDtoApi
            {
                StatusCode = 400,
                ListaError = new List<ErrorDtoApi>()
            };
            try
            {
                if (file == null)
                {
                    respuesta.ListaError.Add(new ErrorDtoApi { Mensaje = "El archivo no ha sido cargado" });
                    return BadRequest(respuesta);
                }
                string idNegocio = string.Empty;
                string idMoneda = string.Empty;
                string idCategoria = string.Empty;
                try
                {
                    idNegocio = Request.Form["IdNegocio"][0];
                    idMoneda = Request.Form["IdMoneda"][0];
                    idCategoria = Request.Form["IdCategoria"][0];

                    if (idNegocio == "0")
                    {
                        respuesta.ListaError.Add(new ErrorDtoApi { Mensaje = "Seleccione el negocio" });
                    }
                    if (idMoneda == "0")
                    {
                        respuesta.ListaError.Add(new ErrorDtoApi { Mensaje = "Seleccione la moneda" });
                    }
                    if (idCategoria == "0")
                    {
                        respuesta.ListaError.Add(new ErrorDtoApi { Mensaje = "Seleccione la categoria" });
                    }
                    if (respuesta.ListaError.Any())
                    {
                        respuesta.StatusCode = 400;
                        return BadRequest(respuesta);
                    }
                }
                catch
                {
                    respuesta.ListaError.Add(new ErrorDtoApi { Mensaje = "Seleccione el negocio" });
                    return BadRequest(respuesta);
                }

                if (file.Length == 0)
                {
                    respuesta.ListaError.Add(new ErrorDtoApi { Mensaje = "El archivo no ha sido cargado" });
                    return BadRequest(respuesta);
                }

                bool esError = false;
                if (idNegocio == null) esError = true;
                if (idNegocio == "0") esError = true;
                if (Request.Form.Files == null) esError = true;
                if (!Entidad.Utilitario.Util.EsLong(idNegocio)) esError = true;

                if (!esError)
                {


                    var nombreArchivo = System.Net.Http.Headers.ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    string extension = Path.GetExtension(nombreArchivo).Trim().Replace(".", string.Empty).ToLower();

                    if(extension != "xlsx")
                    {
                        respuesta.ListaError.Add(new ErrorDtoApi { Mensaje = "Solo se admiten archivos .xlsx" });
                        return BadRequest(respuesta);
                    }

                    byte[] archivoBytes;
                    using (var memoryStream = new MemoryStream())
                    {
                        file.CopyTo(memoryStream);
                        archivoBytes = memoryStream.ToArray();
                    }

                    if (archivoBytes != null)
                    {
                        //ResponseProductoImportarDtoApi
                        RequestProductoImportarDtoApi prmApi = new RequestProductoImportarDtoApi
                        {
                            IdNegocio = Convert.ToInt64(idNegocio),
                            ExtensionSinPunto = extension,
                            ArchivoBytes = archivoBytes,
                            IdCategoria  = Convert.ToInt32(idCategoria),
                            IdMoneda = Convert.ToInt32(idMoneda)
                        };

                        var t = Task.Run(() => _lnProducto.Importar(prmApi));
                        t.Wait();
                        if (t.Result != null)
                        {
                            respuesta = t.Result;
                        }
                    }
                }
                else
                {
                    //Error en los parametros
                    respuesta.ListaError.Add(new ErrorDtoApi { Mensaje = "Parametros incompletos para continuar con el proceso" });
                    return BadRequest(respuesta);
                }

            }
            catch (InvalidOperationException invEx)
            {
                string mensajeInvEx = (string.IsNullOrEmpty(invEx.StackTrace) ? invEx.Message : invEx.StackTrace).Replace(Environment.NewLine, " ");
                Logger.Log(Logger.Level.Error, mensajeInvEx);
                respuesta.ListaError.Add(new ErrorDtoApi { Mensaje = string.Format("[InvalidOperationException]{0}", mensajeInvEx) });
                return BadRequest(respuesta);
            }
            catch (Exception ex)
            {
                string mensajeEx = (ex.InnerException == null ? ex.Message : ex.InnerException.Message).Replace(Environment.NewLine, " ");
                Logger.Log(Logger.Level.Error, mensajeEx);
                respuesta.ListaError.Add(new ErrorDtoApi { Mensaje = string.Format("[Exception]{0}", mensajeEx) });
                return BadRequest(respuesta);
            }

            if (respuesta.StatusCode == 400)
            {
                return BadRequest(respuesta);
            }

            if (respuesta.ListaError.Any()) {
                respuesta.StatusCode = 400;
                return BadRequest(respuesta);
            }
            respuesta.StatusCode = 200;
            return Ok(respuesta);
        }

        //[Route("/Producto/{id}/Descuentos")]
        //public ActionResult Descuentos(long id)
        //{
        //    //Problema: Verificar que el producto le pertenezca al IdUsuario que ha iniciado sesion
        //    //Solucion: seria bueno que se envie un parametro mas con el IdUsuario, esto evitaria que un usuario ingrese a un producto que no es de él
        //    //Método: cuando traes el Producto, que tambien lo traiga con el IdUsuario
        //    ProductoAtributoDto entidad = new ProductoAtributoDto();
        //    entidad.IdProducto = id;
        //    return View(entidad);
        //}
    }

    public class Producto
    {
        public long IdProducto { get; set; }
    }
}