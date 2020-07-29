using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppWeb.CustomHandler;
using Entidad.Configuracion.Proceso;
using ModelosApi.Request.Maestro;
using Entidad.Vo;
using Microsoft.AspNetCore.Mvc;
using Negocio.Repositorio.Maestro;
using Entidad.Dto.Maestro;

namespace AppWeb.Controllers
{
    public class NegocioUbicacionController : Controller
    {
        private readonly LnNegocioUbicacion _lnNegocioUbicacion = new LnNegocioUbicacion();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("ObtenerPorIdNegocio")]
        public ActionResult ObtenerPorIdNegocio(NegocioUbicacionObtenerPorIdNegocioFiltroDto prm)
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

            var t = Task.Run(() => _lnNegocioUbicacion.ObtenerPorIdNegocio(prm));
            t.Wait();

            return Json(t.Result);
        }

        [HttpPost]
        [ActionName("ObtenerPorIdUsuario")]
        public ActionResult ObtenerPorIdUsuario(NegocioUbicacionObtenerPorIdUsuarioFiltroDto prm)
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

            var t = Task.Run(() => _lnNegocioUbicacion.ObtenerPorIdUsuario(prm));
            t.Wait();

            return Json(t.Result);
        }

        // GET: NegocioUbicacion/Details/5
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

            var t = Task.Run(() => _lnNegocioUbicacion.ObtenerPorId(id));
            t.Wait();

            return Json(t.Result);
        }

        // POST: NegocioUbicacion/Delete/5
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

            var t = Task.Run(() => _lnNegocioUbicacion.Eliminar(id));
            t.Wait();

            return Json(t.Result);
        }

        // GET: NegocioUbicacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: NegocioUbicacion/Edit/5
        public ActionResult Edit(long id)
        {
            return View();
        }


        // POST: NegocioUbicacion/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [ValidationActionFilter]
        public ActionResult Registrar(RequestNegocioUbicacionRegistrarDtoApi prm)
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

            var t = Task.Run(() => _lnNegocioUbicacion.Registrar(prm));
            t.Wait();

            return Json(t.Result);
        }

        // POST: NegocioUbicacion/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [ValidationActionFilter]
        public ActionResult Modificar(RequestNegocioUbicacionModificarDtoApi prm)//int id, IFormCollection collection)
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

            var t = Task.Run(() => _lnNegocioUbicacion.Modificar(prm));
            t.Wait();

            return Json(t.Result);
        }

    }
}