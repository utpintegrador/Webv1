using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AppWeb.Models;
using Entidad.Dto.Dashboard;
using Negocio.Repositorio.Dashboard;

namespace AppWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly LnDashboard _lnDashBoard = new LnDashboard();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public List<DashboardResumenDto> ObtenerCabecera(long idUsuario)
        {
            
            return _lnDashBoard.ObtenerCabecera(idUsuario);
        }

        [HttpGet]
        public List<DashboardTotalVentasDto> ObtenerTotalVentas(long idUsuario)
        {
            return _lnDashBoard.ObtenerTotalVentas(idUsuario);
        }

        [HttpGet]
        public DashboardProductoRootDto ObtenerProductosTop(long idUsuario, int cantidad)
        {
            return _lnDashBoard.ObtenerProductosTop(idUsuario, cantidad);
        }

        [HttpGet]
        public DashboardCategoriaRootDto ObtenerCategoriasTop(long idUsuario, int cantidad)
        {
            return _lnDashBoard.ObtenerCategoriasTop(idUsuario, cantidad);
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Registrar()
        {
            return View();
        }
    }
}
