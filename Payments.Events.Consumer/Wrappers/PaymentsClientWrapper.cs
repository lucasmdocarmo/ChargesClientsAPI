using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Events.Consumer.Wrappers
{
    public class PaymentsClientWrapper
    {

        public string CPF { get; set; }
        public decimal? TotalValue { get; set; }
        public decimal? ChargeValue { get; set; }
        public string Name { get; set; }
    }
}
