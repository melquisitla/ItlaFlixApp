using ItlaFlixApp.BL.Contract;
using ItlaFlixApp.BL.Core;
using ItlaFlixApp.BL.Dtos.Gender;
using ItlaFlixApp.BL.Models;
using ItlaFlixApp.DAL.Entities;
using ItlaFlixApp.DAL.Exceptions;
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
                var genders = this.genderRepository.GetEntities().Select(cd => new GenderResultModel()
                {
                    txt_desc = cd.txt_desc,
                    cod_genero= cd.cod_genero,
                   
                }).ToList();
                result.Data = genders;
                result.Success = true;
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
            ServiceResult result = new ServiceResult();

            try
            {
                var genders = this.genderRepository.GetEntity(id);

                GenderResultModel genderResultModel = new GenderResultModel()
                {
                    txt_desc = genders.txt_desc,
                    cod_genero = genders.cod_genero,

                };
                result.Data = genders;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrio un error obteniendo el genero";
                result.Success = false;
                this.logger.LogError($" {result.Message} ", ex.ToString());
            }
            return result;
        }

        public ServiceResult RemoveGender(GenderRemoveDto removeDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                Gender genderToRemove = this.genderRepository.GetEntity(removeDto.cod_genero);
                genderToRemove.cod_genero = removeDto.cod_genero;

                result.Data = genderToRemove;
                result.Success = true;
                this.genderRepository.Update(genderToRemove);
                this.genderRepository.SaveChanges();
                result.Success = true;
                result.Message = "El genero ha sido eliminado correctamente. ";
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrio un error removiendo el genero";
                result.Success = false;
                this.logger.LogError($" {result.Message} ", ex.ToString());
            }
            return result;
        }

        public ServiceResult SaveGender(GenderSaveDto saveDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                Gender gender = new Gender()
                {
                    txt_desc = saveDto.txt_desc
                   
                };
                this.genderRepository.Save(gender);
                this.genderRepository.SaveChanges();
                result.Success = true;
                result.Message = "El genero ha sido agregado correctamente. ";
            }
            catch (GenderDataException sdex)
            {
                result.Message = sdex.Message;
                result.Success = false;
                this.logger.LogError($"{result.Message}", sdex.ToString());

            }
            catch (Exception ex)
            {
                result.Message = "Ocurrio un error guardando el genero";
                result.Success = false;
                this.logger.LogError($" {result.Message} ", ex.ToString());
            }
            return result;
        }

        public ServiceResult UpdateGender(GenderUpdateDto updateDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                Gender gender = this.genderRepository.GetEntity(updateDto.cod_genero);
                gender.cod_genero = updateDto.cod_genero;
                gender.txt_desc = updateDto.txt_desc;
                
                this.genderRepository.Update(gender);
                this.genderRepository.SaveChanges(); 
                result.Success = true;
                result.Message = "El genero ha sido actualizado correctamente. ";
            }
            catch (GenderDataException sdex)
            {
                result.Message = sdex.Message;
                result.Success = false;
                this.logger.LogError($"{result.Message}", sdex.ToString());

            }
            catch (Exception ex)
            {
                result.Message = "Ocurrio un error actualizando el genero";
                result.Success = false;
                this.logger.LogError($" {result.Message} ", ex.ToString());
            }
            return result;
        }
    }
}
