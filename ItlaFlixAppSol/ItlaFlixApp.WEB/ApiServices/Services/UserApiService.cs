using ItlaFlixApp.WEB.ApiServices.Interfaces;
using ItlaFlixApp.WEB.Models.Requests;
using ItlaFlixApp.WEB.Models.Responses;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
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

        public Task<UserDetailResponse> GetUser(int id)
        {
            throw new System.NotImplementedException();
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

        public Task<CommadResponse> Save(UserCreateRequest userCreate)
        {
            throw new System.NotImplementedException();
        }

        public Task<CommadResponse> Update(UserUpdateRequest userUpdate)
        {
            throw new System.NotImplementedException();
        }
    }
}
