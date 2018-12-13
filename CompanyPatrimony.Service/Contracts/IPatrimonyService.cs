using System;
using System.Collections.Generic;
using CompanyPatrimony.Service.ViewModels;
using Flunt.Notifications;

namespace CompanyPatrimony.Service.Contracts
{
    public interface IPatrimonyService : IDisposable
    {
        Tuple<PatrimonyViewModel, IReadOnlyCollection<Notification>> Add(PatrimonyViewModel viewModel);
        Tuple<PatrimonyViewModel, IReadOnlyCollection<Notification>> Update(PatrimonyViewModel viewModel);
        IEnumerable<PatrimonyViewModel> GetAll();
        IEnumerable<PatrimonyViewModel> GetAllByIdBrand(Guid id);
        PatrimonyViewModel GetById(Guid id);
        IReadOnlyCollection<Notification> Remove(Guid id);
        IReadOnlyCollection<Notification> GetNotifications();
    }
}