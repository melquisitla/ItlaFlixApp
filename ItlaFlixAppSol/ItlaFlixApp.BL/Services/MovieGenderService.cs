using ItlaFlixApp.BL.Contract;
using ItlaFlixApp.BL.Core;
using ItlaFlixApp.BL.Dtos.MovieGender;
using ItlaFlixApp.BL.Models;
using ItlaFlixApp.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItlaFlixApp.BL.Services
{
    public class MovieGenderService : IMovieGenderService
    {
        private readonly IMovies_GenderRepository moviesGenderRepository;
        private readonly ILogger<MovieGenderService> logger;

        public MovieGenderService(IMovies_GenderRepository moviesGenderRepository, ILogger<MovieGenderService> logger)
        {
            this.moviesGenderRepository = moviesGenderRepository;
            this.logger = logger;
        }
        public ServiceResult DeleteMovieGender(MovieGenderRemoveDto removeDto)
        {
            throw new NotImplementedException();
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var movieGender = this.moviesGenderRepository.GetEntities().Select(cd => new MoviesGenderResultModel()
                {
                    Cod_genero = cd.cod_genero,
                    Cod_pelicula= cd.cod_pelicula,
                }).ToList();

                result.Data = movieGender;
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrio un error obteniendo los generos de las peliculas";
                result.Success = false;
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var MovieGender = this.moviesGenderRepository.GetEntity(id);

                MoviesGenderResultModel movieGenderResultModel = new MoviesGenderResultModel()
                {
                    Cod_genero = MovieGender.cod_genero,
                    Cod_pelicula = MovieGender.cod_pelicula,
                };

                result.Data = movieGenderResultModel;
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrio un error obteniendo el genero de la pelicula";
                result.Success = false;
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult SaveMovieGender(MovieGenderSaveDto saveDto)
        {
            throw new NotImplementedException();
        }

        public ServiceResult UpdateMovieGender(MovieGenderUpdateDto updateDto)
        {
            throw new NotImplementedException();
        }
    }
}
