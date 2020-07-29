using System.Collections.Generic;
using System.Linq;
using Entidad.Dto.Transaccion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppWeb.Controllers
{
    public class CarroController : Controller
    {
        private CarroObtenerDto _carro;
        // GET: Carro
        public ActionResult Index()
        {
            return View();
        }

        // GET: Carro/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Carro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carro/Create
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

        // GET: Carro/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Carro/Edit/5
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

        // GET: Carro/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Carro/Delete/5
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

        public int Agregar(CarroAgregarDto carroAgregar)
        {
            try
            {
                IniciarObjetoCarro();

                if(carroAgregar != null)
                {
                    //ir a la bd a traer la info
                    //llamada bd
                    _carro.ListaCarroItem.Add(new CarroItemObtenerDto
                    {
                        IdProducto = carroAgregar.IdProducto
                    });
                }
            }
            catch
            {

            }
            return _carro.ListaCarroItem.Count();
        }

        private void IniciarObjetoCarro()
        {
            try
            {
                if (_carro == null)
                {
                    _carro = new CarroObtenerDto();
                }
                if(_carro.ListaCarroItem == null)
                {
                    _carro.ListaCarroItem = new List<CarroItemObtenerDto>();
                }
            }
            catch
            {

            }
        }

    }
}