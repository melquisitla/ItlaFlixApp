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
    public class MovieApiServices : IMovieApiServices
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<MovieApiServices> logger;
        private readonly IHttpClientFactory httpClientFactory;
        
        private readonly string urlBase;
        public MovieApiServices(IConfiguration configuration, ILogger<MovieApiServices> logger,
                                 IHttpClientFactory httpClientFactory
                                 ) 
        {
            this.configuration = configuration;
            this.logger = logger;
            this.httpClientFactory = httpClientFactory;
            
            this.urlBase = this.configuration["apiConfig:baseURL"];
        }
        public async Task<MovieDetailResponse> GetMovie(int id)
        {
            MovieDetailResponse movieResponse = new MovieDetailResponse();

            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {

                    using (var response = await httpClient.GetAsync($"{this.urlBase}/Movie/" + id))
                    {

                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            movieResponse = JsonConvert.DeserializeObject<MovieDetailResponse>(apiResponse);
                        }
                        

                    }

                }
            }
            catch (Exception ex)
            {
                movieResponse.message = this.configuration["errorMessage:errorGetMovies"];
                movieResponse.success = false;
                this.logger.LogError($" {movieResponse.message} : {ex.Message}", ex.ToString());
            }

            return movieResponse;
        }

        public async Task<MovieListResponse> GetMovies()
        {
            MovieListResponse response = new MovieListResponse();
            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    using (var resp = await httpClient.GetAsync($"{this.urlBase}/Movie"))
                    { 
                         if(resp.IsSuccessStatusCode) 
                        { 
                           string jsonResp = await resp.Content.ReadAsStringAsync();
                            response = JsonConvert.DeserializeObject<MovieListResponse>(jsonResp);
                        
                        }
                    
                    }
                }

            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = this.configuration["errorMessage:errorGetMovies"];
                this.logger.LogError($" {response.message} : {ex.Message}", ex.ToString());
            }
            return response;
        }

        public async Task<CommadResponse> Save(MovieCreateRequest movieCreate)
        {
            CommadResponse commadResponse = new CommadResponse();   
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(movieCreate), Encoding.UTF8, "application/json");
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    httpClient.BaseAddress = new Uri(this.urlBase);
                    using (var resp = await httpClient.PostAsync($"{this.urlBase}/Movie/SaveMovie", content))
                    {
                      
                        if (resp.IsSuccessStatusCode)
                        {
                            string apiResponse = await resp.Content.ReadAsStringAsync();

                            commadResponse = JsonConvert.DeserializeObject<CommadResponse>(apiResponse);
                        }
                        else
                        {
                            commadResponse.success = false;
                            commadResponse.message = this.configuration["errorMessage:errorSaveMovies"];
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                commadResponse.success = false;
                commadResponse.message = this.configuration["errorMessage:errorSaveMovies"];
                this.logger.LogError($" {commadResponse.message} : {ex.Message}", ex.ToString());

            }
            return commadResponse;
        }

        public async Task<CommadResponse> Update(MovieUpdateRequest movieUpdate)
        {
            CommadResponse commadResponse = new CommadResponse();
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(movieUpdate), Encoding.UTF8, "application/json");
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    httpClient.BaseAddress = new Uri(this.urlBase);
                    using (var resp = await httpClient.PutAsync($"{this.urlBase}/Movie/UpdateMovie", content))
                    {

                        if (resp.IsSuccessStatusCode)
                        {
                            string apiResponse = await resp.Content.ReadAsStringAsync();

                            commadResponse = JsonConvert.DeserializeObject<CommadResponse>(apiResponse);
                        }
                        else
                        {
                            commadResponse.success = false;
                            commadResponse.message = this.configuration["errorMessage:errorUpdateMovie"];
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                commadResponse.success = false;
                commadResponse.message = this.configuration["errorMessage:errorUpdateMovie"];
                this.logger.LogError($" {commadResponse.message} : {ex.Message}", ex.ToString());

            }
            return commadResponse;
        }
    }
}
