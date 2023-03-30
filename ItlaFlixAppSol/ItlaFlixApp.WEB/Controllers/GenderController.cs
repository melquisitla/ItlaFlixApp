using GSF.Console;
using ItlaFlixApp.WEB.Models;
using ItlaFlixApp.WEB.Models.Requests;
using ItlaFlixApp.WEB.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ItlaFlixApp.WEB.Controllers
{
    public class GenderController : Controller
    {
        HttpClientHandler handler = new HttpClientHandler();
        private readonly IConfiguration configuration;
        private readonly string urlBase;

        public ILogger<GenderController> Logger { get; }

        public GenderController(ILogger<GenderController> logger, IConfiguration configuration)
        {
            Logger = logger;
            this.configuration = configuration;
            this.urlBase = this.configuration["apiConfig:baseURL"];
        }
        public async Task<ActionResult> Index()

        {
            GenderListResponse genderList = new GenderListResponse();

            try
            {
                using (var httpClient = new HttpClient(this.handler))
                {
                    var response = await httpClient.GetAsync($"{ this.urlBase }/Gender");

                    if (response.IsSuccessStatusCode)
                    {
                        string apiResult = await response.Content.ReadAsStringAsync();

                        genderList = JsonConvert.DeserializeObject<GenderListResponse>(apiResult);
                    }
                    else
                    {
                        // ponemos x logica
                    }
                }
                return View(genderList.data);
            }
            catch (Exception ex)
            {

                this.Logger.LogError("Error obteniendo las genero ", ex.ToString());
            }
            return View();
        }

        // GET: GenderController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            GenderDetailResponse detailResponse = new GenderDetailResponse();

            try
            {
                using (var httpClient = new HttpClient(this.handler)) 
                {
                    var response = await httpClient.GetAsync($"{this.urlBase}/Gender/{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        string apiResult = await response.Content.ReadAsStringAsync();

                        detailResponse = JsonConvert.DeserializeObject<GenderDetailResponse>(apiResult);
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

                this.Logger.LogError("No se pudo mostrar el detalle de la genero", ex.ToString());
            }
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
        public async Task<ActionResult> Create(GenderCreateRequest createRequest)
        {
            CommadResponse commadResponse = new CommadResponse();
            try
            {
                using (var httpClient = new HttpClient(this.handler))
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(createRequest), Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync($"{this.urlBase}/Gender/SaveGender", content);

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

        // GET: GenderController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            GenderDetailResponse detailResponse = new GenderDetailResponse();

            try
            {
                using (var httpClient = new HttpClient(this.handler))
                {
                    var response = await httpClient.GetAsync($"{this.urlBase}//{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        string apiResult = await response.Content.ReadAsStringAsync();

                        detailResponse = JsonConvert.DeserializeObject<GenderDetailResponse>(apiResult);
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

                this.Logger.LogError("error editando el genero", ex.ToString());
            }

            return View();
        }

        // POST: GenderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(GenderUpdateRequest genderUpdate)
        {
            CommadResponse commandResponse = new CommadResponse();
            try
            {
                using (var httpClient = new HttpClient(this.handler))
                {
                    StringContent request = new StringContent(JsonConvert.SerializeObject(genderUpdate), Encoding.UTF8, "application/json");

                    var response = await httpClient.PutAsync($"{this.urlBase}/Gender/UpdateGender", request);
                    string apiResult = await response.Content.ReadAsStringAsync();
                    commandResponse = JsonConvert.DeserializeObject<CommadResponse>(apiResult);
                    if (response.IsSuccessStatusCode) 
                    {
                        return RedirectToAction(nameof(Index));

                    }
                    else 
                    {
                        ViewBag.Message = commandResponse.message;
                        return View();
                    }
                        
                }
              
                
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
