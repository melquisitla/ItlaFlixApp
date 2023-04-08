using ItlaFlixApp.WEB.ApiServices.Interfaces;
using ItlaFlixApp.WEB.Controllers;
using ItlaFlixApp.WEB.Models.Request;
using ItlaFlixApp.WEB.Models.Response;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace ItlaFlixApp.WEB.ApiServices.Services
{
    public class MoviesGenderApiService : IMoviesGenderApiServices
    {
        private readonly ILogger<MoviesGenderApiService> Logger;
        private readonly IHttpClientFactory httpClienteFactory;
        private readonly IConfiguration configuration;
        private readonly string urlBase;

        public MoviesGenderApiService(IConfiguration configuration, ILogger<MoviesGenderApiService> logger, IHttpClientFactory httpClientFactory)
        {
            this.configuration = configuration; 
            this.Logger = logger;
            this.httpClienteFactory = httpClientFactory;
            this.urlBase = this.configuration["apiConfig:baseURL"];
        }
        public async Task<MovieGenderResponse> GetMovieGender(int id)
        {
            MovieGenderResponse movieGenderResponse = new MovieGenderResponse();
            try
            {
                using(var httpClient = this.httpClienteFactory.CreateClient())
                {
                    using(var response = await httpClient.GetAsync($"{this.urlBase}//{id}"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResult = await response.Content.ReadAsStringAsync();

                            movieGenderResponse = JsonConvert.DeserializeObject<MovieGenderResponse>(apiResult);
                        }
                        else
                        {
                            // ponemos x logica
                        }
                    }
                }
            }catch(Exception ex)
            {

            }
             return movieGenderResponse;
        }

        public  async Task<MovieGenderResponse> GetMoviesGender()
        {
            MovieGenderResponse movieGenderResponse = new MovieGenderResponse();
            try
            {
                using(var httpClient = this.httpClienteFactory.CreateClient())
                {
                    using(var response = await httpClient.GetAsync(urlBase + "/Movies_Gender"))
                    {
                        if(response.IsSuccessStatusCode)
                        {
                            string apiResult = await response.Content.ReadAsStringAsync();

                            movieGenderResponse = JsonConvert.DeserializeObject<MovieGenderResponse>(apiResult);
                        }
                        else
                        {
                            // Logica en caso de error con http Request
                        }
                    }
                }
            }catch(Exception ex)
            {

            }

            return movieGenderResponse;
        }

        public async Task<CommadResponse> UpdateMovieGender(MoviesGenderUpdateRequest movieGender)
        {
            CommadResponse commandResponse = new CommadResponse();
            try
            {
                StringContent request = new StringContent(JsonConvert.SerializeObject(movieGender), Encoding.UTF8, "application/json");
                using (var httpClient = this.httpClienteFactory.CreateClient())
                {
                    using (var resp = await httpClient.PostAsync($"{this.urlBase}/Movies_Gender/UpdateMoviesGender/" + movieGender.Cod_genero, request))
                    {  
                        if (resp.IsSuccessStatusCode)
                        {
                            string apiResult = await resp.Content.ReadAsStringAsync();
                            commandResponse = JsonConvert.DeserializeObject<CommadResponse>(apiResult);
                        }
                        else
                        {
                            commandResponse.Success = false;
                            commandResponse.Message = "Hubo un error al ingresar el genero de la pelicula";
                        }
                    }
                    
                }
            }catch(Exception ex)
            {
                commandResponse.Message = "Hubo un error al ingresar el genero de la pelicula";
                commandResponse.Success = false;
                Logger.LogError(ex.Message, ex);
            }

            return commandResponse;
        }
    }
}
