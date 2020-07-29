using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidad.Configuracion.Proceso;
using Entidad.Vo;
using Microsoft.AspNetCore.Mvc;
using Negocio.Repositorio.Seguridad;

namespace AppWeb.Controllers
{
    public class AccesoController : Controller
    {
        private readonly LnAcceso _lnAcceso = new LnAcceso();
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ObtenerPorIdUsuario(long id)
        {
            var t = Task.Run(() => _lnAcceso.ObtenerPorIdUsuario(id));
            t.Wait();

            return Json(t.Result);
        }
    }
}