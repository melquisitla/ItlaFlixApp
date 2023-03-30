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

namespace ItlaFlixApp.WEB.Controllers
{
    public class MovieController : Controller
    {
        HttpClientHandler handler = new HttpClientHandler();
        private readonly IConfiguration configuration;
        private readonly string urlBase;

        public ILogger<MovieController> Logger { get; }

        public MovieController(ILogger<MovieController> logger, IConfiguration configuration)
        {
            Logger = logger;
            this.configuration = configuration;
            this.urlBase = this.configuration["apiConfig:baseURL"];
        }

        public async Task <ActionResult> Index()
        {
           MovieListResponse movieList = new MovieListResponse();

            try
            {
                using (var httpClient = new HttpClient(this.handler)) 
                {
                    var response = await httpClient.GetAsync($"{ this.urlBase }/Movie");

                    if (response.IsSuccessStatusCode)
                    {
                        string apiResult = await response.Content.ReadAsStringAsync();

                        movieList = JsonConvert.DeserializeObject<MovieListResponse>(apiResult);
                    }
                    else
                    {
                           // ponemos x logica
                    }
                }
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
                        // ponemos x logica
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
                using (var httpClient = new HttpClient(this.handler))
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(createRequest), Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync($"{this.urlBase}/Movie/SaveMovie", content);

                    string apiResponse = await response.Content.ReadAsStringAsync();

                    commadResponse = JsonConvert.DeserializeObject<CommadResponse>(apiResponse);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewBag.Message = commadResponse.message;
                        return View();
                    }

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
                        // ponemos x logica
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
                
                using (var httpClient = new HttpClient(this.handler)) 
                {
                    StringContent request = new StringContent(JsonConvert.SerializeObject(movieUpdate), Encoding.UTF8, "application/json");

                    var response = await httpClient.PutAsync($"{this.urlBase}/Movie/UpdateMovie", request);
                    string apiResult = await response.Content.ReadAsStringAsync();
                    commadResponse = JsonConvert.DeserializeObject<CommadResponse>(apiResult); 
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else 
                    {
                        ViewBag.Message = commadResponse.message;
                        return View();
                    }
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
