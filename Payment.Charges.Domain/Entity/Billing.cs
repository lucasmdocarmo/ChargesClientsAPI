using Flunt.Notifications;
using Payments.Core.Shared.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Charges.Domain.Entity
{
    public class Billing : Notifiable<Notification>
    {
        public Billing(string cPF, decimal totalValue, decimal chargeValue, string name)
        {
            CPF = cPF;
            TotalValue = totalValue;
            ChargeValue = chargeValue;
            Name = name;
        }
        public Guid Id { get; private set; }
        public string CPF { get; set; }
        public decimal TotalValue { get; set; }
        public decimal ChargeValue { get; set; }
        public string Name { get; set; }
    }
}
