using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ItlaFlixApp.WEB.Models;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using ItlaFlixApp.WEB.Models.Response;
using System.Text.Json.Serialization;
using ItlaFlixApp.WEB.Models.Request;

namespace ItlaFlixApp.WEB.Controllers
{
    public class RentController : Controller
    {
        HttpClientHandler handler = new HttpClientHandler();
        private readonly IConfiguration configuration;
        private readonly string urlBase;

        public ILogger<RentController> Logger { get; }

        public RentController(ILogger<RentController> logger, IConfiguration configuration)
        {
            Logger = logger;
            this.configuration = configuration;
            this.urlBase = this.configuration["apiConfig:baseURL"];
        }

        public async Task<ActionResult> Index()
        {
           RentListResponse rentList = new RentListResponse();
           //CommadResponse commadResponse = new CommadResponse();
            try
            {
                using (var httpClient = new HttpClient(this.handler))
                {
                    var response = await httpClient.GetAsync($"{this.urlBase}/Rent");

                    if (response.IsSuccessStatusCode)
                    {
                        string apiResult = await response.Content.ReadAsStringAsync();

                        rentList = JsonConvert.DeserializeObject<RentListResponse>(apiResult);
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
            RentDetailResponse detailResponse = new RentDetailResponse();

            try
            {
                using (var httpClient = new HttpClient(this.handler))
                {
                    var response = await httpClient.GetAsync($"{this.urlBase}/Rent/{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        string apiResult = await response.Content.ReadAsStringAsync();

                        detailResponse = JsonConvert.DeserializeObject<RentDetailResponse>(apiResult);
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

                this.Logger.LogError("No se pudo rentar esta pelicula", ex.ToString());
            }

            return View();
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RentCreateRequest createRequest)
        {
            CommadResponse commadResponse = new CommadResponse();
            try
            {
                using (var httpClient = new HttpClient(this.handler))
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(createRequest), Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync($"{this.urlBase}/Rent/SaveRent", content);

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
            RentDetailResponse detailResponse = new RentDetailResponse();

            try
            {
                using (var httpClient = new HttpClient(this.handler))
                {
                    var response = await httpClient.GetAsync($"{this.urlBase}/Rent/{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        string apiResult = await response.Content.ReadAsStringAsync();

                        detailResponse = JsonConvert.DeserializeObject<RentDetailResponse>(apiResult);
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

                this.Logger.LogError("Error apartando la pelicula", ex.ToString());
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(RentUpdateRequest rentUpdate)
        {
            CommadResponse commadResponse = new CommadResponse();
            try
            {

                using (var httpClient = new HttpClient(this.handler))
                {
                    StringContent request = new StringContent(JsonConvert.SerializeObject(rentUpdate), Encoding.UTF8, "application/json");

                    var response = await httpClient.PutAsync($"{this.urlBase}/Rent/UpdateRent", request);
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
                this.Logger.LogError("Error comprando la pelicula", ex.ToString());
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