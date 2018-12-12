using System.Collections.Generic;
using CompanyPatrimony.Domain.Core.Contracts;
using Flunt.Notifications;

namespace CompanyPatrimony.Service.Services
{
    public class BaseService
    {
        private readonly List<Notification> _notifications;
        private IReadOnlyCollection<Notification> Notifications => (IReadOnlyCollection<Notification>)this._notifications;

        public BaseService()
        {
            _notifications = new List<Notification>();
        }

        public IReadOnlyCollection<Notification> GetNotifications()
        {
            return Notifications;
        }

        protected void AddNotification(Notification notification)
        {
            this._notifications.Add(notification);
        }

        protected void AddNotifications(IReadOnlyCollection<Notification> notifications)
        {
            this._notifications.AddRange((IEnumerable<Notification>)notifications);
        }
    }
}