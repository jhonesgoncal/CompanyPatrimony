using System;
using Flunt.Notifications;

namespace CompanyPatrimony.Domain.Core.Entities
{
    public abstract class Entity<T> : Notifiable
    {
        protected Entity() => Id = Guid.NewGuid();
        public Guid Id { get; private set; }
    }
}