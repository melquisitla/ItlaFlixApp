
using ItlaFlixApp.BL.Contract;
using ItlaFlixApp.BL.Core;
using ItlaFlixApp.BL.Dtos.User;
using ItlaFlixApp.BL.Models;
using ItlaFlixApp.DAL.Entities;
using ItlaFlixApp.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace ItlaFlixApp.BL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly ILogger<UserService> logger;

        public UserService(IUserRepository userRepository, ILogger<UserService> logger)
        { 
            this.userRepository = userRepository;
            this.logger = logger;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var users = this.userRepository.GetEntities().Select(cd => new UserResultModel ()
                {
                    cod_usuario = cd.cod_usuario,
                    txt_nombre= cd.txt_nombre,
                    txt_apellido= cd.txt_apellido,
                    txt_password = cd.txt_password,
                    txt_user = cd.txt_user,
                    nro_doc= cd.nro_doc,
                    cod_rol= cd.cod_rol, 
                    sn_activo= cd.sn_activo,

                }).ToList();
                result.Data = users;
                result.Success = true;
                result.Message = "Los usuarios han sido encontrados correctamente";

            }
            catch (Exception ex)
            {
                result.Message = "Ocurrio un error obteniendo los Usuarios";
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
                var user = this.userRepository.GetEntity(id);
                UserResultModel userResultModel = new UserResultModel()

                {
                    cod_usuario = user.cod_usuario,
                    txt_nombre = user.txt_nombre,
                    txt_apellido = user.txt_apellido,
                    txt_password = user.txt_password,
                    txt_user = user.txt_user,
                    nro_doc = user.nro_doc,
                    cod_rol = user.cod_rol,
                    sn_activo = user.sn_activo,

                };

                result.Data = userResultModel;
                result.Success = true;
                result.Message = "El usuario ha sido encontrado correctamente";
            }
            catch (Exception ex)
            {

                result.Message = "Ocurrio un error obteniendo el Usuario";
                result.Success = false;
                this.logger.LogError($" {result.Message} ", ex.ToString());
            }

            return result;
        }

        public ServiceResult RemoveUser(UserRemoveDto removeDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                User userToRemove = this.userRepository.GetEntity(removeDto.cod_usuario);
                this.userRepository.Remove(userToRemove);
                result.Success = true;
                result.Message = "El usuario ha sido eliminada correctamente";
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrio un error removiendo el usuario";
                result.Success = false;
                this.logger.LogError($" {result.Message} ", ex.ToString());
            }
            return result;
        }

        public ServiceResult SaveUser(UserSaveDto saveDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                User user = new User()
                {
                    txt_nombre = saveDto.txt_nombre,
                    txt_apellido = saveDto.txt_apellido,
                    txt_user = saveDto.txt_user,
                    txt_password = saveDto.txt_password,
                    nro_doc = saveDto.nro_doc,
                    cod_rol = saveDto.cod_rol,
                    sn_activo = saveDto.sn_activo,
                };

                this.userRepository.Save(user);
                result.Success = true;
                result.Message = "El usuario ha sido agregando correctamente";
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrio un error agregando el nuevo usuario";
                result.Success = false;
                this.logger.LogError($" {result.Message} ", ex.ToString());
            }
            return result;
        }

        public ServiceResult UpdateUser(UserUpdateDto updateDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                User user = this.userRepository.GetEntity(updateDto.cod_usuario);
                user.cod_usuario = updateDto.cod_usuario;
                user.txt_nombre = updateDto.txt_nombre;
                user.txt_apellido = updateDto.txt_apellido;
                user.txt_user = updateDto.txt_user;
                user.txt_password = updateDto.txt_password;
                user.nro_doc = updateDto.nro_doc;
                user.cod_rol = updateDto.cod_rol;
                user.sn_activo = updateDto.sn_activo;

                this.userRepository.Update(user);
                result.Success = true;
                result.Message = "El usuario ha sido actualizado correctamente";
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrio un error actualizando el usuario";
                result.Success = false;
                this.logger.LogError($" {result.Message} ", ex.ToString());
            }
            return result;
        }
    }
}
