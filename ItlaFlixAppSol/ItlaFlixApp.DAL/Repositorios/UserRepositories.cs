using ItlaFlixApp.DAL.Context;
using ItlaFlixApp.DAL.Entities;
using ItlaFlixApp.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace ItlaFlixApp.DAL.Repositorios
{
    public class UserRepositories : Core.RepositoryBase<User>, IUserRepository
    {
        private readonly ItlaContext ItlaContext;
        private readonly ILogger<UserRepositories> logger;
        
        public UserRepositories(ItlaContext ItlaContext, ILogger<UserRepositories> logger): base(ItlaContext)
        {
            this.ItlaContext = ItlaContext;
            this.logger = logger;
        }
        //Para cambiar el comportamiento de una debemios hacer override aqui con loss cambios que necesitemos
        /*        public override List<User> GetEntities()
                {
                    var users= this._ItlaContext.tUsers.Where(usr => usr.sn_activo == -1).ToList();
                    return users;
                }*/
        public override void Save(User entity)
        {
            // x logica para verificar //
            base.Save(entity);
            base.SaveChanges();
        }

        public override void Update(User entity)
        {
            base.Update(entity);
            base.SaveChanges();
        }

        public override void Remove(User entity)
        {
            base.Remove(entity);
            base.SaveChanges();
        }
    }
}
