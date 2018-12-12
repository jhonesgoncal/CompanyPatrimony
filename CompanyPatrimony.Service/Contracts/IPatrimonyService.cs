using System;
using System.Collections.Generic;
using CompanyPatrimony.Service.ViewModels;
using Flunt.Notifications;

namespace CompanyPatrimony.Service.Contracts
{
    public interface IPatrimonyService : IDisposable
    {
        PatrimonyViewModel Add(PatrimonyViewModel viewModel);
        PatrimonyViewModel Update(PatrimonyViewModel viewModel);
        IEnumerable<PatrimonyViewModel> GetAll();
        IEnumerable<PatrimonyViewModel> GetAllByIdBrand(Guid id);
        PatrimonyViewModel GetById(Guid id);
        void Remove(Guid id);
        IReadOnlyCollection<Notification> GetNotifications();
    }
}