using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidad.Configuracion.Proceso;
using Entidad.Vo;
using Microsoft.AspNetCore.Mvc;
using Negocio.Repositorio.Transaccion;
using Entidad.Dto.Transaccion;

namespace AppWeb.Controllers
{
    public class VentaController : Controller
    {
        private readonly LnVenta _lnVenta = new LnVenta();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("ObtenerData")]
        public ActionResult ObtenerData(VentaObtenerFiltroDto prm)
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

            var t = Task.Run(() => _lnVenta.Obtener(prm));
            t.Wait();

            return Json(t.Result);
        }

        [HttpPost]
        [ActionName("ObtenerPorIdUsuario")]
        public ActionResult ObtenerPorIdUsuario(VentaObtenerPorIdUsuarioFiltroDto prm)
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

            var t = Task.Run(() => _lnVenta.ObtenerPorIdUsuario(prm));
            t.Wait();

            return Json(t.Result);
        }

        public ActionResult Details(long id)
        {
            return View();
        }
    }
}