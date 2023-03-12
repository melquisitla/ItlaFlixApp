﻿using ItlaFlixApp.BL.Contract;
using ItlaFlixApp.BL.Core;
using ItlaFlixApp.BL.Dtos.Movie;
using ItlaFlixApp.BL.Models;
using ItlaFlixApp.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace ItlaFlixApp.BL.Services
{
    public class MovieService : IMovieServices
    {
        private readonly IMovieRepository movieRepository;
        private readonly ILogger<MovieService> logger;

        public MovieService(IMovieRepository movieRepository, 
                            ILogger<MovieService> logger) 
        {
            this.movieRepository = movieRepository;
            this.logger = logger;
        }
        public ServiceResult GetAll()
        {
           ServiceResult result = new ServiceResult();

            try
            {
                var movies = this.movieRepository.GetEntities().Select(cd => new MovieResultModel() 
                {
                  txt_desc = cd.txt_desc,
                  precio_venta = cd.precio_venta,
                  precio_alquiler = cd.precio_alquiler,
                  cod_Peliculas = cd.cod_pelicula,
                  cant_disponibles_alquiler = cd.cant_disponibles_alquiler,
                  cant_disponibles_venta = cd.cant_disponibles_venta
                }).ToList();
                result.Data = movies;
                result.Success = true;

            }
            catch (Exception ex)
            {
                result.Message = "Ocurrio un error obteniendo la pelicula";
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
                var movies = this.movieRepository.GetEntity(id);
                    
                    MovieResultModel movieResultModel = new MovieResultModel()
                {
                    txt_desc = movies.txt_desc,
                    precio_venta = movies.precio_venta,
                    precio_alquiler = movies.precio_alquiler,
                    cod_Peliculas = movies.cod_pelicula,
                    cant_disponibles_alquiler = movies.cant_disponibles_alquiler,
                    cant_disponibles_venta = movies.cant_disponibles_venta
                };
                result.Data = movies;
                result.Success = true;

            }
            catch (Exception ex)
            {
                result.Message = "Ocurrio un error obteniendo la pelicula";
                result.Success = false;
                this.logger.LogError($" {result.Message} ", ex.ToString());
            }
            return result;
        }

        public ServiceResult RemoveMovie(MovieRemoveDto removeDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var movies = this.movieRepository.GetEntities().Select(cd => new MovieResultModel()
                {
                    txt_desc = cd.txt_desc,
                    precio_venta = cd.precio_venta,
                    precio_alquiler = cd.precio_alquiler,
                    cod_Peliculas = cd.cod_pelicula,
                    cant_disponibles_alquiler = cd.cant_disponibles_alquiler,
                    cant_disponibles_venta = cd.cant_disponibles_venta
                }).ToList();
                result.Data = movies;
                result.Success = true;

            }
            catch (Exception ex)
            {
                result.Message = "Ocurrio un error removiendo la pelicula";
                result.Success = false;
                this.logger.LogError($" {result.Message} ", ex.ToString());
            }
            return result;
        }

        public ServiceResult SaveMovie(MovieSaveDto saveDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var movies = this.movieRepository.GetEntities().Select(cd => new MovieResultModel()
                {
                    txt_desc = cd.txt_desc,
                    precio_venta = cd.precio_venta,
                    precio_alquiler = cd.precio_alquiler,
                    cod_Peliculas = cd.cod_pelicula,
                    cant_disponibles_alquiler = cd.cant_disponibles_alquiler,
                    cant_disponibles_venta = cd.cant_disponibles_venta
                }).ToList();
                result.Data = movies;
                result.Success = true;

            }
            catch (Exception ex)
            {
                result.Message = "Ocurrio un error guardando la pelicula";
                result.Success = false;
                this.logger.LogError($" {result.Message} ", ex.ToString());
            }
            return result;
        }

        public ServiceResult UpdateMovie(MovieUpdateDto updateDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var movies = this.movieRepository.GetEntities().Select(cd => new MovieResultModel()
                {
                    txt_desc = cd.txt_desc,
                    precio_venta = cd.precio_venta,
                    precio_alquiler = cd.precio_alquiler,
                    cod_Peliculas = cd.cod_pelicula,
                    cant_disponibles_alquiler = cd.cant_disponibles_alquiler,
                    cant_disponibles_venta = cd.cant_disponibles_venta
                }).ToList();
                result.Data = movies;
                result.Success = true;

            }
            catch (Exception ex)
            {
                result.Message = "Ocurrio un error actualizando la pelicula";
                result.Success = false;
                this.logger.LogError($" {result.Message} ", ex.ToString());
            }
            return result;
        }
    }
}
