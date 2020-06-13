using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidad.Dto.Seguridad;
using Entidad.Entidad.Seguridad;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Repositorio.Seguridad;

namespace AppWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly LnUsuario _lnUsuario = new LnUsuario();
        // GET: Usuario
        public ActionResult Index()
        {
            //UsuarioObtenerFiltroDto filtro = new UsuarioObtenerFiltroDto();
            //var listado = _lnUsuario.Obtener(filtro);


            //var tarea = _lnUsuario.Obtener2(filtro);
            //var resultado = tarea.GetAwaiter();

            return View();// listado);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            var resultado = _lnUsuario.ObtenerPorId(id);
            return View(resultado);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioRegistrarDto modelo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int resultado = _lnUsuario.Registrar(modelo);
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

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            //var entidad = _lnUsuario.ObtenerPorId(id);
            return View();// entidad);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Usuario modelo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    UsuarioModificarDto prm = new UsuarioModificarDto
                    {
                        IdUsuario = modelo.IdUsuario,
                        Contrasenia = modelo.Contrasenia,
                        Nombre = modelo.Nombre,
                        UserName = modelo.UserName,
                        ApellidoPaterno = modelo.ApellidoPaterno,
                        ApellidoMaterno = modelo.ApellidoMaterno,
                        IdEstado = modelo.IdEstado
                    };
                    int resultado = _lnUsuario.Modificar(prm);
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

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            var entidad = _lnUsuario.ObtenerPorId(id);
            return View(entidad);
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Usuario modelo)
        {
            try
            {
                // TODO: Add delete logic here
                if (id > 0)
                {
                    int resultado = _lnUsuario.Eliminar(id);
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