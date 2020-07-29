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
    public class CompraController : Controller
    {
        private readonly LnCompra _lnCompra = new LnCompra();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("ObtenerData")]
        public ActionResult ObtenerData(CompraObtenerFiltroDto prm)
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

            var t = Task.Run(() => _lnCompra.Obtener(prm));
            t.Wait();

            return Json(t.Result);
        }

        [HttpPost]
        [ActionName("ObtenerPorIdUsuario")]
        public ActionResult ObtenerPorIdUsuario(CompraObtenerPorIdUsuarioFiltroDto prm)
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

            var t = Task.Run(() => _lnCompra.ObtenerPorIdUsuario(prm));
            t.Wait();

            return Json(t.Result);
        }

        public ActionResult Details(long id)
        {
            return View();
        }
    }
}