using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Entidad.Configuracion.Proceso;
using ModelosApi.Request.Maestro;
using Entidad.Vo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelosApi.Response.Comun;
using ModelosApi.Response.Maestro;
using Negocio.Repositorio.Maestro;

namespace AppWeb.Controllers
{
    public class ProductoImagenController : Controller
    {
        private readonly LnProductoImagen _lnProductoImagen = new LnProductoImagen();
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Obtener(long id)
        {
            LnProducto lnProducto = new LnProducto();
            //Problema: Verificar que el producto le pertenezca al IdUsuario que ha iniciado sesion
            //Solucion: seria bueno que se envie un parametro mas con el IdUsuario, esto evitaria que un usuario ingrese a un producto que no es de él
            //Método: cuando traes el Producto, que tambien lo traiga con el IdUsuario
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();

                if (string.IsNullOrEmpty(ConfiguracionToken.ConfigToken))
                {
                    return RedirectToAction("Login", "Home");
                }
            }

            var t = Task.Run(() => lnProducto.ObtenerPorId(id));
            t.Wait();

            return Json(t.Result);
        }

        [HttpPost]
        public ActionResult SubirImagenes(IFormFile file)
        {
            string urlImagenNueva = string.Empty;
            ResponseProductoSubirImagenDtoApi respuesta = new ResponseProductoSubirImagenDtoApi();
            try
            {
                if(file == null)
                {
                    respuesta.ListaError.Add(new ErrorDtoApi { Mensaje = "El archivo no ha sido cargado" });
                    return BadRequest(respuesta);
                }
                string idProducto = string.Empty;
                try
                {
                    idProducto = Request.Form["IdProducto"][0];
                }
                catch
                {
                    respuesta.ListaError.Add(new ErrorDtoApi { Mensaje = "El IdProducto no ha sido cargado" });
                    return BadRequest(respuesta);
                }

                if (file.Length == 0)
                {
                    respuesta.ListaError.Add(new ErrorDtoApi { Mensaje = "El archivo no ha sido cargado" });
                    return BadRequest(respuesta);
                }

                bool esError = false;
                if (idProducto == null) esError = true;
                if (idProducto == "0") esError = true;
                if (Request.Form.Files == null) esError = true;
                if (!Entidad.Utilitario.Util.EsLong(idProducto)) esError = true;

                if (!esError)
                {


                    var nombreArchivo = System.Net.Http.Headers.ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    string extension = Path.GetExtension(nombreArchivo).Trim().Replace(".", string.Empty).ToLower();
                    byte[] archivoBytes;
                    using (var memoryStream = new MemoryStream())
                    {
                        file.CopyTo(memoryStream);
                        archivoBytes = memoryStream.ToArray();
                    }

                    if (archivoBytes != null)
                    {
                        RequestProductoImagenModificarImagenMetodo1DtoApi prmApi = new RequestProductoImagenModificarImagenMetodo1DtoApi
                        {
                            IdProducto = Convert.ToInt64(idProducto),
                            ExtensionSinPunto = extension,
                            ArchivoBytes = archivoBytes
                        };

                        var t = Task.Run(() => _lnProductoImagen.SubirImagen(prmApi));
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

            return Ok(respuesta);
        }

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

            var t = Task.Run(() => _lnProductoImagen.Eliminar(id));
            t.Wait();

            return Json(t.Result);
        }

    }
}