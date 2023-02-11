using ItlaFlixApp.DAL.Context;
using ItlaFlixApp.DAL.Core;
using Microsoft.EntityFrameworkCore;
using System;

namespace ItlaFlixApp.DAL.DbFactory
{
    public class DBFactory : IDbFactory, IDisposable
    {
        private readonly ItlaContext itlaContext;

        public DBFactory(ItlaContext itlaContext) => this.itlaContext = itlaContext;

        private bool isDisposed = false;

        public DbContext GetDbContext => this.itlaContext; 
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!this.isDisposed)
            {
                if (this.itlaContext != null)
                {
                    this.itlaContext.Dispose();
                }
            }
            this.isDisposed = true;
        } 
    }
}
