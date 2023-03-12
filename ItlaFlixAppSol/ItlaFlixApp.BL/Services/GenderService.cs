using ItlaFlixApp.BL.Contract;
using ItlaFlixApp.BL.Core;
using ItlaFlixApp.BL.Dtos.Gender;
using ItlaFlixApp.BL.Models;
using ItlaFlixApp.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace ItlaFlixApp.BL.Services
{
    public class GenderService : IGenderServices
    {
        private readonly IGenderRepository genderRepository;
        private readonly ILogger<GenderService> logger;

        public GenderService(IGenderRepository genderRepository,
                            ILogger<GenderService> logger) 
        {
            this.genderRepository = genderRepository;
            this.logger = logger;
        }
        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var movies = this.genderRepository.GetEntities().Select(cd => new GenderResultModel()
                {
                    txt_desc = cd.txt_desc,
                    cod_genero= cd.cod_genero,
                   
                }).ToList();
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrio un error obteniendo el genero";
                result.Success = false;
                this.logger.LogError($" {result.Message} ", ex.ToString());
            }
            return result;
        }

        public ServiceResult GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult RemoveGender(GenderRemoveDto removeDto)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult SaveGender(GenderSaveDto saveDto)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult UpdateGender(GenderUpdateDto updateDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
