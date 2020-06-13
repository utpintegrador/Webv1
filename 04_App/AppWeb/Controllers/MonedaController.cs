using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidad.Dto.Maestro;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppWeb.Controllers
{
    public class MonedaController : Controller
    {
        // GET: Moneda
        public ActionResult Index()
        {
            return View();
        }

        // GET: Moneda/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Moneda/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Moneda/Create
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

        // GET: Moneda/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Moneda/Edit/5
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

        // GET: Moneda/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Moneda/Delete/5
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

        [HttpGet]
        public List<MonedaComboDto> ObtenerCombo(string primerValor)
        {
            List<MonedaComboDto> lista = new List<MonedaComboDto>();
            lista.Add(new MonedaComboDto { IdMoneda = 1, Descripcion = "Sol" });
            lista.Add(new MonedaComboDto { IdMoneda = 2, Descripcion = "Dólar" });

            if (!string.IsNullOrEmpty(primerValor))
            {
                lista.Insert(0, new MonedaComboDto { IdMoneda = 0, Descripcion = primerValor });
            }

            return lista;
        }

    }
}