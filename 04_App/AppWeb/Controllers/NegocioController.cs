using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidad.Dto.Maestro;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppWeb.Controllers
{
    public class NegocioController : Controller
    {
        // GET: Negocio
        public ActionResult Index()
        {
            return View();
        }

        // GET: Negocio/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Negocio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Negocio/Create
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

        // GET: Negocio/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Negocio/Edit/5
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

        // GET: Negocio/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Negocio/Delete/5
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
        public List<NegocioComboDto> ObtenerCombo(string primerValor)
        {
            List<NegocioComboDto> lista = new List<NegocioComboDto>();
            lista.Add(new NegocioComboDto { IdNegocio = 1, NumeroDocumentoIdentidad = "00000000000", RazonSocial = "RazonSocial 1" });
            lista.Add(new NegocioComboDto { IdNegocio = 2, NumeroDocumentoIdentidad = "11111111111", RazonSocial = "RazonSocial 2" });

            if (!string.IsNullOrEmpty(primerValor))
            {
                lista.Insert(0, new NegocioComboDto { IdNegocio = 0, RazonSocial = primerValor });
            }

            return lista;
        }
    }
}