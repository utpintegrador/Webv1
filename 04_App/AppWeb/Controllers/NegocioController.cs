using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppWeb.CustomHandler;
using Entidad.Configuracion.Proceso;
using ModelosApi.Request.Maestro;
using Entidad.Vo;
using Microsoft.AspNetCore.Mvc;
using Negocio.Repositorio.Maestro;
using Entidad.Dto.Maestro;

namespace AppWeb.Controllers
{
    public class NegocioController : Controller
    {
        private readonly LnNegocio _lnNegocio = new LnNegocio();
        // GET: Negocio
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Producto()
        {
            return View();
        }

        [HttpPost]
        [ActionName("ObtenerData")]
        public ActionResult ObtenerData(NegocioObtenerFiltroDto prm)
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

            var t = Task.Run(() => _lnNegocio.Obtener(prm));
            t.Wait();

            return Json(t.Result);
        }

        [HttpPost]
        [ActionName("ObtenerCercanos")]
        public ActionResult ObtenerCercanos(NegocioObtenerCercanosFiltroDto prm)
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

            var t = Task.Run(() => _lnNegocio.ObtenerCercanos(prm));
            t.Wait();

            return Json(t.Result);
        }

        // GET: Negocio/Details/5
        public ActionResult Details(long id)
        {
            return View();
        }

        // GET: Negocio/Details/5
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

            var t = Task.Run(() => _lnNegocio.ObtenerPorId(id));
            t.Wait();

            return Json(t.Result);
        }

        // GET: Negocio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Negocio/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [ValidationActionFilter]
        public ActionResult Registrar(RequestNegocioRegistrarDtoApi prm)
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

            var t = Task.Run(() => _lnNegocio.Registrar(prm));
            t.Wait();

            return Json(t.Result);
        }

        // GET: Negocio/Edit/5
        public ActionResult Edit(long id)
        {
            return View();
        }

        // POST: Negocio/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [ValidationActionFilter]
        public ActionResult Modificar(RequestNegocioModificarDtoApi prm)//int id, IFormCollection collection)
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

            var t = Task.Run(() => _lnNegocio.Modificar(prm));
            t.Wait();

            return Json(t.Result);
        }

        // POST: Negocio/Delete/5
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

            var t = Task.Run(() => _lnNegocio.Eliminar(id));
            t.Wait();

            return Json(t.Result);
        }

        [HttpGet]
        public ActionResult ObtenerCombo(long idUsuario)
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

            var t = Task.Run(() => _lnNegocio.ObtenerCombo(idUsuario));
            t.Wait();

            return Json(t.Result);
        }

        [Route("/Negocio/{id}/Ubicaciones")]
        public ActionResult Ubicaciones(long id)
        {
            //Problema: Verificar que el producto le pertenezca al IdUsuario que ha iniciado sesion
            //Solucion: seria bueno que se envie un parametro mas con el IdUsuario, esto evitaria que un usuario ingrese a un producto que no es de él
            //Método: cuando traes el Producto, que tambien lo traiga con el IdUsuario
            //ProductoAtributoDto entidad = new ProductoAtributoDto();
            //entidad.IdProducto = id;
            return View();// entidad);
        }
    }
}