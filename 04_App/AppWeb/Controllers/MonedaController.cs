using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidad.Configuracion.Proceso;
using Entidad.Dto.Maestro;
using Entidad.Request.Maestro;
using Entidad.Vo;
using Microsoft.AspNetCore.Mvc;
using Negocio.Repositorio.Maestro;

namespace AppWeb.Controllers
{
    public class MonedaController : Controller
    {
        private readonly LnMoneda _lnMoneda = new LnMoneda();
        // GET: Moneda
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("ObtenerData")]
        public ActionResult ObtenerData(MonedaObtenerFiltroDto prm)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnMoneda.Obtener(prm));
            t.Wait();

            return Json(t.Result);
        }

        // GET: Moneda/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Moneda/Details/5
        public ActionResult ObtenerPorId(int id)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnMoneda.ObtenerPorId(id));
            t.Wait();

            return Json(t.Result);
        }

        // GET: Moneda/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Moneda/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Registrar(RequestMonedaRegistrarDtoApi prm)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnMoneda.Registrar(prm));
            t.Wait();

            return Json(t.Result);
        }

        // GET: Moneda/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Moneda/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Modificar(RequestMonedaModificarDtoApi prm)//int id, IFormCollection collection)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnMoneda.Modificar(prm));
            t.Wait();

            return Json(t.Result);
        }

        // POST: Moneda/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id)//, IFormCollection collection)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnMoneda.Eliminar(id));
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
            }

            var t = Task.Run(() => _lnMoneda.ObtenerCombo());
            t.Wait();

            return Json(t.Result);
        }

    }
}