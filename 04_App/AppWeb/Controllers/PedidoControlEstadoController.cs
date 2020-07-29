using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidad.Configuracion.Proceso;
using Entidad.Vo;
using Microsoft.AspNetCore.Mvc;
using Negocio.Repositorio.Seguimiento;

namespace AppWeb.Controllers
{
    public class PedidoControlEstadoController : Controller
    {
        private readonly LnPedidoControlEstado _lnPedidoControlEstado = new LnPedidoControlEstado();
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ObtenerPorIdPedido(long idPedido)
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

            var t = Task.Run(() => _lnPedidoControlEstado.ObtenerPorIdPedido(idPedido));
            t.Wait();

            return Json(t.Result);
        }
    }
}