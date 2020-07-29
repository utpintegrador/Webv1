using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppWeb.CustomHandler;
using Entidad.Configuracion.Proceso;
using ModelosApi.Request.Correo;
using Entidad.Vo;
using Microsoft.AspNetCore.Mvc;
using Negocio.Repositorio.Correo;

namespace AppWeb.Controllers
{
    public class RecuperacionContraseniaController : Controller
    {
        private readonly LnRecuperacionContrasenia _lnRecuperacionContrasenia = new LnRecuperacionContrasenia();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidationActionFilter]
        public ActionResult Registrar(RequestRecuperacionContraseniaRegistrarDtoApi prm)
        {
            var t = Task.Run(() => _lnRecuperacionContrasenia.Registrar(prm));
            t.Wait();

            return Json(t.Result);
        }
    }
}