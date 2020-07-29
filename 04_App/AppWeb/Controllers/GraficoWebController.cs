using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppWeb.CustomHandler;
using Entidad.Configuracion.Proceso;
using Entidad.Vo;
using Microsoft.AspNetCore.Mvc;
using ModelosApi.Request.Grafico;
using Negocio.Repositorio.Grafico;

namespace AppWeb.Controllers
{
    public class GraficoWebController : Controller
    {
        private readonly LnGraficoWeb _lnGraficoWeb = new LnGraficoWeb();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidationActionFilter]
        public ActionResult ObtenerResumenWeb(RequestGraficoObtenerResumenDtoApi prm)
        {
            if (!ModelState.IsValid) return Json(BadRequest());
            if (ConstanteVo.ActivarLLamadasConToken)
            {
                IEnumerable<string> headerUsr = Request.Headers[ConstanteVo.NombreParametroToken];
                ConfiguracionToken.ConfigToken = headerUsr.FirstOrDefault();

                if (string.IsNullOrEmpty(ConfiguracionToken.ConfigToken))
                {
                    return RedirectToAction("Login", "Home");
                }
            }

            var t = Task.Run(() => _lnGraficoWeb.ObtenerResumenWeb(prm));
            t.Wait();

            return Json(t.Result);
        }

        //public List<DashboardResumenDto> ObtenerCabecera(long idUsuario)
        //{
        //    List<DashboardResumenDto> lista = new List<DashboardResumenDto>();
        //    lista.Add(new DashboardResumenDto
        //    {
        //        Orden = 1,
        //        ColorFondo = "bg-primary",
        //        Icono = "fa fa-television",
        //        Titulo = "Cantidad productos ofrecidos",
        //        Valor = 658
        //    });
        //    lista.Add(new DashboardResumenDto
        //    {
        //        Orden = 2,
        //        ColorFondo = "bg-success",
        //        Icono = "fa fa-shopping-cart",
        //        Titulo = "Cantidad de ventas realizadas",
        //        Valor = 23
        //    });
        //    lista.Add(new DashboardResumenDto
        //    {
        //        Orden = 3,
        //        ColorFondo = "bg-info",
        //        Icono = "fa fa-star-o",
        //        Titulo = "Valoracion obtenida como comprador",
        //        Valor = 4.2M
        //    });
        //    lista.Add(new DashboardResumenDto
        //    {
        //        Orden = 4,
        //        ColorFondo = "bg-danger",
        //        Icono = "fa fa-star-o",
        //        Titulo = "Valoracion obtenida como vendedor",
        //        Valor = 1.3M
        //    });
        //    return lista;
        //}
    }
}