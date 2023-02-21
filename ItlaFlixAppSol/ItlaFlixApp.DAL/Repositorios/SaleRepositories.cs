using System.Collections.Generic;
using System.Linq;
using ItlaFlixApp.DAL.Context;
using ItlaFlixApp.DAL.Entities;
using ItlaFlixApp.DAL.Interfaces;
using ItlaFlixApp.DAL.Models;
using Microsoft.Extensions.Logging;
using System;


namespace ItlaFlixApp.DAL.Repositorios
{
    public class SaleRepositories : ISaleRepository
    {
        private readonly ItlaContext _ItlaContext;
        private readonly ILogger<SaleRepositories> _logger;

        public SaleRepositories(ItlaContext ItlaContext, ILogger<SaleRepositories> logger)
        {
            _ItlaContext = ItlaContext;
            _logger = logger;
        }

        public void Add(Sale sale)
        {
            try
            {
                Sale saleToAdd = new Sale()
                {
                    id = sale.id,
                    cod_pelicula= sale.cod_pelicula,
                    precio= sale.precio,
                    cod_usuario= sale.cod_usuario,  
                    fecha = sale.fecha
                };
                _ItlaContext.tVentaPeliculas.Add(saleToAdd);
                _ItlaContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error agregando el usuario {ex.Message}", ex.ToString());
            }

        }

        public Sale Get(int id)
        {
            return _ItlaContext.tVentaPeliculas.Find(id);
        }

        public List<SaleModel> GetAll()
        {
            var sales = _ItlaContext.tVentaPeliculas.Select(cd => new SaleModel()
            {
                id = cd.id,
                cod_pelicula = cd.cod_pelicula,
                cod_usuario= cd.cod_usuario,
                precio = cd.precio,
                fecha = cd.fecha,
            }).ToList();

            return sales;
        }

        public void Remove(Sale sale)
        {
            try
            {
                Sale saleToRemove = this.Get(sale.id);
                saleToRemove.id = sale.id;

                _ItlaContext.tVentaPeliculas.Remove(saleToRemove);
                _ItlaContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error removiendo el usuario {ex.Message}", ex.ToString());
            }
        }

        public void Update(Sale sale)
        {
            try
            {
                Sale saleToUpdate = this.Get(sale.id);

                saleToUpdate.cod_usuario = sale.cod_usuario;
                saleToUpdate.id = sale.id;
                saleToUpdate.cod_pelicula = sale.cod_pelicula;
                saleToUpdate.precio = sale.precio;
                saleToUpdate.fecha = DateTime.Now;

                _ItlaContext.tVentaPeliculas.Update(saleToUpdate);
                _ItlaContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error removiendo el usuario {ex.Message}", ex.ToString());
            }

        }
    }
}
