using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AppWeb.CustomHandler;
using Entidad.Configuracion.Proceso;
using ModelosApi.Dto.Maestro;
using ModelosApi.Request.Maestro;
using Entidad.Vo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelosApi.Response.Comun;
using ModelosApi.Response.Maestro;
using Negocio.Repositorio.Maestro;
using Entidad.Dto.Maestro;

namespace AppWeb.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly LnCategoria _lnCategoria = new LnCategoria();
        // GET: Categoria
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("ObtenerData")]
        public ActionResult ObtenerData(CategoriaObtenerFiltroDto prm)
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

            var t = Task.Run(() => _lnCategoria.Obtener(prm));
            t.Wait();

            return Json(t.Result);
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Categoria/Details/5
        public ActionResult ObtenerPorId(int id)
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

            var t = Task.Run(() => _lnCategoria.ObtenerPorId(id));
            t.Wait();

            return Json(t.Result);
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [ValidationActionFilter]
        public ActionResult Registrar(RequestCategoriaRegistrarDtoApi prm)
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

            var t = Task.Run(() => _lnCategoria.Registrar(prm));
            t.Wait();

            return Json(t.Result);
        }

        // GET: Categoria/Edit/5
        public ActionResult Edit(long id)
        {
            return View();
        }

        // POST: Categoria/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [ValidationActionFilter]
        public ActionResult Modificar(RequestCategoriaModificarDtoApi prm)//int id, IFormCollection collection)
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

            var t = Task.Run(() => _lnCategoria.Modificar(prm));
            t.Wait();

            return Json(t.Result);
        }

        // POST: Categoria/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id)//, IFormCollection collection)
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

            var t = Task.Run(() => _lnCategoria.Eliminar(id));
            t.Wait();

            return Json(t.Result);
        }

        [HttpGet]
        public ActionResult ObtenerCombo(int idEstado)
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

            var t = Task.Run(() => _lnCategoria.ObtenerCombo(idEstado));
            t.Wait();

            return Json(t.Result);
        }

        [Route("/Categoria/{id}/Imagenes")]
        public ActionResult Imagenes(int id)
        {
            //Problema: Verificar que el producto le pertenezca al IdUsuario que ha iniciado sesion
            //Solucion: seria bueno que se envie un parametro mas con el IdUsuario, esto evitaria que un usuario ingrese a un producto que no es de él
            //Método: cuando traes el Producto, que tambien lo traiga con el IdUsuario
            CategoriaObtenerPorIdDtoApi entidad = new CategoriaObtenerPorIdDtoApi();
            entidad.IdCategoria = id;
            return View(entidad);
        }

        [HttpPost]
        public ActionResult SubirImagenes(IFormFile file)
        {

            string urlImagenNueva = string.Empty;
            ResponseCategoriaSubirImagenDtoApi respuesta = new ResponseCategoriaSubirImagenDtoApi();
            try
            {
                if (file == null)
                {
                    respuesta.ListaError.Add(new ErrorDtoApi { Mensaje = "El archivo no ha sido cargado" });
                    return BadRequest(respuesta);
                }
                string idCategoria = string.Empty;
                try
                {
                    idCategoria = Request.Form["IdCategoria"][0];
                }
                catch
                {
                    respuesta.ListaError.Add(new ErrorDtoApi { Mensaje = "El IdCategoria no ha sido cargado" });
                    return BadRequest(respuesta);
                }

                if (file.Length == 0)
                {
                    respuesta.ListaError.Add(new ErrorDtoApi { Mensaje = "El archivo no ha sido cargado" });
                    return BadRequest(respuesta);
                }

                bool esError = false;
                if (idCategoria == null) esError = true;
                if (idCategoria == "0") esError = true;
                if (Request.Form.Files == null) esError = true;
                if (!Entidad.Utilitario.Util.EsInt(idCategoria)) esError = true;

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
                        RequestCategoriaModificarImagenMetodo1DtoApi prmApi = new RequestCategoriaModificarImagenMetodo1DtoApi
                        {
                            IdCategoria = Convert.ToInt32(idCategoria),
                            ExtensionSinPunto = extension,
                            ArchivoBytes = archivoBytes
                        };

                        var t = Task.Run(() => _lnCategoria.SubirImagen(prmApi));
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
    }
}