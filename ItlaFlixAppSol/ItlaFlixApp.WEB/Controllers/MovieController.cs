using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ItlaFlixApp.WEB.Models;

namespace ItlaFlixApp.WEB.Controllers
{
    public class MovieController : Controller
    {
        // GET: MovieController
        public ActionResult Index()
        {
            List<MovieModel> movies = new List<MovieModel>()
            {
                new MovieModel(){

                     id =  1, Pelicula = "Rapido Furioso 9",Gender = "Accion",cant_disponible_sale= 20,
                     cant_disponible_rent = 20,precio_sale = 250,precio_rent= 50
                },
                new MovieModel(){
                    id =  2, Pelicula = "Wakanda Forever",Gender = "Accion",cant_disponible_sale= 20,
                     cant_disponible_rent = 20,precio_sale = 300,precio_rent= 50
                },

                new MovieModel(){
                    id = 3, Pelicula = "Matrix Resurreccion", Gender = "Accion", cant_disponible_sale = 20,
                     cant_disponible_rent = 20, precio_sale = 150, precio_rent = 50
                }
            };
            return View(movies);
        }

        // GET: MovieController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MovieController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovieController/Create
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

        // GET: MovieController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MovieController/Edit/5
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

        // GET: MovieController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MovieController/Delete/5
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
