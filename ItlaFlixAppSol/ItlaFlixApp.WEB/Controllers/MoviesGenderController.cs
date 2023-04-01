using ItlaFlixApp.WEB.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Text;
using ItlaFlixApp.WEB.Models.Request;

namespace ItlaFlixApp.WEB.Controllers
{
    public class MoviesGenderController : Controller
    {
        HttpClientHandler handler = new HttpClientHandler();
        private readonly ILogger<MoviesGenderController> Logger;
        private readonly IConfiguration configuration;
        private readonly string urlBase;

        public MoviesGenderController(ILogger<MoviesGenderController> logger, IConfiguration configuration ) 
        { 
            this.Logger= logger;
            this.configuration= configuration;
            this.urlBase = this.configuration["apiConfig:baseURL"];
        }
        
        public async Task<ActionResult> Index()
        {
            MovieGenderResponse movieGenderResponse = new MovieGenderResponse();

            try
            {
                using( var http = new HttpClient(this.handler) )
                {
                    var response = await http.GetAsync(urlBase + "/Movies_Gender");
                    if(response.IsSuccessStatusCode)
                    {
                        string apiResult = await response.Content.ReadAsStringAsync();

                        movieGenderResponse = JsonConvert.DeserializeObject<MovieGenderResponse>(apiResult);
                    }
                    else
                    {
                        // Logica en caso de error con http Request
                    }
                }

                return View(movieGenderResponse.data);

            }
            catch (Exception ex)
            {
                this.Logger.LogError("Error obteniendo los generos y las peliculas.", ex.ToString());
            }

            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MoviesGenderCreateRequest CreateReq)
        {
            CommadResponse commandResponse = new CommadResponse();
            try
            {
                using (var http = new HttpClient(this.handler))
                {
                    StringContent request = new StringContent(JsonConvert.SerializeObject(CreateReq), Encoding.UTF8, "application/json");

                    var response = await http.PutAsync($"{this.urlBase}/Movies_Gender/SaveMoviesGender", request);
                    string apiResult = await response.Content.ReadAsStringAsync();
                    commandResponse = JsonConvert.DeserializeObject<CommadResponse>(apiResult);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));

                    }
                    else
                    {
                        ViewBag.Message = commandResponse.Message;
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
            MovieGenderResponse responseData = new MovieGenderResponse();

            try
            {
                using (var http = new HttpClient(this.handler))
                {
                    var response = await http.GetAsync($"{this.urlBase}//{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        string apiResult = await response.Content.ReadAsStringAsync();

                        responseData = JsonConvert.DeserializeObject<MovieGenderResponse>(apiResult);
                    }
                    else
                    {
                        // ponemos x logica
                    }
                }
                return View(responseData.data);
            }
            catch (Exception ex)
            {

                this.Logger.LogError("error editando el genero y la pelicula", ex.ToString());
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(MoviesGenderUpdateRequest movieGenderReq)
        {
            CommadResponse commandResponse = new CommadResponse();
            try
            {
                using (var http = new HttpClient(this.handler))
                {
                    StringContent request = new StringContent(JsonConvert.SerializeObject(movieGenderReq), Encoding.UTF8, "application/json");

                    var response = await http.PutAsync($"{this.urlBase}/Movies_Gender/UpdateMoviesGender", request);
                    string apiResult = await response.Content.ReadAsStringAsync();
                    commandResponse = JsonConvert.DeserializeObject<CommadResponse>(apiResult);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));

                    }
                    else
                    {
                        ViewBag.Message = commandResponse.Message;
                        return View();
                    }

                }


            }
            catch
            {
                return View();
            }
        }
    }
}
