using System;
using System.Collections.Generic;
using CompanyPatrimony.Service.ViewModels;
using Flunt.Notifications;

namespace CompanyPatrimony.Service.Contracts
{
    public interface IBrandService : IDisposable
    {
        Tuple<BrandViewModel, IReadOnlyCollection<Notification>> Add(BrandViewModel viewModel);
        Tuple<BrandViewModel, IReadOnlyCollection<Notification>> Update(BrandViewModel viewModel);
        IEnumerable<BrandViewModel> GetAll();
        BrandViewModel GetById(Guid id);
        IReadOnlyCollection<Notification> Remove(Guid id);
        IReadOnlyCollection<Notification> GetNotifications();
    }
}