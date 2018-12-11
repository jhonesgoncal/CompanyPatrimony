using System;
using CompanyPatrimony.Domain.Core.Commands;

namespace CompanyPatrimony.Domain.Core.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}