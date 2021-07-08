using Payments.Core.Shared.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Events.Consumer.Entity
{
    public class ChargesClient: BaseEntity
    {
        public ChargesClient(string cPF, string name, decimal? totalValue = null, decimal? chargeValue = null)
        {
            CPF = cPF;
            TotalValue = totalValue;
            ChargeValue = chargeValue;
            Name = name;
        }

        public string CPF { get; set; }
        public decimal? TotalValue { get; set; }
        public decimal? ChargeValue { get; set; }
        public string Name { get; set; }

       public void AddTotalCharge(string totalValue)
        {
            this.TotalValue = Convert.ToDecimal(totalValue);
        }
    }
}
