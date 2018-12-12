using CompanyPatrimony.Domain.Core.Commands;
using CompanyPatrimony.Domain.Core.Contracts;
using CompanyPatrimony.Infra.Data.Context;

namespace CompanyPatrimony.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private CompanyPatrimonyContext _context;

        public UnitOfWork(CompanyPatrimonyContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            var rowsAfftected = _context.SaveChanges();
            return new CommandResponse(rowsAfftected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}