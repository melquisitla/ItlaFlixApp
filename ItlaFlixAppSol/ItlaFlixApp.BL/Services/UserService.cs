
using ItlaFlixApp.BL.Contract;
using ItlaFlixApp.BL.Core;
using ItlaFlixApp.BL.Dtos.User;
using ItlaFlixApp.BL.Models;
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
            throw new System.NotImplementedException();
        }

        public ServiceResult RemoveUser(UserRemoveDto removeDto)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult SaveUser(UserSaveDto saveDto)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult UpdateUser(UserUpdateDto updateDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
