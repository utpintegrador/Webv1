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
    public class TipoUsuarioController : Controller
    {
        private readonly LnTipoUsuario _lnTipoUsuario = new LnTipoUsuario();
        // GET: TipoUsuario
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("ObtenerData")]
        public ActionResult ObtenerData(TipoUsuarioObtenerFiltroDto prm)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnTipoUsuario.Obtener(prm));
            t.Wait();

            return Json(t.Result);
        }

        // GET: TipoUsuario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TipoUsuario/Details/5
        public ActionResult ObtenerPorId(int id)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnTipoUsuario.ObtenerPorId(id));
            t.Wait();

            return Json(t.Result);
        }

        // GET: TipoUsuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoUsuario/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Registrar(RequestTipoUsuarioRegistrarDtoApi prm)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnTipoUsuario.Registrar(prm));
            t.Wait();

            return Json(t.Result);
        }

        // GET: TipoUsuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipoUsuario/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Modificar(RequestTipoUsuarioModificarDtoApi prm)//int id, IFormCollection collection)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnTipoUsuario.Modificar(prm));
            t.Wait();

            return Json(t.Result);
        }

        // POST: TipoUsuario/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id)//, IFormCollection collection)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnTipoUsuario.Eliminar(id));
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

            var t = Task.Run(() => _lnTipoUsuario.ObtenerCombo());
            t.Wait();

            return Json(t.Result);
        }
    }
}