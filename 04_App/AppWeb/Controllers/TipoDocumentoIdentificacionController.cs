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
    public class TipoDocumentoIdentificacionController : Controller
    {
        private readonly LnTipoDocumentoIdentificacion _lnTipoDocumentoIdentificacion = new LnTipoDocumentoIdentificacion();
        // GET: TipoDocumentoIdentificacion
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("ObtenerData")]
        public ActionResult ObtenerData(TipoDocumentoIdentificacionObtenerFiltroDto prm)
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

            var t = Task.Run(() => _lnTipoDocumentoIdentificacion.Obtener(prm));
            t.Wait();

            return Json(t.Result);
        }

        // GET: TipoDocumentoIdentificacion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TipoDocumentoIdentificacion/Details/5
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

            var t = Task.Run(() => _lnTipoDocumentoIdentificacion.ObtenerPorId(id));
            t.Wait();

            return Json(t.Result);
        }

        // GET: TipoDocumentoIdentificacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoDocumentoIdentificacion/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [ValidationActionFilter]
        public ActionResult Registrar(RequestTipoDocumentoIdentificacionRegistrarDtoApi prm)
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

            var t = Task.Run(() => _lnTipoDocumentoIdentificacion.Registrar(prm));
            t.Wait();

            return Json(t.Result);
        }

        // GET: TipoDocumentoIdentificacion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipoDocumentoIdentificacion/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [ValidationActionFilter]
        public ActionResult Modificar(RequestTipoDocumentoIdentificacionModificarDtoApi prm)//int id, IFormCollection collection)
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

            var t = Task.Run(() => _lnTipoDocumentoIdentificacion.Modificar(prm));
            t.Wait();

            return Json(t.Result);
        }

        // POST: TipoDocumentoIdentificacion/Delete/5
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

            var t = Task.Run(() => _lnTipoDocumentoIdentificacion.Eliminar(id));
            t.Wait();

            return Json(t.Result);
        }

        [HttpGet]
        public ActionResult ObtenerCombo()
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

            var t = Task.Run(() => _lnTipoDocumentoIdentificacion.ObtenerCombo());
            t.Wait();

            return Json(t.Result);
        }
    }
}