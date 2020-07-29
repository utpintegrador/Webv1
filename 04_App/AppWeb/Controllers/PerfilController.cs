using Microsoft.AspNetCore.Mvc;

namespace AppWeb.Controllers
{
    public class PerfilController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contrasenia()
        {
            return View();
        }
    }
}