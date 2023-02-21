using System.Collections.Generic;
using ItlaFlixApp.DAL.Context;
using ItlaFlixApp.DAL.Entities;
using System.Linq;
using ItlaFlixApp.DAL.Exceptions;
using ItlaFlixApp.DAL.Interfaces;
using ItlaFlixApp.DAL.Models;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Numerics;

namespace ItlaFlixApp.DAL.Repositorios
{
    public class MovieRepositories : IMovieRepository

    {


        private readonly ItlaContext _itlacontext;
        private readonly ILogger<MovieRepositories> _logger;

        public MovieRepositories(ItlaContext itlacontext, ILogger<MovieRepositories> logger)
        {
            _itlacontext = itlacontext;
            _logger = logger;
        }

        public void Add(Movie movie)
        {
            try
            {

                Movie MovieToAdd = new Movie();

                MovieToAdd.txt_desc = movie.txt_desc;
                MovieToAdd.cant_disponibles_venta = movie.cant_disponibles_venta;
                MovieToAdd.cant_disponibles_alquiler = movie.cant_disponibles_alquiler;
                MovieToAdd.precio_venta = movie.precio_venta;
                MovieToAdd.precio_alquiler = movie.precio_alquiler;

                _itlacontext.Add(MovieToAdd);
                _itlacontext.SaveChanges();
            }
            catch (Exception ex)
            {

                _logger.LogError($" Error borrando la pelicula  {ex.Message}", ex.ToString());
            }

        }

        public void Delete(Movie movie)
        {
            try
            {
                Movie MovieToRemove = this.Get(movie.cod_pelicula);

                MovieToRemove.cod_pelicula = movie.cod_pelicula;
                
                _itlacontext.tPeliculas.Remove(MovieToRemove);
                _itlacontext.SaveChanges();



            }
            catch (Exception ex)
            {

                _logger.LogError($" Error borrando la pelicula  {ex.Message}", ex.ToString());
            }
        }

        public bool Exists(int cod_pelicula)
        {
            return _itlacontext.tPeliculas.Any(cd => cd.cod_pelicula == cod_pelicula);

        }

        public Movie Get(int id)
        {
            return _itlacontext.tPeliculas.Find(id);
        }

        public List<MovieModel> GetAll()
        {

            var Movies = _itlacontext.tPeliculas.Select(cd => new MovieModel()
            {
                cod_pelicula = cd.cod_pelicula,
                txt_desc = cd.txt_desc,
                precio_venta = cd.precio_venta,
                precio_alquiler = cd.precio_alquiler,
                cant_disponibles_alquiler = cd.cant_disponibles_alquiler,
                cant_disponibles_venta = cd.cant_disponibles_venta

            }).ToList();
            return Movies;
        }

        public void Update(Movie movie)
        {
            try
            {
                Movie MovieToUpdate = this.Get(movie.cod_pelicula);

                MovieToUpdate.cod_pelicula = movie.cod_pelicula;
                MovieToUpdate.cant_disponibles_venta = movie.cant_disponibles_venta;
                MovieToUpdate.cant_disponibles_alquiler = movie.cant_disponibles_alquiler;
                MovieToUpdate.precio_venta = movie.precio_venta;
                MovieToUpdate.precio_alquiler = movie.precio_alquiler;
                MovieToUpdate.txt_desc = movie.txt_desc;
                _itlacontext.tPeliculas.Update(MovieToUpdate);
                _itlacontext.SaveChanges();
            }
            catch (Exception ex)
            {

                _logger.LogError($" Error actualizando la pelicula  {ex.Message}", ex.ToString());
            }
        }

    }
}

