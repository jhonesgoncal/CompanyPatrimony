using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CompanyPatrimony.Domain.Contracts;
using CompanyPatrimony.Domain.Entities;
using CompanyPatrimony.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CompanyPatrimony.Infra.Data.Repositories
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public BrandRepository(CompanyPatrimonyContext context) : base(context)
        {
        }

        public IEnumerable<Brand> Find(Expression<Func<Brand, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate);
        }
    }
}