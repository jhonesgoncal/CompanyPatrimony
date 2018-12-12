using System;
using System.Collections.Generic;
using CompanyPatrimony.Domain.Core.Entities;

namespace CompanyPatrimony.Domain.Core.Contracts
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity<TEntity>
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(Guid id);
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        int SaveChanges();
    }
}