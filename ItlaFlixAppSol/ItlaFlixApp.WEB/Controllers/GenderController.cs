using ItlaFlixApp.WEB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ItlaFlixApp.WEB.Controllers
{
    public class GenderController : Controller
    {
        // GET: GenderController
        public ActionResult Index()

        {
            List<GenderModel> gender = new List<GenderModel>()
            {
                new GenderModel()
                {
                    Id= 1,Description = "Accion"
                },
                new GenderModel()
                {
                    Id= 2,Description = "Aventura"
                },
                new GenderModel()
                {
                    Id= 3, Description = "Accion"
                }
            };
            return View(gender);
        }

        // GET: GenderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GenderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GenderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GenderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GenderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GenderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GenderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
