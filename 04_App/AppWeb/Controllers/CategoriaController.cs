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
    public class CategoriaController : Controller
    {
        private readonly LnCategoria _lnCategoria = new LnCategoria();
        // GET: Categoria
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("ObtenerData")]
        public ActionResult ObtenerData(CategoriaObtenerFiltroDto prm)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnCategoria.Obtener(prm));
            t.Wait();

            return Json(t.Result);
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Categoria/Details/5
        public ActionResult ObtenerPorId(int id)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnCategoria.ObtenerPorId(id));
            t.Wait();

            return Json(t.Result);
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Registrar(RequestCategoriaRegistrarDtoApi prm)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnCategoria.Registrar(prm));
            t.Wait();

            return Json(t.Result);
        }

        // GET: Categoria/Edit/5
        public ActionResult Edit(long id)
        {
            return View();
        }

        // POST: Categoria/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Modificar(RequestCategoriaModificarDtoApi prm)//int id, IFormCollection collection)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnCategoria.Modificar(prm));
            t.Wait();

            return Json(t.Result);
        }

        // POST: Categoria/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id)//, IFormCollection collection)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnCategoria.Eliminar(id));
            t.Wait();

            return Json(t.Result);
        }

        [HttpGet]
        public ActionResult ObtenerCombo(int idEstado)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnCategoria.ObtenerCombo(idEstado));
            t.Wait();

            return Json(t.Result);
        }
    }
}