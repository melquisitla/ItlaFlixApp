using ItlaFlixApp.DAL.Context;
using ItlaFlixApp.DAL.Entities;
using ItlaFlixApp.DAL.Interfaces;
using ItlaFlixApp.DAL.Models;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace ItlaFlixApp.DAL.Repositorios
{
    public class SaleRepositories : ISaleRepository
    {
        /*        private readonly ItlaContext context;
                private readonly ILogger<SaleRepositories> logger;

                public SaleRepositories(ItlaContext context, ILogger<SaleRepositories> logger) 
                { 
                    this.context = context;
                    this.logger = logger;
                }*/
        public void Add(Sale sale)
        {
            throw new NotImplementedException();
        }

        public Sale Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<SaleModel> GetAll()
        {
            return new List<SaleModel>
            {
                new SaleModel(){cod_venta = 1, Usuario = "wagner25", Titulo = "Wakanda Forever", Precio = 350.00F, Fecha = DateTime.Now},
                new SaleModel(){cod_venta = 2, Usuario = "wnovas69", Titulo = "Rapido y Furioso 9", Precio = 250.00F, Fecha = DateTime.Now},
                new SaleModel(){cod_venta = 3, Usuario = "mmateo01", Titulo = "Matrix Resurreccion", Precio = 150.00F, Fecha = DateTime.Now},
            };
        }

        public void Remove(Sale sale)
        {
            throw new NotImplementedException();
        }

        public void Update(Sale sale)
        {
            throw new NotImplementedException();
        }
    }
}
