using Flunt.Notifications;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Core.Shared.Entity
{
    public abstract class BaseEntity : Notifiable<Notification>
    {
        public Guid Id { get; private set; }
        public DateTime LastUpdated { get; private set; }
        public BaseEntity()
        {
            Id = Guid.NewGuid();
            LastUpdated = DateTime.Now;
        }
    }
}
