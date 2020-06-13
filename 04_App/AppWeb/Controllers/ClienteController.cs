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
    public class ClienteController : Controller
    {
        private readonly LnCliente _lnCliente = new LnCliente();
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("ObtenerData")]
        public ActionResult ObtenerData(ClienteObtenerFiltroDto prm)
        {
            var listado = _lnCliente.Obtener(prm);
            return Json(listado);
        }

        [HttpGet("ObtenerPendientesPorUsuario")]
        public ActionResult ObtenerPendientesPorUsuario()
        {
            ClienteObtenerFiltroDto filtro = new ClienteObtenerFiltroDto();

            var listado = _lnCliente.ObtenerPendientesPorUsuario(filtro);
            return View(listado);
        }

        // GET: Cliente/Details/5
        //[HttpGet("Cliente/{id}")]
        public ActionResult Details(int id)
        {
            var resultado = _lnCliente.ObtenerPorId(id);
            return View(resultado);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteRegistrarDto modelo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int resultado = _lnCliente.Registrar(modelo);
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

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            var entidad = _lnCliente.ObtenerPorId(id);
            return View(entidad);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Cliente modelo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    ClienteModificarDto prm = new ClienteModificarDto
                    {
                        IdCliente = modelo.IdCliente,
                        NumeroDocumento = modelo.NumeroDocumento,
                        RazonSocial = modelo.RazonSocial,
                        Direccion = modelo.Direccion,
                        IdEstado = modelo.IdEstado,
                        IdPais = modelo.IdPais,
                        IdUbigeo = modelo.IdUbigeo,
                        IdUsuario = modelo.IdUsuario
                    };
                    int resultado = _lnCliente.Modificar(prm);
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

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            var entidad = _lnCliente.ObtenerPorId(id);
            return View(entidad);
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Cliente modelo)
        {
            try
            {
                // TODO: Add delete logic here
                if (id > 0)
                {
                    int resultado = _lnCliente.Eliminar(id);
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