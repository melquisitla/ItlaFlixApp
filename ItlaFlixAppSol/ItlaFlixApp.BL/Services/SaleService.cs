
using ItlaFlixApp.BL.Contract;
using ItlaFlixApp.BL.Core;
using ItlaFlixApp.BL.Dtos.Sale;
using ItlaFlixApp.BL.Models;
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
            throw new System.NotImplementedException();
        }

        public ServiceResult RemoveSale(SaleRemoveDto removeDto)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult SaveSale(SaleSaveDto saveDto)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult UpdateSale(SaleUpdateDto updateDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
