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
    public class EstadoController : Controller
    {
        private readonly LnEstado _lnEstado = new LnEstado();
        // GET: Estado
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("ObtenerData")]
        public ActionResult ObtenerData(EstadoObtenerFiltroDto prm)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnEstado.Obtener(prm));
            t.Wait();

            return Json(t.Result);
        }

        // GET: Estado/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Estado/Details/5
        public ActionResult ObtenerPorId(int id)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnEstado.ObtenerPorId(id));
            t.Wait();

            return Json(t.Result);
        }

        // GET: Estado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estado/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Registrar(RequestEstadoRegistrarDtoApi prm)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnEstado.Registrar(prm));
            t.Wait();

            return Json(t.Result);
        }

        // GET: Estado/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Estado/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Modificar(RequestEstadoModificarDtoApi prm)//int id, IFormCollection collection)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnEstado.Modificar(prm));
            t.Wait();

            return Json(t.Result);
        }

        // POST: Estado/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id)//, IFormCollection collection)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnEstado.Eliminar(id));
            t.Wait();

            return Json(t.Result);
        }


        [HttpGet]
        public ActionResult ObtenerCombo(int idTipoEstado)//, string primerItem)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnEstado.ObtenerCombo(idTipoEstado));
            t.Wait();

            return Json(t.Result);

        }

    }
}