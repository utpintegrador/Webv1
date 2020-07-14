using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Repositorio.Gestion;

namespace AppWeb.Controllers
{
    public class IncidenciasController : Controller
    {
        private readonly LnIncidencia _lnIncidencia = new LnIncidencia();
        // GET: Incidencia
        public ActionResult Index()
        {
            //var listaIncidencias = _lnIncidencia.Obtener();
            //return View(listaIncidencias);
            return View();
        }

        // GET: Incidencia/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Incidencia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Incidencia/Create
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

        // GET: Incidencia/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Incidencia/Edit/5
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

        // GET: Incidencia/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Incidencia/Delete/5
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