using Flunt.Notifications;
using Payments.Core.Shared.Contracts.Application.Interactors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Application.UseCases.DisplayClient.Boundaries
{
    public class DisplayClientInput : Notifiable<Notification>, IUseCaseInput
    {
        public string CPF { get; set; }
    }
}
