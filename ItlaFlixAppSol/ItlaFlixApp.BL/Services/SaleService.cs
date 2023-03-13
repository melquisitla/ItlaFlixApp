
using ItlaFlixApp.BL.Contract;
using ItlaFlixApp.BL.Core;
using ItlaFlixApp.BL.Dtos.Sale;
using ItlaFlixApp.BL.Models;
using ItlaFlixApp.DAL.Entities;
using ItlaFlixApp.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace ItlaFlixApp.BL.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository saleRepository;
        private readonly ILogger<SaleService> logger;

        public SaleService(ISaleRepository saleRepository, ILogger<SaleService> logger)
        {
            this.saleRepository = saleRepository;
            this.logger = logger;
        }
        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var sales = this.saleRepository.GetEntities().Select(cd => new SaleResultModel()
                {
                    Id = cd.id,
                    cod_pelicula = cd.cod_pelicula,
                    cod_usuario = cd.cod_usuario,
                    precio = cd.precio,
                    fecha = cd.fecha,

                }).ToList();

                result.Data = sales;
                result.Success = true;
                result.Message = "Las ventas han sido encontradas correctamente";
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrio un error obteniendo las Ventas";
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
                var sale = this.saleRepository.GetEntity(id);
                SaleResultModel saleResultModel = new SaleResultModel()
                {
                    Id = sale.id,
                    cod_pelicula = sale.cod_pelicula,
                    cod_usuario = sale.cod_usuario,
                    precio = sale.precio,
                    fecha = sale.fecha,

                };
                
                result.Data = saleResultModel;
                result.Success = true;
                result.Message = "La venta ha sido encontrada correctamente";
            }
            catch (Exception ex)
            {

                result.Message = "Ocurrio un error obteniendo la Venta";
                result.Success = false;
                this.logger.LogError($" {result.Message} ", ex.ToString());
            }
            return result;
        }

        public ServiceResult RemoveSale(SaleRemoveDto removeDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                Sale saleToRemove = this.saleRepository.GetEntity(removeDto.Id);

               // saleToRemove.Deleted = saleToRemove.Removed;
               this.saleRepository.Remove(saleToRemove);
                result.Success = true;
                result.Message = "La venta ha sido eliminada correctamente";
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrio un error removiendo la venta";
                result.Success = false;
                this.logger.LogError($" {result.Message} ", ex.ToString());
            }
            return result;
        }

        public ServiceResult SaveSale(SaleSaveDto saveDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                Sale sale = new Sale()
                {
                    cod_pelicula = saveDto.cod_pelicula,
                    cod_usuario= saveDto.cod_usuario,
                    precio = saveDto.precio,
                    fecha = saveDto.fecha,
                };

                this.saleRepository.Save(sale);
                result.Success = true;
                result.Message = "La venta ha sido agregada correctamente";
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrio un error agregando la nueva venta";
                result.Success = false;
                this.logger.LogError($" {result.Message} ", ex.ToString());
            }
            return result;
        }

        public ServiceResult UpdateSale(SaleUpdateDto updateDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                Sale sale = this.saleRepository.GetEntity(updateDto.Id);
                sale.id = updateDto.Id;
                sale.cod_pelicula = updateDto.cod_pelicula;
                sale.cod_usuario = updateDto.cod_usuario;
                sale.precio = updateDto.precio;
                sale.fecha = updateDto.fecha;

                this.saleRepository.Update(sale);
                result.Success = true;
                result.Message = "La venta ha sido actualizada correctamente";
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrio un error actualizando la nueva venta";
                result.Success = false;
                this.logger.LogError($" {result.Message} ", ex.ToString());
            }
            return result;
        }
    }
}
