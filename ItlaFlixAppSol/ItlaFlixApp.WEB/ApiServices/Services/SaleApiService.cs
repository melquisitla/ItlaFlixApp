using ItlaFlixApp.WEB.ApiServices.Interfaces;
using ItlaFlixApp.WEB.Models.Requests;
using ItlaFlixApp.WEB.Models.Responses;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ItlaFlixApp.WEB.ApiServices.Services
{
    public class SaleApiService : ISaleApiService
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<SaleApiService> logger;
        private readonly IHttpClientFactory httpClientFactory;
        private readonly string urlBase;

        public SaleApiService(IConfiguration configuration, ILogger<SaleApiService> logger, IHttpClientFactory httpClientFactory) 
        {
            this.configuration = configuration;
            this.logger = logger;
            this.httpClientFactory = httpClientFactory;
            this.urlBase = this.configuration["apiConfig:baseUrl"];
        }

        public async Task<SaleDetailResponse> GetSale(int id)
        {
            SaleDetailResponse response = new SaleDetailResponse();
            try
            {
                using (var HttpCliente = this.httpClientFactory.CreateClient())
                {
                    using (var resp = await HttpCliente.GetAsync($"{this.urlBase}/Sale/{id}"))
                    {
                        if (resp.IsSuccessStatusCode)
                        {
                            string jsonResp = await resp.Content.ReadAsStringAsync();
                            response = JsonConvert.DeserializeObject<SaleDetailResponse>(jsonResp);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = this.configuration["error:errorGetSale"];
                this.logger.LogError($" {response.message} : {ex.Message}", ex.ToString());
            }


            return response;
        }

        public async Task<SaleListResponse> GetSales()
        {
            SaleListResponse response = new SaleListResponse();

            try
            {
                using (var HttpCliente = this.httpClientFactory.CreateClient())
                {
                    using (var resp = await HttpCliente.GetAsync($"{this.urlBase}/Sale"))
                    {
                        if (resp.IsSuccessStatusCode)
                        {
                            string jsonResp = await resp.Content.ReadAsStringAsync();
                            response = JsonConvert.DeserializeObject<SaleListResponse>(jsonResp);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = this.configuration["error:errorGetSales"];
                this.logger.LogError($" {response.message} : {ex.Message}", ex.ToString());
            }

            return response;

        }

        public async Task<CommadResponse> Save(SaleCreateRequest saleCreate)
        {
            CommadResponse response = new CommadResponse();

            try
            {
                using (var HttpCliente = this.httpClientFactory.CreateClient())
                {
                    saleCreate.fecha = DateTime.Now;

                    StringContent request = new StringContent(JsonConvert.SerializeObject(saleCreate), Encoding.UTF8, "application/json");

                    using (var resp = await HttpCliente.PostAsync($"{this.urlBase}/Sale/SaveSale", request))
                    {

                        if (resp.IsSuccessStatusCode)
                        {
                            string jsonResp = await resp.Content.ReadAsStringAsync();
                            response = JsonConvert.DeserializeObject<CommadResponse>(jsonResp);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = this.configuration["error:errorSaveSales"];
                this.logger.LogError($" {response.message} : {ex.Message}", ex.ToString());
            }

            return response;
        }

        public Task<CommadResponse> Update(SaleUpdateRequest saleUpdate)
        {
            throw new System.NotImplementedException();
        }
    }
}
