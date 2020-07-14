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
    public class TipoBusquedaController : Controller
    {
        private readonly LnTipoBusqueda _lnTipoBusqueda = new LnTipoBusqueda();
        // GET: TipoBusqueda
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("ObtenerData")]
        public ActionResult ObtenerData(TipoBusquedaObtenerFiltroDto prm)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnTipoBusqueda.Obtener(prm));
            t.Wait();

            return Json(t.Result);
        }

        // GET: TipoBusqueda/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TipoBusqueda/Details/5
        public ActionResult ObtenerPorId(int id)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnTipoBusqueda.ObtenerPorId(id));
            t.Wait();

            return Json(t.Result);
        }

        // GET: TipoBusqueda/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoBusqueda/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Registrar(RequestTipoBusquedaRegistrarDtoApi prm)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnTipoBusqueda.Registrar(prm));
            t.Wait();

            return Json(t.Result);
        }

        // GET: TipoBusqueda/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipoBusqueda/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Modificar(RequestTipoBusquedaModificarDtoApi prm)//int id, IFormCollection collection)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnTipoBusqueda.Modificar(prm));
            t.Wait();

            return Json(t.Result);
        }

        // POST: TipoBusqueda/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id)//, IFormCollection collection)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnTipoBusqueda.Eliminar(id));
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

            var t = Task.Run(() => _lnTipoBusqueda.ObtenerCombo());
            t.Wait();

            return Json(t.Result);
        }
    }
}