using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidad.Configuracion.Proceso;
using Entidad.Dto.Maestro;
using Entidad.Request.Maestro;
using Entidad.Vo;
using Microsoft.AspNetCore.Mvc;
using ModelosApi.Request.Maestro;
using Negocio.Repositorio.Maestro;

namespace AppWeb.Controllers
{
    public class ProductoController : Controller
    {
        private readonly LnProducto _lnProducto = new LnProducto();
        // GET: Producto
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("ObtenerData")]
        public ActionResult ObtenerData(ProductoObtenerFiltroDto prm)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnProducto.Obtener(prm));
            t.Wait();

            return Json(t.Result);
        }

        // GET: Producto/Details/5
        public ActionResult Details(long id)
        {
            return View();
        }

        // GET: Producto/Details/5
        public ActionResult ObtenerPorId(long id)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnProducto.ObtenerPorId(id));
            t.Wait();

            return Json(t.Result);
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Registrar(RequestProductoRegistrarDtoApi prm)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnProducto.Registrar(prm));
            t.Wait();

            return Json(t.Result);
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(long id)
        {
            return View();
        }

        // POST: Producto/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Modificar(RequestProductoModificarDtoApi prm)//int id, IFormCollection collection)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnProducto.Modificar(prm));
            t.Wait();

            return Json(t.Result);
        }

        // POST: Producto/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Eliminar(long id)//, IFormCollection collection)
        {
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
            }

            var t = Task.Run(() => _lnProducto.Eliminar(id));
            t.Wait();

            return Json(t.Result);
        }

        [HttpPost]
        public ActionResult EliminarSeleccionados(string arrayObjeto)//RequestProductoEliminarMasivoDtoApi prm)
        {
            if(arrayObjeto != null)
            {
                var prm = Newtonsoft.Json.JsonConvert.DeserializeObject<RequestProductoEliminarMasivoDtoApi>(arrayObjeto);
                if(prm != null)
                {
                    if (prm.ListaIdProducto != null)
                    {
                        if (prm.ListaIdProducto.Any())
                        {
                            if (ConstanteVo.ActivarLLamadasConToken)
                            {
                                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();
                            }

                            var t = Task.Run(() => _lnProducto.EliminarMasivo(prm));
                            t.Wait();

                            return Json(t.Result);
                        }
                    }
                }
            }
            return BadRequest();
        }
    }

    public class Producto
    {
        public long IdProducto { get; set; }
    }
}