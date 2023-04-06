using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ItlaFlixApp.WEB.Models;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using ItlaFlixApp.WEB.Models.Responses;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ItlaFlixApp.WEB.Models.Requests;
using System.Text;
using GSF.Console;
using ItlaFlixApp.WEB.ApiServices.Interfaces;

namespace ItlaFlixApp.WEB.Controllers
{
    public class MovieController : Controller
    {
        HttpClientHandler handler = new HttpClientHandler();
        private readonly IConfiguration configuration;
        private readonly IMovieApiServices movieApiServices;
        private readonly string urlBase;

        public ILogger<MovieController> Logger { get; }

        public MovieController(ILogger<MovieController> logger, IConfiguration configuration, IMovieApiServices movieApiServices)
        {
            Logger = logger;
            this.configuration = configuration;
            this.movieApiServices = movieApiServices;
            this.urlBase = this.configuration["apiConfig:baseURL"];
        }

        public async Task <ActionResult> Index()
        {
           MovieListResponse movieList = new MovieListResponse();

            try
            {
                

                movieList = await this.movieApiServices.GetMovies();
                return View(movieList.data);
            }
            catch (Exception ex)
            {

                this.Logger.LogError("Error obteniendo las peliculas ", ex.ToString());
            }
            return View();
        }

     
        public async Task<ActionResult> Details(int id)
        {
            MovieDetailResponse detailResponse = new MovieDetailResponse();

            try
            {

                using (var httpClient = new HttpClient(this.handler))
                {
                    var response = await httpClient.GetAsync($"{this.urlBase}/Movie/{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        string apiResult = await response.Content.ReadAsStringAsync();

                        detailResponse = JsonConvert.DeserializeObject<MovieDetailResponse>(apiResult);
                    }
                    else
                    {
                        Console.WriteLine("Esta Dando error de lo mio");
                    }
                }
                return View(detailResponse.data);
            }
            catch (Exception ex)
            {

                this.Logger.LogError("No se pudo mostrar el detalle de la pelicula", ex.ToString());
            }

            return View();
        }

        
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MovieCreateRequest createRequest)
        {      
            CommadResponse commadResponse = new CommadResponse();
            try
            {
                commadResponse = await this.movieApiServices.Save(createRequest);

                if (commadResponse.success)
                {
                    return RedirectToAction(nameof(Index));
                }
                else 
                {
                    ViewBag.Message = commadResponse.message;
                    return View();
                }
                
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            MovieDetailResponse detailResponse = new MovieDetailResponse();

            try
            {
                using (var httpClient = new HttpClient(this.handler))
                {
                    var response = await httpClient.GetAsync($"{this.urlBase}/Movie/{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        string apiResult = await response.Content.ReadAsStringAsync();

                        detailResponse = JsonConvert.DeserializeObject<MovieDetailResponse>(apiResult);
                    }
                    else
                    {
                        Console.WriteLine("Esta Dando error de lo mio");
                    }
                }
                return View(detailResponse.data);
            }
            catch (Exception ex)
            {

                this.Logger.LogError("Error editando la pelicula", ex.ToString());
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(MovieUpdateRequest movieUpdate)
        {
            CommadResponse commadResponse = new CommadResponse();
            try
            {
                commadResponse = await this.movieApiServices.Update(movieUpdate);

                if (commadResponse.success)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Message = commadResponse.message;
                    return View();
                }

                


            }
            catch (Exception ex)
            {
                this.Logger.LogError("Error actualizando la movie", ex.ToString());
                return View();
            }
        }

       
        public ActionResult Delete(int id)
        {
            return View();
        }

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
