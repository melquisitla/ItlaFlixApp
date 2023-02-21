using ItlaFlixApp.DAL.Context;
using ItlaFlixApp.DAL.Entities;
using ItlaFlixApp.DAL.Exceptions;
using ItlaFlixApp.DAL.Interfaces;
using ItlaFlixApp.DAL.Models;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ItlaFlixApp.DAL.Repositorios
{
    public class GenderRepositories : IGenderRepository
    {

        private readonly ItlaContext _itlacontext;
        private readonly ILogger<GenderRepositories> _logger;

        public GenderRepositories(ItlaContext itlacontext, ILogger<GenderRepositories> logger)
        {
            _itlacontext = itlacontext;
            _logger = logger;
        }
        public void Add(Gender gender)
        {
            try
            {
                Gender GenderToAdd = new Gender();
                GenderToAdd.txt_desc = gender.txt_desc;

                _itlacontext.Add(GenderToAdd);
                _itlacontext.SaveChanges();

            }
            catch (Exception ex)
            {

                _logger.LogError($" Error agregando el genero {ex.Message}", ex.ToString());
            }
        }

        public void Delete(Gender gender)
        {
            try
            {
                Gender GenderToRemove = this.Get(gender.cod_genero);
                GenderToRemove.cod_genero = gender.cod_genero;
                _itlacontext.Remove(GenderToRemove);
                _itlacontext.SaveChanges();
            }
            catch (Exception ex)
            {

                _logger.LogError($" Error borrando el genero  {ex.Message}", ex.ToString());
            }
        }

        public bool Exists(int cod_genero)
        {
            return _itlacontext.tGeneros.Any(cd => cd.cod_genero == cod_genero);
        }

        public bool Exists(string txt_desc)
        {
            throw new NotImplementedException();
        }

        public Gender Get(int cod_genero)
        {
            return _itlacontext.tGeneros.Find(cod_genero);
        }

        public List<GenderModel> GetAll()
        {
            var Genders = _itlacontext.tGeneros.Select(cd => new GenderModel()
            {
               cod_genero = cd.cod_genero,
               txt_desc = cd.txt_desc,
            }).ToList();
            return Genders;
        }

        public void Update(Gender gender)
        {
            try
            {
                Gender GenderToUpdate = this.Get(gender.cod_genero);
                GenderToUpdate.cod_genero = gender.cod_genero;
                GenderToUpdate.txt_desc = gender.txt_desc;
                _itlacontext.tGeneros.Update(GenderToUpdate);
                _itlacontext.SaveChanges();
            }
            catch (Exception ex)
            {

                _logger.LogError($" Error actualizando el genero  {ex.Message}", ex.ToString());
            }
        }
    }
}
