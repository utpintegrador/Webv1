using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppWeb.CustomHandler;
using Entidad.Configuracion.Proceso;
using ModelosApi.Request.Transaccion;
using Entidad.Vo;
using Microsoft.AspNetCore.Mvc;
using Negocio.Repositorio.Transaccion;

namespace AppWeb.Controllers
{
    public class PedidoController : Controller
    {
        private readonly LnPedido _lnPedido = new LnPedido();
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ObtenerNotaPedidoPorId(long id)
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

            var t = Task.Run(() => _lnPedido.ObtenerNotaPedidoPorId(id));
            t.Wait();

            return Json(t.Result);
        }

        [HttpGet]
        public ActionResult ObtenerPendientesAtencionPorIdUsuario(long id)
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

            var t = Task.Run(() => _lnPedido.ObtenerPendientesAtencionPorIdUsuario(id));
            t.Wait();

            return Json(t.Result);
        }

        [HttpGet]
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

            var t = Task.Run(() => _lnPedido.ObtenerPorId(id));
            t.Wait();

            return Json(t.Result);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [ValidationActionFilter]
        public ActionResult ModificarEstadoPorParteDeVendedor(RequestPedidoModificarEstadoPorParteDeVendedorDtoApi prm)//int id, IFormCollection collection)
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

            var t = Task.Run(() => _lnPedido.ModificarEstadoPorParteDeVendedor(prm));
            t.Wait();

            return Json(t.Result);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [ValidationActionFilter]
        public ActionResult ModificarEstadoPorParteDeComprador(RequestPedidoModificarEstadoPorParteDeCompradorDtoApi prm)//int id, IFormCollection collection)
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

            var t = Task.Run(() => _lnPedido.ModificarEstadoPorParteDeComprador(prm));
            t.Wait();

            return Json(t.Result);
        }
    }
}