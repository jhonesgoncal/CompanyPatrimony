using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CompanyPatrimony.Domain.Core.Contracts;
using CompanyPatrimony.Domain.Core.Entities;
using CompanyPatrimony.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CompanyPatrimony.Infra.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity<TEntity>
    {
        protected CompanyPatrimonyContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository(CompanyPatrimonyContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public virtual TEntity GetById(Guid id)
        {
            return DbSet.AsNoTracking().FirstOrDefault(t => t.Id == id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}