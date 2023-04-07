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
    public class UserApiService : IUserApiService
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<UserApiService> logger;
        private readonly IHttpClientFactory httpClientFactory;
        private readonly string urlBase;

        public UserApiService(IConfiguration configuration, ILogger<UserApiService> logger, IHttpClientFactory httpClientFactory) 
        {
            this.configuration = configuration;
            this.logger = logger;
            this.httpClientFactory = httpClientFactory;
            this.urlBase = this.configuration["apiConfig:baseUrl"];
        }

        public async Task<UserDetailResponse> GetUser(int id)
        {
            UserDetailResponse response = new UserDetailResponse();
            try
            {
                using (var HttpCliente = this.httpClientFactory.CreateClient())
                {
                    using (var resp = await HttpCliente.GetAsync($"{this.urlBase}/User/{id}"))
                    {
                        if (resp.IsSuccessStatusCode)
                        {
                            string jsonResp = await resp.Content.ReadAsStringAsync();
                            response = JsonConvert.DeserializeObject<UserDetailResponse>(jsonResp);
                        }
                        else
                        {
                            response.success = false;
                            response.message = this.configuration["error:errorGetUser"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = this.configuration["error:errorGetUser"];
                this.logger.LogError($" {response.message} : {ex.Message}", ex.ToString());
            }


            return response;
        }

        public async Task<UserListResponse> GetUsers()
        {
           UserListResponse response = new UserListResponse();

            try
            {
                using (var HttpCliente  = this.httpClientFactory.CreateClient())
                {
                    using (var resp = await HttpCliente.GetAsync($"{this.urlBase}/User"))
                    {
                        if (resp.IsSuccessStatusCode)
                        {
                            string jsonResp = await resp.Content.ReadAsStringAsync();
                            response = JsonConvert.DeserializeObject<UserListResponse>(jsonResp);
                        }
                        else
                        {
                            response.success = false;
                            response.message = this.configuration["error:errorGetUsers"];
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = this.configuration["error:errorGetUsers"];
                this.logger.LogError($" {response.message} : {ex.Message}", ex.ToString());
            }

            return response;
        }

        public async Task<CommadResponse> Save(UserCreateRequest userCreate)
        {
            CommadResponse response = new CommadResponse();

            try
            {
                using (var HttpCliente = this.httpClientFactory.CreateClient())
                {

                    StringContent request = new StringContent(JsonConvert.SerializeObject(userCreate), Encoding.UTF8, "application/json");

                    using (var resp = await HttpCliente.PostAsync($"{this.urlBase}/User/SaveUser", request))
                    {

                        if (resp.IsSuccessStatusCode)
                        {
                            string jsonResp = await resp.Content.ReadAsStringAsync();
                            response = JsonConvert.DeserializeObject<CommadResponse>(jsonResp);
                        }
                        else
                        {
                            response.success = false;
                            response.message = this.configuration["error:errorSaveUser"];
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = this.configuration["error:errorSaveUser"];
                this.logger.LogError($" {response.message} : {ex.Message}", ex.ToString());
            }

            return response;
        }

        public async Task<CommadResponse> Update(UserUpdateRequest userUpdate)
        {
            CommadResponse response = new CommadResponse();

            try
            {
                using (var HttpCliente = this.httpClientFactory.CreateClient())
                {
                    StringContent request = new StringContent(JsonConvert.SerializeObject(userUpdate), Encoding.UTF8, "application/json");

                    using (var resp = await HttpCliente.PutAsync($"{this.urlBase}/User/UpdateUser", request))
                    {

                        if (resp.IsSuccessStatusCode)
                        {
                            string jsonResp = await resp.Content.ReadAsStringAsync();
                            response = JsonConvert.DeserializeObject<CommadResponse>(jsonResp);
                        }
                        else
                        {
                            response.success = false;
                            response.message = this.configuration["error:errorUpdateUser"];
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = this.configuration["error:errorUpdateUser"];
                this.logger.LogError($" {response.message} : {ex.Message}", ex.ToString());
            }

            return response;
        }
    
    }
}
