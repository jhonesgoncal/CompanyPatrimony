using System;
using System.Collections.Generic;
using CompanyPatrimony.Service.ViewModels;
using Flunt.Notifications;

namespace CompanyPatrimony.Service.Contracts
{
    public interface IBrandService : IDisposable
    {
        BrandViewModel Add(BrandViewModel viewModel);
        BrandViewModel Update(BrandViewModel viewModel);
        IEnumerable<BrandViewModel> GetAll();
        BrandViewModel GetById(Guid id);
        void Remove(Guid id);
        IReadOnlyCollection<Notification> GetNotifications();
    }
}