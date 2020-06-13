using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Repositorio.Transaccion;

namespace AppWeb.Controllers
{
    public class PasarelaProductoController : Controller
    {
        private readonly LnPasarelaProducto _lnPasarelaProducto = new LnPasarelaProducto();
        // GET: PasarelaProducto
        public ActionResult Index()
        {
            var listaProducto = _lnPasarelaProducto.ObtenerProductos();
            return View(listaProducto);
        }

        // GET: PasarelaProducto/Details/5
        public ActionResult Details(long id)
        {
            var producto = _lnPasarelaProducto.ObtenerPorId(1);
            //return View(producto);
            return Ok(producto);
        }

        // GET: PasarelaProducto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PasarelaProducto/Create
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

        // GET: PasarelaProducto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PasarelaProducto/Edit/5
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

        // GET: PasarelaProducto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PasarelaProducto/Delete/5
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