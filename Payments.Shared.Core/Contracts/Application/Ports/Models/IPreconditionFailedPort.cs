using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Core.Shared.Contracts.Application.Ports.Models
{
    public interface IPreconditionPort
    {
        void ValidationErrors(IEnumerable<Notification> notifications);
        void ValidationError(string notification, string key);
    }
}
