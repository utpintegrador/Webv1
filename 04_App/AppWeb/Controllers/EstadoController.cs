using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidad.Dto.Maestro;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppWeb.Controllers
{
    public class EstadoController : Controller
    {
        // GET: Estado
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [ActionName("ObtenerPorIdTipoEstado")]
        public ActionResult ObtenerPorIdTipoEstado(int idTipoEstado)
        {
            List<EstadoObtenerDto> listaEstado = new List<EstadoObtenerDto>();
            listaEstado.Add(new EstadoObtenerDto { IdEstado = 0, Descripcion = "Todos" });
            listaEstado.Add(new EstadoObtenerDto { IdEstado = 1, Descripcion = "Activo" });
            listaEstado.Add(new EstadoObtenerDto { IdEstado = 2, Descripcion = "Inactivo" });

            return Ok(listaEstado);
        }

        // GET: Estado/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Estado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estado/Create
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

        // GET: Estado/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Estado/Edit/5
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

        // GET: Estado/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Estado/Delete/5
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
        public List<EstadoComboDto> ObtenerCombo(string primerValor)
        {
            List<EstadoComboDto> lista = new List<EstadoComboDto>();
            lista.Add(new EstadoComboDto { IdEstado = 1, Descripcion = "Activo" });
            lista.Add(new EstadoComboDto { IdEstado = 2, Descripcion = "Inactivo" });

            if (!string.IsNullOrEmpty(primerValor))
            {
                lista.Insert(0, new EstadoComboDto { IdEstado = 0, Descripcion = primerValor });
            }

            return lista;
        }
    }
}