using GSF.Console;
using ItlaFlixApp.WEB.Models.Requests;
using ItlaFlixApp.WEB.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ItlaFlixApp.WEB.Controllers
{
    public class UserController : Controller
    {
        HttpClientHandler handler = new HttpClientHandler();
        private readonly ILogger<UserController> logger;
        private readonly IConfiguration configuration;
        private readonly string urlBase;

        public UserController(ILogger<UserController> logger, IConfiguration configuration)
        {
            this.logger = logger;
            this.configuration = configuration;
            this.urlBase = this.configuration["apiConfig:baseUrl"];
        }


        public async Task<ActionResult> Index()
        {
            UserListResponse userList = new UserListResponse();
            try
            {
                using (var HttpClient  = new HttpClient(this.handler))
                {
                    var response = await HttpClient.GetAsync($"{this.urlBase}/User");
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResult = await response.Content.ReadAsStringAsync();

                        userList = JsonConvert.DeserializeObject<UserListResponse>(apiResult);
                    }
                    else
                    {
                        // Crear logica
                    }
                }
                return View(userList.data);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<ActionResult> Details(int id)
        {
            UserDetailResponse detailResponse =  new UserDetailResponse();

            try
            {
                using (var httpClient = new HttpClient(this.handler))
                {
                    var response = await httpClient.GetAsync( $"{ this.urlBase }/User/{ id }");

                    if (response.IsSuccessStatusCode )
                    {
                        string apiResult = await response.Content.ReadAsStringAsync();

                        detailResponse = JsonConvert.DeserializeObject<UserDetailResponse>(apiResult);
                    }
                    else
                    {
                        // logica por hacer
                    }
                }
                return View(detailResponse.data);
            }
            catch (Exception ex)
            {

                this.logger.LogError("Error obteniendo el detalle del usuario", ex.ToString());
            }
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserCreateRequest createRequest)
        {
            CommadResponse commadResponse = new CommadResponse();

            try
            {
                using (var httpClient = new HttpClient(this.handler))
                {
                    StringContent request = new StringContent(JsonConvert.SerializeObject(createRequest), Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync($"{this.urlBase}/User/SaveUser", request);

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
            UserDetailResponse detailResponse = new UserDetailResponse();

            try
            {
                using (var httpClient = new HttpClient(this.handler))
                {
                    var response = await httpClient.GetAsync($"{this.urlBase}/User/{id}");

                    if (response.IsSuccessStatusCode )
                    {
                        String apiResult = await response.Content.ReadAsStringAsync();

                        detailResponse = JsonConvert.DeserializeObject<UserDetailResponse>(apiResult);
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

                this.logger.LogError("Error editando el usuario", ex.ToString());
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UserUpdateRequest userUpdate)
        {
            CommadResponse commadResponse = new CommadResponse();
            try
            {
                using (var httpClient = new HttpClient(this.handler))
                {
                    StringContent request = new StringContent(JsonConvert.SerializeObject(userUpdate), Encoding.UTF8, "application/json");

                    var response = await httpClient.PutAsync($"{this.urlBase}/User/UpdateUser", request);
                    
                    string apiResult = await response.Content.ReadAsStringAsync();

                    commadResponse = JsonConvert.DeserializeObject<CommadResponse>(apiResult);
                        
                    if (response.IsSuccessStatusCode )
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

 
        public async Task<ActionResult> Delete(int id)
        {
            UserDeleteResponse detailResponse = new UserDeleteResponse();

            try
            {
                using (var httpClient = new HttpClient(this.handler))
                {
                    var response = await httpClient.GetAsync($"{this.urlBase}/User/RemoveUser/{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        String apiResult = await response.Content.ReadAsStringAsync();

                        detailResponse = JsonConvert.DeserializeObject<UserDeleteResponse>(apiResult);
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

                this.logger.LogError("Error eliminando el usuario", ex.ToString());
            }
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(UserDeleteRequest userDelete)
        {
            return View();
        }
    }
}
