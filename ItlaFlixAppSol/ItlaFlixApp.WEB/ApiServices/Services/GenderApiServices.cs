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
    public class GenderApiServices : IGenderApiServices
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<GenderApiServices> logger;
        private readonly IHttpClientFactory httpClientFactory;
        private readonly string urlBase;
        public GenderApiServices(IConfiguration configuration, ILogger<GenderApiServices> logger,
                                IHttpClientFactory httpClientFactory
                                )
        {
            this.configuration = configuration;
            this.logger = logger;
            this.httpClientFactory = httpClientFactory;

            this.urlBase = this.configuration["apiConfig:baseURL"];
        }
        public async Task<GenderDetailResponse> GetGender(int id)
        {
            GenderDetailResponse response = new GenderDetailResponse();
            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    using (var resp = await httpClient.GetAsync($"{this.urlBase}/Gender"))
                    {
                        if (resp.IsSuccessStatusCode)
                        {
                            string jsonResp = await resp.Content.ReadAsStringAsync();
                            response = JsonConvert.DeserializeObject<GenderDetailResponse>(jsonResp);

                        }

                    }
                }

            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = this.configuration["errorMessage:errorGetGenders"];
                this.logger.LogError($" {response.message} : {ex.Message}", ex.ToString());
            }
            return response;
        }

        public async Task<GenderListResponse> GetGenders()
        {
            GenderListResponse response = new GenderListResponse();
            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    using (var resp = await httpClient.GetAsync($"{this.urlBase}/Gender"))
                    {
                        if (resp.IsSuccessStatusCode)
                        {
                            string jsonResp = await resp.Content.ReadAsStringAsync();
                            response = JsonConvert.DeserializeObject<GenderListResponse>(jsonResp);

                        }

                    }
                }

            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = this.configuration["errorMessage:errorGetGenders"];
                this.logger.LogError($" {response.message} : {ex.Message}", ex.ToString());
            }
            return response;
        }

        public async Task<CommadResponse> Save(GenderCreateRequest genderCreate)
        {
            CommadResponse commadResponse = new CommadResponse();
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(genderCreate), Encoding.UTF8, "application/json");
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    httpClient.BaseAddress = new Uri(this.urlBase);
                    using (var resp = await httpClient.PostAsync($"{this.urlBase}/Gender/SaveGender", content))
                    {

                        if (resp.IsSuccessStatusCode)
                        {
                            string apiResponse = await resp.Content.ReadAsStringAsync();

                            commadResponse = JsonConvert.DeserializeObject<CommadResponse>(apiResponse);
                        }
                        else
                        {
                            commadResponse.success = false;
                            commadResponse.message = this.configuration["errorMessage:errorSaveGenders"];
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                commadResponse.success = false;
                commadResponse.message = this.configuration["errorMessage:errorSaveGenders"];
                this.logger.LogError($" {commadResponse.message} : {ex.Message}", ex.ToString());

            }
            return commadResponse;
        }

        public async  Task<CommadResponse> Update(GenderUpdateRequest genderUpdate)
        {
            CommadResponse commadResponse = new CommadResponse();
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(genderUpdate), Encoding.UTF8, "application/json");
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    httpClient.BaseAddress = new Uri(this.urlBase);
                    using (var resp = await httpClient.PutAsync($"{this.urlBase}/Gender/UpdateGender", content))
                    {

                        if (resp.IsSuccessStatusCode)
                        {
                            string apiResponse = await resp.Content.ReadAsStringAsync();

                            commadResponse = JsonConvert.DeserializeObject<CommadResponse>(apiResponse);
                        }
                        else
                        {
                            commadResponse.success = false;
                            commadResponse.message = this.configuration["errorMessage:errorUpdateGender"];
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                commadResponse.success = false;
                commadResponse.message = this.configuration["errorMessage:errorUpdateGender"];
                this.logger.LogError($" {commadResponse.message} : {ex.Message}", ex.ToString());

            }
            return commadResponse;
        }
    }
}
