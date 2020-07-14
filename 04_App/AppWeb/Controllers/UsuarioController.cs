using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Entidad.Configuracion.Proceso;
using Entidad.Dto.Response.Seguridad;
using Entidad.Dto.Seguridad;
using Entidad.Vo;
using Microsoft.AspNetCore.Mvc;
using ModelosApi.Request.Seguridad;
using Negocio.Repositorio.Seguridad;

namespace AppWeb.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly LnUsuario _lnUsuario = new LnUsuario();
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("ObtenerData")]
        public ActionResult ObtenerData(UsuarioObtenerFiltroDto prm)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnUsuario.Obtener(prm));
            t.Wait();

            return Json(t.Result);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(long id)
        {
            return View();
        }

        // GET: Usuario/Details/5
        public ActionResult ObtenerPorId(long id)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnUsuario.ObtenerPorId(id));
            t.Wait();

            return Json(t.Result);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Registrar(RequestUsuarioRegistrarDtoApi prm)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnUsuario.Registrar(prm));
            t.Wait();

            return Json(t.Result);
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(long id)
        {
            return View();
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Modificar(RequestUsuarioModificarDtoApi prm)//int id, IFormCollection collection)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnUsuario.Modificar(prm));
            t.Wait();

            return Json(t.Result);
        }

        [HttpPost]
        [ActionName("ModificarModoAdmin")]
        //[ValidateAntiForgeryToken]
        public ActionResult ModificarModoAdmin(RequestUsuarioModificarModoAdminDtoApi prm)//int id, IFormCollection collection)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnUsuario.ModificarModoAdmin(prm));
            t.Wait();

            return Json(t.Result);
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Eliminar(long id)//, IFormCollection collection)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnUsuario.Eliminar(id));
            t.Wait();

            return Json(t.Result);
        }

        public UsuarioResponseSubirImagenDto ActualizarImagen()
        {
            UsuarioResponseSubirImagenDto respuesta = new UsuarioResponseSubirImagenDto();
            string urlImagenNueva = string.Empty;

            try
            {
                var idUsuario = Request.Form["IdUsuario"][0];

                bool esError = false;
                if (idUsuario == null) esError = true;
                if (idUsuario == "0") esError = true;
                if (Request.Form.Files == null) esError = true;
                if (!Entidad.Utilitario.Util.EsLong(idUsuario)) esError = true;

                if (!esError)
                {
                    if (Request.Form.Files.Any())
                    {
                        var file = Request.Form.Files[0];
                        if (file.Length > 0)
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
                                RequestUsuarioModificarImagenMetodo1DtoApi filtroApi = new RequestUsuarioModificarImagenMetodo1DtoApi
                                {
                                    IdUsuario = Convert.ToInt64(idUsuario),
                                    ArchivoBytes = archivoBytes,
                                    ExtensionSinPunto = extension
                                };
                                var t = Task.Run(() => _lnUsuario.SubirImagen(filtroApi));
                                t.Wait();
                                if (t.Result != null)
                                {
                                    respuesta = t.Result;
                                }
                            }
                        }
                        else
                        {
                            //Solo Eliminar
                            var t = Task.Run(() => _lnUsuario.EliminarImagen(Convert.ToInt64(idUsuario)));
                            t.Wait();
                            if (t.Result != null)
                            {
                                respuesta = t.Result;
                            }
                        }
                    }
                    else
                    {
                        //Debe de haber por lo menos una imagen
                        respuesta.ListaError.Add(new Entidad.Dto.Global.ErrorDto
                        {
                            Mensaje = "No se ha seleccionado una imágen"
                        });

                        ////Solo Eliminar
                        ////Solo Eliminar
                        //var t = Task.Run(() => _lnUsuario.EliminarImagen(Convert.ToInt64(idUsuario)));
                        //t.Wait();
                        //if (t.Result != null)
                        //{
                        //    respuesta = t.Result;
                        //}
                    }
                }
                else
                {
                    //Error en los parametros
                    respuesta.ListaError.Add(new Entidad.Dto.Global.ErrorDto
                    {
                        Mensaje = "Parametros incompletos para continuar con el proceso"
                    });
                }

            }
            catch (InvalidOperationException invEx)
            {
                Logger.Log(Logger.Level.Error,
                    (string.IsNullOrEmpty(invEx.StackTrace) ? invEx.Message : invEx.StackTrace).Replace(Environment.NewLine, " "));
                respuesta.ListaError.Add(new Entidad.Dto.Global.ErrorDto
                {
                    Mensaje = (string.IsNullOrEmpty(invEx.StackTrace) ? invEx.Message : invEx.StackTrace).Replace(Environment.NewLine, " ")
                });
            }
            catch (Exception ex)
            {
                Logger.Log(Logger.Level.Error, ex.InnerException == null ? ex.Message : ex.InnerException.Message);
                respuesta.ListaError.Add(new Entidad.Dto.Global.ErrorDto
                {
                    Mensaje = ex.InnerException == null ? ex.Message : ex.InnerException.Message
                });
            }

            return respuesta; //Json(respuesta);

        }

        [HttpPost]
        [ActionName("EliminarImagen")]
        public ActionResult EliminarImagen(long id)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnUsuario.EliminarImagen(id));
            t.Wait();

            return Json(t.Result);
        }

    }
}