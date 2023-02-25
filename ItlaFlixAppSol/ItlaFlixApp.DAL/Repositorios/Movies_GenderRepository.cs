using ItlaFlixApp.DAL.Context;
using ItlaFlixApp.DAL.Entities;
using ItlaFlixApp.DAL.Interfaces;
using ItlaFlixApp.DAL.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItlaFlixApp.DAL.Repositorios
{
    public class Movies_GenderRepository : IMovies_GenderRepository
    {

        private readonly ItlaContext _itlacontext;
        private readonly ILogger<Movies_GenderRepository> _logger;

        public Movies_GenderRepository()
        {
        }

        public Movies_GenderRepository(ItlaContext itlacontext, ILogger<Movies_GenderRepository> logger)
        {
            _itlacontext = itlacontext;
            _logger = logger;
        }
        public void Add(Movies_Gender MoviesGender)
        {
            try
            {
                Movies_Gender MovieGenderToAdd = new Movies_Gender();
                MovieGenderToAdd.cod_pelicula = MoviesGender.cod_pelicula;

                _itlacontext.Add(MovieGenderToAdd);
                _itlacontext.SaveChanges();

            }
            catch (Exception ex)
            {

                _logger.LogError($" Error agregando el genero {ex.Message}", ex.ToString());
            }
        }

        public void Delete(Movies_Gender MoviesGender)
        {
            try
            {
                Movies_Gender MoviesGenderToRemove = this.Get(MoviesGender.cod_genero);
                MoviesGenderToRemove.cod_genero = MoviesGender.cod_genero;
                _itlacontext.Remove(MoviesGenderToRemove);
                _itlacontext.SaveChanges();
            }
            catch (Exception ex)
            {

                _logger.LogError($" Error borrando el genero  {ex.Message}", ex.ToString());
            }
        }

        public bool Exists(int cod_genero)
        {
            return _itlacontext.tGeneroPelicula.Any(cd => cd.cod_genero == cod_genero);
        }

        public bool Exists(string txt_desc)
        {
            throw new NotImplementedException();
        }

        public Movies_Gender Get(int cod_genero)
        {
            return _itlacontext.tGeneroPelicula.Find(cod_genero);
        }

        public List<Movie_GenderModel> GetAll()
        {
            var Genders = _itlacontext.tGeneroPelicula.Select(cd => new Movie_GenderModel()
            {
              cod_genero = cd.cod_genero,
              cod_pelicula = cd.cod_pelicula,
            }).ToList();

           return Genders;
          
        }

        public void Update(Movies_Gender moviesGender)
        {
            try
            {
                Movies_Gender MoviesGenderToUpdate = this.Get(moviesGender.cod_genero);
                MoviesGenderToUpdate.cod_genero = moviesGender.cod_genero;
                MoviesGenderToUpdate.cod_pelicula = moviesGender.cod_pelicula;
                _itlacontext.tGeneroPelicula.Update(MoviesGenderToUpdate);
                _itlacontext.SaveChanges();
            }
            catch (Exception ex)
            {

                _logger.LogError($" Error actualizando el genero  {ex.Message}", ex.ToString());
            }
        }
    }
}
