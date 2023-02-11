using ItlaFlixApp.DAL.Context;
using ItlaFlixApp.DAL.Entities;
using ItlaFlixApp.DAL.Exceptions;
using ItlaFlixApp.DAL.Interfaces;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ItlaFlixApp.DAL.Repositorios
{
    public class UserRepositories : IUserRepository
    {
        private readonly ItlaContext context;
        private readonly ILogger<UserRepositories> logger;

        public UserRepositories(ItlaContext context, ILogger<UserRepositories> logger) 
        {
            this.context = context;
            this.logger = logger;
        }
        public void Add(User user)
        {
            try
            {

                if(this.context.Users.Any(cd => cd.cod_usuario == user.cod_usuario))
                    throw new UserException("El Usuario ya se encuentra regitrado");

                this.context.Users.Add(user);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                this.logger.LogError($"Ocurrio un error {ex.Message}", ex.ToString());
            }

        }

        public void Delete(User user)
        {
            throw new System.NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Update(User user)
        {
            throw new System.NotImplementedException();
        }

        public User UserGet(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
