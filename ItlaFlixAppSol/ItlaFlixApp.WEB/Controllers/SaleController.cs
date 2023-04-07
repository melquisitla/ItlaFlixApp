using GSF.Console;
using ItlaFlixApp.WEB.ApiServices.Interfaces;
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
        private readonly ISaleApiService saleApiService;
        private readonly string urlBase;

        public SaleController(ILogger<SaleController> logger, IConfiguration configuration, ISaleApiService saleApiService) 
        {
            this.logger = logger;
            this.configuration = configuration;
            this.saleApiService = saleApiService;
            this.urlBase = this.configuration["apiConfig:baseUrl"];
        }

        public async Task<ActionResult> Index()
        {
            SaleListResponse saleList = new SaleListResponse();

            try
            {
                saleList = await this.saleApiService.GetSales();

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
                detailResponse = await this.saleApiService.GetSale(id);

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SaleCreateRequest createRequest)
        {
            CommadResponse commadResponse = new CommadResponse();

            try
            {
                commadResponse = await this.saleApiService.Save(createRequest);
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
            SaleDetailResponse detailResponse = new SaleDetailResponse();

            try
            {
                detailResponse = await this.saleApiService.GetSale(id);

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
                commadResponse = await this.saleApiService.Update(saleUpdate);
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
