using ItlaFlixApp.WEB.ApiServices.Interfaces;
using ItlaFlixApp.WEB.Models.Request;
using ItlaFlixApp.WEB.Models.Response;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ItlaFlixApp.WEB.ApiServices.Services
{
    public class RentApiServices : IRentApiServices
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<RentApiServices> logger;
        private readonly IHttpClientFactory httpClientFactory;

        private readonly string urlBase;
        public RentApiServices(IConfiguration configuration, ILogger<RentApiServices> logger,
                                 IHttpClientFactory httpClientFactory
                                 )
        {
            this.configuration = configuration;
            this.logger = logger;
            this.httpClientFactory = httpClientFactory;

            this.urlBase = this.configuration["apiConfig:baseURL"];
        }
        public async Task<RentDetailResponse> GetRent(int id)
        {
            RentDetailResponse rentResponse = new RentDetailResponse();

            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {

                    using (var response = await httpClient.GetAsync($"{this.urlBase}/Rent/{id}"))
                    {

                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            rentResponse = JsonConvert.DeserializeObject<RentDetailResponse>(apiResponse);
                        }


                    }

                }
            }
            catch (Exception ex)
            {
                rentResponse.message = this.configuration["errorMessage:errorGetRents"];
                rentResponse.success= false;
                this.logger.LogError($" {rentResponse.message} : {ex.Message}", ex.ToString());
            }

            return rentResponse;
        }

        public async Task<RentListResponse> GetRents()
        {
            RentListResponse response = new RentListResponse();
            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    using (var resp = await httpClient.GetAsync($"{this.urlBase}/Rent"))
                    {
                        if (resp.IsSuccessStatusCode)
                        {
                            string jsonResp = await resp.Content.ReadAsStringAsync();
                            response = JsonConvert.DeserializeObject<RentListResponse>(jsonResp);

                        }

                    }
                }

            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = this.configuration["errorMessage:errorGetRents"];
                this.logger.LogError($" {response.message} : {ex.Message}", ex.ToString());
            }
            return response;
        }

        public async Task<CommadResponse> Save(RentCreateRequest rentCreate)
        {
            CommadResponse commadResponse = new CommadResponse();
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(rentCreate), Encoding.UTF8, "application/json");
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    httpClient.BaseAddress = new Uri(this.urlBase);
                    using (var resp = await httpClient.PostAsync($"{this.urlBase}/Rent/SaveRent", content))
                    {

                        if (resp.IsSuccessStatusCode)
                        {
                            string apiResponse = await resp.Content.ReadAsStringAsync();

                            commadResponse = JsonConvert.DeserializeObject<CommadResponse>(apiResponse);
                        }
                        else
                        {
                            commadResponse.success = false;
                            commadResponse.message = this.configuration["errorMessage:errorSaveRents"];
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                commadResponse.success = false;
                commadResponse.message = this.configuration["errorMessage:errorSaveRent"];
                this.logger.LogError($" {commadResponse.message} : {ex.Message}", ex.ToString());

            }
            return commadResponse;
        }

        public async Task<CommadResponse> Update(RentUpdateRequest rentUpdate)
        {
            CommadResponse commadResponse = new CommadResponse();
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(rentUpdate), Encoding.UTF8, "application/json");
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    httpClient.BaseAddress = new Uri(this.urlBase);
                    using (var resp = await httpClient.PutAsync($"{this.urlBase}/Rent/UpdateRent", content))
                    {

                        if (resp.IsSuccessStatusCode)
                        {
                            string apiResponse = await resp.Content.ReadAsStringAsync();

                            commadResponse = JsonConvert.DeserializeObject<CommadResponse>(apiResponse);
                        }
                        else
                        {
                            commadResponse.success = false;
                            commadResponse.message = this.configuration["errorMessage:errorUpdateRent"];
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                commadResponse.success = false;
                commadResponse.message = this.configuration["errorMessage:errorUpdateRent"];
                this.logger.LogError($" {commadResponse.message} : {ex.Message}", ex.ToString());

            }
            return commadResponse;
        }
    }
}