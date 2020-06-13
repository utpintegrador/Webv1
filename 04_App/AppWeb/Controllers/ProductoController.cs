using System.Collections.Generic;
using Entidad.Dto.Maestro;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Repositorio.Maestro;

namespace AppWeb.Controllers
{
    public class ProductoController : Controller
    {
        private readonly LnProducto _lnProducto = new LnProducto();
        // GET: Producto
        public ActionResult Index(ProductoObtenerFiltroDto filtro)
        {
            //var listaProducto = _lnProducto.ObtenerListadoPorIdUsuario(filtro);
            return View();// listaProducto);
        }

        [HttpGet]
        public List<ProductoObtenerDto> ObtenerListado(ProductoObtenerFiltroDto filtro)
        {
            var listaProducto = _lnProducto.ObtenerListadoPorIdUsuario(filtro);
            return listaProducto;
        }

        // GET: Producto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Producto/Details/5
        public ActionResult ObtenerPorVendedor(int id)
        {
            return View();
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Producto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Producto/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}