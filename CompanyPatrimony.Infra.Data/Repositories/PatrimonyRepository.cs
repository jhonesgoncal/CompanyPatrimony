using System;
using System.Collections.Generic;
using System.Linq;
using CompanyPatrimony.Domain.Contracts;
using CompanyPatrimony.Domain.Entities;
using CompanyPatrimony.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CompanyPatrimony.Infra.Data.Repositories
{
    public class PatrimonyRepository : Repository<Patrimony>, IPatrimonyRepository
    {
        public PatrimonyRepository(CompanyPatrimonyContext context) : base(context)
        {
        }


        public IEnumerable<Patrimony> GetAllByIdBrand(Guid id)
        {
            return DbSet.AsNoTracking().Where(x => x.BrandId == id).ToList();
        }
    }
}