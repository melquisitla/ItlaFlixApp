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
    public class UserRepositories : Core.ReposirotyBase<User>, IUserRepository
    {
        private readonly ItlaContext _Itlacontext;
        private readonly ILogger<UserRepositories> _logger;

        public UserRepositories(ItlaContext Itlacontext, ILogger<UserRepositories> logger) : base(Itlacontext)
        {
            this._Itlacontext = Itlacontext;
            this._logger = logger;
        }
        public void Add(User user)
        {
            try
            {

                //if (NewMethod(user))
                    throw new UserException("El Usuario ya se encuentra regitrado");

               // object value = this._Itlacontext.Users.Add(user);
               // this._Itlacontext.SaveChanges();
            }
            catch (Exception ex)
            {

                this._logger.LogError($"Ocurrio un error {ex.Message}", ex.ToString());
            }

        }

       // private bool NewMethod(User user) => this._Itlacontext.Users.Any(cd => cd.cod_usuario == user.cod_usuario);

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
