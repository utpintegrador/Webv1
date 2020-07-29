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
    public class PedidoDetalleController : Controller
    {
        private readonly LnPedidoDetalle _lnPedidoDetalle = new LnPedidoDetalle();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("ObtenerData")]
        public ActionResult ObtenerData(PedidoDetalleObtenerFiltroDto prm)
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

            var t = Task.Run(() => _lnPedidoDetalle.Obtener(prm));
            t.Wait();

            return Json(t.Result);
        }
    }
}