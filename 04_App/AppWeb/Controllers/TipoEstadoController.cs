using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidad.Dto.Maestro;
using Entidad.Entidad.Maestro;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Repositorio.Maestro;

namespace AppWeb.Controllers
{
    public class TipoEstadoController : Controller
    {
        private readonly LnTipoEstado _lnTipoEstado = new LnTipoEstado();
        // GET: TipoEstado
        public ActionResult Index()
        {
            TipoEstadoObtenerFiltroDto filtro = new TipoEstadoObtenerFiltroDto();
            var listado = _lnTipoEstado.Obtener(filtro);
            return View(listado);
        }

        // GET: TipoEstado/Details/5
        public ActionResult Details(int id)
        {
            var resultado = _lnTipoEstado.ObtenerPorId(id);
            return View(resultado);
        }

        // GET: TipoEstado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoEstado/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoEstadoRegistrarDto modelo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int idNuevo = 0;
                    int resultado = _lnTipoEstado.Registrar(modelo, ref idNuevo);
                    if (resultado > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }

            }
            catch
            {

            }
            return View();
        }

        // GET: TipoEstado/Edit/5
        public ActionResult Edit(int id)
        {
            var entidad = _lnTipoEstado.ObtenerPorId(id);
            return View(entidad);
        }

        // POST: TipoEstado/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TipoEstado modelo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    TipoEstadoModificarDto prm = new TipoEstadoModificarDto
                    {
                        IdTipoEstado = modelo.IdTipoEstado,
                        Nombre = modelo.Nombre,
                        Observacion = modelo.Observacion
                    };
                    int resultado = _lnTipoEstado.Modificar(prm);
                    if (resultado > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                }
            }
            catch
            {

            }
            return View();
        }

        // GET: TipoEstado/Delete/5
        public ActionResult Delete(int id)
        {
            var entidad = _lnTipoEstado.ObtenerPorId(id);
            return View(entidad);
        }

        // POST: TipoEstado/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TipoEstado modelo)
        {
            try
            {
                // TODO: Add delete logic here
                if (id > 0)
                {
                    int resultado = _lnTipoEstado.Eliminar(id);
                    if (resultado > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }


            }
            catch
            {

            }
            return View();
        }
    }
}