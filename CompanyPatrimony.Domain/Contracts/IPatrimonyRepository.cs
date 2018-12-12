using System;
using System.Collections.Generic;
using CompanyPatrimony.Domain.Core.Contracts;
using CompanyPatrimony.Domain.Entities;

namespace CompanyPatrimony.Domain.Contracts
{
    public interface IPatrimonyRepository : IRepository<Patrimony>
    {
        IEnumerable<Patrimony> GetAllByIdBrand(Guid id);
    }
}