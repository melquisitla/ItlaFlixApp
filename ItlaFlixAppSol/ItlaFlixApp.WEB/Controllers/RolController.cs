using ItlaFlixApp.WEB.Models.Request;
using ItlaFlixApp.WEB.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System;

namespace ItlaFlixApp.WEB.Controllers
{
    public class RolController : Controller
    {
        HttpClientHandler handler = new HttpClientHandler();
        private readonly IConfiguration configuration;
        private readonly string urlBase;

        public ILogger<RolController> Logger { get; }

        public RolController(ILogger<RolController> logger, IConfiguration configuration)
        {
            Logger = logger;
            this.configuration = configuration;
            this.urlBase = this.configuration["apiConfig:baseUrl"];
        }

        public async Task<ActionResult> Index()
        {
            RolListResponse rentList = new RolListResponse();
            //CommadResponse commadResponse = new CommadResponse();
            try
            {
                using (var httpClient = new HttpClient(this.handler))
                {
                    var response = await httpClient.GetAsync($"{this.urlBase}/Rol");

                    if (response.IsSuccessStatusCode)
                    {
                        string apiResult = await response.Content.ReadAsStringAsync();

                        rentList = JsonConvert.DeserializeObject<RolListResponse>(apiResult);
                    }
                    else
                    {
                        // ponemos x logica
                    }
                }
                return View(rentList.data);
            }
            catch (Exception ex)
            {

                this.Logger.LogError("Error alquilando las peliculas ", ex.ToString());
            }
            return View();
        }


        public async Task<ActionResult> Details(int id)
        {
            RolDetailResponse detailResponse = new RolDetailResponse();

            try
            {
                using (var httpClient = new HttpClient(this.handler))
                {
                    var response = await httpClient.GetAsync($"{this.urlBase}/Rol/{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        string apiResult = await response.Content.ReadAsStringAsync();

                        detailResponse = JsonConvert.DeserializeObject<RolDetailResponse>(apiResult);
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

                this.Logger.LogError("No se pudo completar el rol de esta pelicula", ex.ToString());
            }

            return View();
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RolCreateRequest createRequest)
        {
            CommadResponse commadResponse = new CommadResponse();
            try
            {
                using (var httpClient = new HttpClient(this.handler))
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(createRequest), Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync($"{this.urlBase}/Rol/SaveRol", content);

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
            RolDetailResponse detailResponse = new RolDetailResponse();

            try
            {
                using (var httpClient = new HttpClient(this.handler))
                {
                    var response = await httpClient.GetAsync($"{this.urlBase}/Rol/{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        string apiResult = await response.Content.ReadAsStringAsync();

                        detailResponse = JsonConvert.DeserializeObject<RolDetailResponse>(apiResult);
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

                this.Logger.LogError("Error creando el rol de la pelicula", ex.ToString());
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(RolUpdateRequest rolUpdate)
        {
            CommadResponse commadResponse = new CommadResponse();
            try
            {

                using (var httpClient = new HttpClient(this.handler))
                {
                    StringContent request = new StringContent(JsonConvert.SerializeObject(rolUpdate), Encoding.UTF8, "application/json");

                    var response = await httpClient.PutAsync($"{this.urlBase}/Rol/UpdateRol", request);
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
                this.Logger.LogError("Error en la pelicula", ex.ToString());
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