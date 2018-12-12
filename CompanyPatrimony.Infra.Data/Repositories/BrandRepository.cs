using CompanyPatrimony.Domain.Contracts;
using CompanyPatrimony.Domain.Entities;
using CompanyPatrimony.Infra.Data.Context;

namespace CompanyPatrimony.Infra.Data.Repositories
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public BrandRepository(CompanyPatrimonyContext context) : base(context)
        {
        }
    }
}