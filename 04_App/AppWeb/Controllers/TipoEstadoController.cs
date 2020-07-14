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
    public class TipoEstadoController : Controller
    {
        private readonly LnTipoEstado _lnTipoEstado = new LnTipoEstado();
        // GET: TipoEstado
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("ObtenerData")]
        public ActionResult ObtenerData(TipoEstadoObtenerFiltroDto prm)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnTipoEstado.Obtener(prm));
            t.Wait();

            return Json(t.Result);
        }

        // GET: TipoEstado/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TipoEstado/Details/5
        public ActionResult ObtenerPorId(int id)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnTipoEstado.ObtenerPorId(id));
            t.Wait();

            return Json(t.Result);
        }

        // GET: TipoEstado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoEstado/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Registrar(RequestTipoEstadoRegistrarDtoApi prm)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnTipoEstado.Registrar(prm));
            t.Wait();

            return Json(t.Result);
        }

        // GET: TipoEstado/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipoEstado/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Modificar(RequestTipoEstadoModificarDtoApi prm)//int id, IFormCollection collection)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnTipoEstado.Modificar(prm));
            t.Wait();

            return Json(t.Result);
        }

        // POST: TipoEstado/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id)//, IFormCollection collection)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnTipoEstado.Eliminar(id));
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

            var t = Task.Run(() => _lnTipoEstado.ObtenerCombo());
            t.Wait();

            return Json(t.Result);
        }
    }
}