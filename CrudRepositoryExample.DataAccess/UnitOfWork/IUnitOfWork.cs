using System;
using CrudRepositoryExample.DataAccess.Repository;

namespace CrudRepositoryExample.DataAccess.UnitOfWork
{
   public  interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;
        int SaveChanges();
    }
}
