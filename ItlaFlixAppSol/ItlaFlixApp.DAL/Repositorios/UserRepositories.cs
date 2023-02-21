using System.Collections.Generic;
using System.Linq;
using ItlaFlixApp.DAL.Context;
using ItlaFlixApp.DAL.Entities;
using ItlaFlixApp.DAL.Exceptions;
using ItlaFlixApp.DAL.Interfaces;
using ItlaFlixApp.DAL.Models;
using System;
using Microsoft.Extensions.Logging;


namespace ItlaFlixApp.DAL.Repositorios
{
    public class UserRepositories : IUserRepository
    {
        private readonly ItlaContext _ItlaContext;
        private readonly ILogger<UserRepositories> _logger;
        
        public UserRepositories(ItlaContext ItlaContext, ILogger<UserRepositories> logger)
        {
            _ItlaContext = ItlaContext;
            _logger = logger;
        }

        public bool Exists(String Name)
        {
            return _ItlaContext.tUsers.Any(cd => cd.txt_nombre == Name);
        }

        public User Get(int cod_usuario)
        {
            return _ItlaContext.tUsers.Find(cod_usuario);
        }

        public List<UserModel> GetAll()
        {
            
            var users = _ItlaContext.tUsers.Select(cd => new UserModel()
            {  
                cod_usuario = cd.cod_usuario,
                txt_nombre = cd.txt_nombre,
                txt_apellido = cd.txt_apellido,
                txt_user = cd.txt_user,
                nro_doc = cd.nro_doc,
                cod_rol = cd.cod_rol,
                sn_activo = cd.sn_activo,

            }).ToList();

            return users;
        }

        public void Remove(User user)
        {
            try
            {
                User userToRemove = this.Get(user.cod_usuario);
                userToRemove.sn_activo = 0;

                _ItlaContext.tUsers.Remove(userToRemove);
                _ItlaContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error removiendo el usuario { ex.Message }", ex.ToString());
            }
        }

        public void Save(User user)
        {
            try
            {
                User userToAdd = new User()
                {
                    cod_usuario = user.cod_usuario,
                    txt_nombre = user.txt_nombre,
                    txt_apellido = user.txt_apellido,
                    txt_password = user.txt_password,
                    txt_user = user.txt_user,
                    nro_doc = user.nro_doc,
                    cod_rol = user.cod_rol,
                    sn_activo= user.sn_activo,
                };
                _ItlaContext.tUsers.Add(userToAdd);
                _ItlaContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error guardando el usuario {ex.Message}", ex.ToString());
            }
        }

        public void Update(User user)
        {
            try
            {
                User userToUpdate = this.Get(user.cod_usuario);
                userToUpdate.cod_usuario = user.cod_usuario;
                userToUpdate.cod_rol = user.cod_rol;
                userToUpdate.txt_nombre = user.txt_nombre;
                userToUpdate.txt_apellido = user.txt_apellido;
                userToUpdate.nro_doc = user.nro_doc;
                userToUpdate.txt_user = user.txt_user;
                userToUpdate.sn_activo = user.sn_activo;

                _ItlaContext.tUsers.Update(userToUpdate);
                _ItlaContext.SaveChanges();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error actualizando el usuario {ex.Message}", ex.ToString());
            }
        }
    }
}
