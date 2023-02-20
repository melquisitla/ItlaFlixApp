using ItlaFlixApp.DAL.Context;
using ItlaFlixApp.DAL.Entities;
using ItlaFlixApp.DAL.Exceptions;
using ItlaFlixApp.DAL.Interfaces;
using ItlaFlixApp.DAL.Models;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ItlaFlixApp.DAL.Repositorios
{
    public class UserRepositories : IUserRepository
    {
        /*        private readonly ItlaContext context;
                private readonly ILogger<UserRepositories> logger;

                public UserRepositories(ItlaContext context, ILogger<UserRepositories> logger)
                {
                    this.context = context;
                    this.logger = logger;
                }*/
        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int Name)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserModel> GetAll()
        {
            return new List<UserModel>
            {
                new UserModel(){id=1, Nombre="Wesley",Apellido="Novas", Usuario = "wnovas69", Cedula="001-1234648-2",Rol="Usuario", Activo = true},
                new UserModel(){id=2, Nombre="Wagner",Apellido="Jafet", Usuario = "wagner25", Cedula="001-1234649-2",Rol="Usuario" , Activo = true},
                new UserModel(){id=3, Nombre="Melquis",Apellido="Mateo", Usuario = "mmateo01", Cedula="001-1164428-2",Rol="Usuario" , Activo = true},
            };
        }

        public void Remove(User user)
        {
            throw new NotImplementedException();
        }

        public void Save(User user)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
