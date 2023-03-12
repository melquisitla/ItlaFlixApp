using ItlaFlixApp.BL.Contract;
using ItlaFlixApp.BL.Core;
using ItlaFlixApp.BL.Dtos.MovieGender;
using ItlaFlixApp.BL.Models;
using ItlaFlixApp.DAL.Entities;
using ItlaFlixApp.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

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
            ServiceResult result = new ServiceResult();
            try
            {
                Movies_Gender movieGenderToRemove = this.moviesGenderRepository.GetEntity(removeDto.Cod_genero);
                this.moviesGenderRepository.Remove(movieGenderToRemove);
                result.Success = true;
                result.Message = "El genero de la pelicula ha sido eliminado correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "hubo un error al borrar el genero de la pelicula";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var movieGender = this.moviesGenderRepository.GetEntities().Select(cd => new MoviesGenderResultModel()
                {
                    Cod_genero = cd.cod_genero,
                    Cod_pelicula = cd.cod_pelicula,
                }).ToList();

                result.Success = true;
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

                result.Success = true;
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
            ServiceResult result = new ServiceResult();

            try
            {
                Movies_Gender moviesGender = new Movies_Gender()
                {
                    cod_genero = saveDto.Cod_genero,
                    cod_pelicula = saveDto.Cod_pelicula,
                };
                this.moviesGenderRepository.Save(moviesGender);
                result.Success = true;
                result.Message = "El genero de la pelicuala ha sido guardado correctamente";
            }
            catch (Exception ex)
            {
                result.Message = "Error al guardar el genero de una pelicula";
                result.Success = false;
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult UpdateMovieGender(MovieGenderUpdateDto updateDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                Movies_Gender movieGender = this.moviesGenderRepository.GetEntity(updateDto.Cod_genero);
                movieGender.cod_pelicula = updateDto.Cod_pelicula;
                movieGender.cod_genero = updateDto.Cod_genero;
                
                this.moviesGenderRepository.Update(movieGender);
                result.Message = "El genero de la pelicula ha sido actualizado";
            }catch(Exception ex)
            {
                result.Message = "Error al actualizar el genero de una pelicula";
                result.Success = false;
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
    }
}
