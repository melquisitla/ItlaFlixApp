using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ItlaFlixApp.WEB.ApiServices.Interfaces;
using ItlaFlixApp.WEB.Models.Response;
using ItlaFlixApp.WEB.Models.Request;

namespace ItlaFlixApp.WEB.Controllers
{
    public class RentController : Controller
    {
        HttpClientHandler handler = new HttpClientHandler();
        private readonly IConfiguration configuration;
        private readonly IRentApiServices rentApiServices;
        private readonly string urlBase;

        public ILogger<RentController> Logger { get; }

        public RentController(ILogger<RentController> logger, IConfiguration configuration, IRentApiServices rentApiServices)
        {
            Logger = logger;
            this.configuration = configuration;
            this.rentApiServices = rentApiServices;
            this.urlBase = this.configuration["apiConfig:baseURL"];
        }

        public async Task<ActionResult> Index()
        {
            RentListResponse rentList = new RentListResponse();

            try
            {
                rentList = await this.rentApiServices.GetRents();
                return View(rentList.data);
            }
            catch (Exception ex)
            {

                this.Logger.LogError("Error rentando las peliculas ", ex.ToString());
            }
            return View();
        }


        public async Task<ActionResult> Details(int id)
        {
            RentDetailResponse detailResponse = new RentDetailResponse();

            try
            {
                detailResponse =await this.rentApiServices.GetRent(id);


                return View(detailResponse.data);
            }
            catch (Exception ex)
            {

                this.Logger.LogError("No se pudo mostrar el detalle de la renta de la  pelicula", ex.ToString());
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
                commadResponse = await this.rentApiServices.Save(createRequest);

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
                        Console.WriteLine("Esta dando error ");
                    }
                }
                return View(detailResponse.data);
            }
            catch (Exception ex)
            {

                this.Logger.LogError("Error rentando la pelicula", ex.ToString());
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
                commadResponse = await this.rentApiServices.Update(rentUpdate);

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
                this.Logger.LogError("Error Alquilando la pelicula", ex.ToString());
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