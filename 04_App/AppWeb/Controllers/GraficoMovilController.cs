using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppWeb.CustomHandler;
using Entidad.Configuracion.Proceso;
using Entidad.Vo;
using Microsoft.AspNetCore.Mvc;
using ModelosApi.Request.Grafico;
using Negocio.Repositorio.Grafico;

namespace AppWeb.Controllers
{
    public class GraficoMovilController : Controller
    {
        private readonly LnGraficoMovil _lnGraficoMovil = new LnGraficoMovil();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidationActionFilter]
        public ActionResult ObtenerResumenCompras(RequestGraficoObtenerResumenComprasDtoApi prm)
        {
            if (!ModelState.IsValid) return Json(BadRequest());
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();

                if (string.IsNullOrEmpty(ConfiguracionToken.ConfigToken))
                {
                    return RedirectToAction("Login", "Home");
                }
            }

            var t = Task.Run(() => _lnGraficoMovil.ObtenerResumenCompras(prm));
            t.Wait();

            return Json(t.Result);
        }

        [HttpPost]
        [ValidationActionFilter]
        public ActionResult ObtenerResumenVentas(RequestGraficoObtenerResumenVentasDtoApi prm)
        {
            if (!ModelState.IsValid) return Json(BadRequest());
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();

                if (string.IsNullOrEmpty(ConfiguracionToken.ConfigToken))
                {
                    return RedirectToAction("Login", "Home");
                }
            }

            var t = Task.Run(() => _lnGraficoMovil.ObtenerResumenVentas(prm));
            t.Wait();

            return Json(t.Result);
        }
    }
}