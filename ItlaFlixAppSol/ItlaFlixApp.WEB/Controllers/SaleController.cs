﻿using GSF.Console;
using ItlaFlixApp.WEB.Models.Requests;
using ItlaFlixApp.WEB.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ItlaFlixApp.WEB.Controllers
{
    public class SaleController : Controller
    {
        HttpClientHandler handler = new  HttpClientHandler();
        private readonly ILogger<SaleController> logger;
        private readonly IConfiguration configuration;
        private readonly string urlBase;

        public SaleController(ILogger<SaleController> logger, IConfiguration configuration) 
        {
            this.logger = logger;
            this.configuration = configuration;
            this.urlBase = this.configuration["apiConfig:baseUrl"];
        }

        public async Task<ActionResult> Index()
        {
            SaleListResponse saleList = new SaleListResponse();

            try
            {
                using (var httpClient = new HttpClient(this.handler)) 
                {
                    var response = await httpClient.GetAsync($"{ this.urlBase }/Sale");
                    if (response.IsSuccessStatusCode)  
                    {
                        string apiResult = await response.Content.ReadAsStringAsync();

                        saleList = JsonConvert.DeserializeObject<SaleListResponse>(apiResult);
                    }
                    else
                    {
                        // Crear logica 
                    }
                }

                return View(saleList.data);
            }
            catch (Exception ex)
            {

                this.logger.LogError("Error obteniendo las ventas", ex.ToString());
            }
            return View();
        }

        public async Task<ActionResult> Details(int id)
        {
            SaleDetailResponse detailResponse = new SaleDetailResponse();

            try
            {
                using (var httpClient = new HttpClient(this.handler))
                {
                    var response = await httpClient.GetAsync($"{this.urlBase}/Sale/{id}");

                    if (response.IsSuccessStatusCode) 
                    {
                        string apiResult = await response.Content.ReadAsStringAsync();

                        detailResponse = JsonConvert.DeserializeObject<SaleDetailResponse>(apiResult);
                    }
                    else
                    {
                        // Logic apor hacer
                    }
                }
                return View(detailResponse.data);
            }
            catch (Exception ex)
            {

                this.logger.LogError("Error obteniendo el detalle de la venta", ex.ToString());
            }
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: SaleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SaleCreateRequest createRequest)
        {
            CommadResponse commadResponse = new CommadResponse();
            try
            {
                using (var httpClient = new HttpClient(this.handler))
                {
                    createRequest.fecha = DateTime.Now;

                    StringContent request = new StringContent(JsonConvert.SerializeObject(createRequest), Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync($"{this.urlBase}/Sale/SaveSale", request);

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
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            SaleDetailResponse detailResponse = new SaleDetailResponse();

            try
            {
                using (var httpClient = new HttpClient(this.handler))
                {
                    var response = await httpClient.GetAsync($"{this.urlBase}/Sale/{id}");

                    if(response.IsSuccessStatusCode)
                    {
                        string apiResult = await response.Content.ReadAsStringAsync();

                        detailResponse = JsonConvert.DeserializeObject<SaleDetailResponse>(apiResult);
                    }
                    else
                    {
                        // Logica por hacer
                    }
                }

                return View(detailResponse.data);
            }
            catch (Exception ex)
            {

                this.logger.LogError("Error editando la venta", ex.ToString());
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(SaleUpdateRequest saleUpdate)
        {
            CommadResponse commadResponse = new CommadResponse();
            try
            {
                using  (var httpClient = new HttpClient(this.handler))
                {
                    StringContent request = new StringContent(JsonConvert.SerializeObject(saleUpdate), Encoding.UTF8, "application/json");

                    var response = await httpClient.PutAsync($"{this.urlBase}/Sale/UpdateSale", request);
                   
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
            catch
            {
                return View();
            }
        }

        // GET: SaleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SaleController/Delete/5
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