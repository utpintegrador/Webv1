using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppWeb.CustomHandler;
using Entidad.Configuracion.Proceso;
using Entidad.Vo;
using Microsoft.AspNetCore.Mvc;
using ModelosApi.Request.Maestro;
using Negocio.Repositorio.Maestro;
using Entidad.Dto.Maestro;

namespace AppWeb.Controllers
{
    public class ProductoDescuentoController : Controller
    {
        private readonly LnProductoDescuento _lnProductoDescuento = new LnProductoDescuento();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("ObtenerPorIdProducto")]
        public ActionResult ObtenerPorIdProducto(ProductoDescuentoObtenerPorIdProductoFiltroDto prm)
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

            var t = Task.Run(() => _lnProductoDescuento.ObtenerPorIdProducto(prm));
            t.Wait();

            return Json(t.Result);
        }

        // GET: ProductoDescuento/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductoDescuento/Details/5
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

            var t = Task.Run(() => _lnProductoDescuento.ObtenerPorId(id));
            t.Wait();

            return Json(t.Result);
        }

        // GET: ProductoDescuento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductoDescuento/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [ValidationActionFilter]
        public ActionResult Registrar(RequestProductoDescuentoRegistrarDtoApi prm)
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

            var t = Task.Run(() => _lnProductoDescuento.Registrar(prm));
            t.Wait();

            return Json(t.Result);
        }

        // GET: ProductoDescuento/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductoDescuento/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [ValidationActionFilter]
        public ActionResult Modificar(RequestProductoDescuentoModificarDtoApi prm)//int id, IFormCollection collection)
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

            var t = Task.Run(() => _lnProductoDescuento.Modificar(prm));
            t.Wait();

            return Json(t.Result);
        }

        // POST: ProductoDescuento/Delete/5
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

            var t = Task.Run(() => _lnProductoDescuento.Eliminar(id));
            t.Wait();

            return Json(t.Result);
        }
    }
}