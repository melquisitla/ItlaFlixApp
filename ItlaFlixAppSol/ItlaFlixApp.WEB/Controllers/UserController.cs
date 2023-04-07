﻿using GSF.Console;
using ItlaFlixApp.WEB.ApiServices.Interfaces;
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
        private readonly IUserApiService userApiService;
        private readonly string urlBase;

        public UserController(ILogger<UserController> logger, IConfiguration configuration, IUserApiService userApiService)
        {
            this.logger = logger;
            this.configuration = configuration;
            this.userApiService = userApiService;
            this.urlBase = this.configuration["apiConfig:baseUrl"];
        }


        public async Task<ActionResult> Index()
        {
            UserListResponse userList = new UserListResponse();
            try
            {
                userList = await this.userApiService.GetUsers();

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
                detailResponse = await this.userApiService.GetUser(id);

                return View(detailResponse.data);
            }
            catch (Exception ex)
            {

                this.logger.LogError("Error obteniendo el detalle del usuario", ex.ToString());
            }
            return View();
        }

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
                commadResponse = await this.userApiService.Save(createRequest);
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
            UserDetailResponse detailResponse = new UserDetailResponse();

            try
            {
                detailResponse = await this.userApiService.GetUser(id);

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
                commadResponse = await this.userApiService.Update(userUpdate);
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
