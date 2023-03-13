using ItlaFlixApp.BL.Contract;
using ItlaFlixApp.BL.Dtos.Rent;
using ItlaFlixApp.BL.Core;
using ItlaFlixApp.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;
using ItlaFlixApp.BL.Models;
using System.Linq;
using ItlaFlixApp.DAL.Entities;
using System;

namespace ItlaFlixApp.BL.Services
{
    public class RentService : IRentService
    {
        private readonly IRentRepository rentRepository;
        private readonly ILogger logger;
        public RentService(IRentRepository rentRepository,
                           ILogger <RentService> logger)
        { 
            this.rentRepository = rentRepository;
            this.logger = logger;
        }
        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var rent = this.rentRepository.GetEntities().Select(cd => new RentResultModel()
                { 
                 Id = cd.Id,
                 cod_pelicula = cd.cod_pelicula,
                 cod_usuario= cd.cod_usuario,
                 precio = cd.precio,
                 Devuelta= cd.devuelta,
                 fecha= cd.fecha,
                }).ToList();
                result.Data = rent;
                result.Success= true;
            }
            catch (System.Exception ex)
            {
             result.Message = "Ocurrio un error obteniendo la renta de la pelicula" ;
                result.Success = true ;
                this.logger.LogError($" {result.Message}", ex.ToString());
            }
            return result;
            //throw new System.NotImplementedException();
        }

       // public ServiceResult GetBy()
        //{
           // throw new System.NotImplementedException();
       // }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();
            try 
            {
                var rent = this.rentRepository.GetEntity(id);
                  RentResultModel rentResultModel = new RentResultModel ()
                {
                    Id = rent.Id,
                    cod_pelicula = rent.cod_pelicula,
                    cod_usuario = rent.cod_usuario,
                    precio = rent.precio,
                    Devuelta = rent.devuelta,
                    fecha = rent.fecha,
                };
                result.Data = rentResultModel;
                result.Success = true;
            }
            catch (System.Exception ex) 
            {
                result.Message = "Ocurrio un error obteniendo la renta de la pelicula";
                result.Success = true;
                this.logger.LogError($" {result.Message}", ex.ToString());
            }
            return result;
            // throw new System.NotImplementedException(); 
        }

        public ServiceResult RemoveRent (RentRemoveDto removeDto) 
        {
            ServiceResult result = new ServiceResult();
            try
            {
                Rent rent = this.rentRepository.GetEntity(removeDto.Id);
                rent.cod_usuario = removeDto.cod_usuario;
                rent.cod_pelicula = removeDto.cod_pelicula;
                rent.precio = removeDto.precio;
                rent.devuelta=removeDto.devuelta;
                this.rentRepository.Update(rent);
                this.rentRepository.SaveChanges();
                result.Success = true;
                result.Message = "El Alquiler fue Removido Exitosamente";
            }
            catch (Exception ex)
            {
                result.Message = "Error, Removiendo el alquiler";
                result.Success = false;
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result; 


        }
        public ServiceResult SaveRent (RentSaveDto saveDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                Rent rent= new Rent()
                {
                    Id= saveDto.Id,
                    cod_pelicula = saveDto.cod_pelicula,
                    cod_usuario = saveDto.cod_usuario,
                    precio = saveDto.precio,
                   fecha = DateTime.Now, 
                     
                };
                this.rentRepository.Save(rent);
                this.rentRepository.SaveChanges();
                result.Message = "El alquiler fue reservado Exitosamente";
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Message = "Error Guardando el aquiler de pelicula";
                result.Success = false;
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result; 
        }
        public ServiceResult UpdateRent(RentUpdateDto updateDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                Rent rent = this.rentRepository.GetEntity(updateDto.Id);
                rent.Id= updateDto.Id;
                rent.cod_usuario = updateDto.cod_usuario;
                rent.cod_pelicula = updateDto.cod_pelicula;
                rent.precio = updateDto.precio;
                rent.devuelta = updateDto.devuelta;
                this.rentRepository.Update(rent);
                this.rentRepository.SaveChanges();
                result.Success = true;
                result.Message = "El Alquiler fue actualizado Exitosamente";
            }
            catch (Exception ex)
            {
                result.Message = "Error, actualizando el alquiler";
                result.Success = false;
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
    }
}     
        



