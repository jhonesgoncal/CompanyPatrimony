using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CompanyPatrimony.Domain.Core.Contracts;
using CompanyPatrimony.Domain.Entities;

namespace CompanyPatrimony.Domain.Contracts
{
    public interface IBrandRepository : IRepository<Brand>
    {
        IEnumerable<Brand> Find(Expression<Func<Brand, bool>> predicate);
    }
}