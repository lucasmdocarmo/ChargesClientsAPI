using Flunt.Notifications;
using Payments.Core.Shared.Contracts.Application.Interactors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Charges.Application.UseCases.RecordReport.Boundaries
{
    public class BillingInput : Notifiable<Notification>, IUseCaseInput
    {
        public string CPF { get; set; }
        public decimal TotalValue { get; set; }
        public decimal ChargeValue { get; set; }
        public string Name { get; set; }
    }
}
