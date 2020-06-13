using System.Collections.Generic;
using Entidad.Dto.Maestro;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Repositorio.Maestro;

namespace AppWeb.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly LnCategoria _lnCategoria = new LnCategoria();
        // GET: Categoria
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public List<CategoriaObtenerDto> Obtener(CategoriaObtenerFiltroDto filtro)
        {
            var listaCategoria = _lnCategoria.Obtener(filtro);
            return listaCategoria;
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
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

        // GET: Categoria/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Categoria/Edit/5
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

        // GET: Categoria/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Categoria/Delete/5
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
        public List<CategoriaComboDto> ObtenerCombo(string primerValor)
        {
            List<CategoriaComboDto> lista = new List<CategoriaComboDto>();
            lista.Add(new CategoriaComboDto { IdCategoria = 1, Descripcion = "Categoria 1" });
            lista.Add(new CategoriaComboDto { IdCategoria = 2, Descripcion = "Categoria 2" });
            lista.Add(new CategoriaComboDto { IdCategoria = 2, Descripcion = "Categoria 3" });
            lista.Add(new CategoriaComboDto { IdCategoria = 2, Descripcion = "Categoria 4" });
            lista.Add(new CategoriaComboDto { IdCategoria = 2, Descripcion = "Categoria 5" });

            if (!string.IsNullOrEmpty(primerValor))
            {
                lista.Insert(0, new CategoriaComboDto { IdCategoria = 0, Descripcion = primerValor });
            }

            return lista;
        }
    }
}