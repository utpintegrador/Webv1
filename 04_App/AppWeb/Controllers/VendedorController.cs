using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppWeb.Controllers
{
    public class VendedorController : Controller
    {
        // GET: Vendedor
        public ActionResult Index()
        {
            return View();
        }

        // GET: Vendedor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Vendedor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vendedor/Create
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

        // GET: Vendedor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Vendedor/Edit/5
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

        // GET: Vendedor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Vendedor/Delete/5
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