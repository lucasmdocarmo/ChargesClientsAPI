using Payments.Core.Shared.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Events.Consumer.Wrappers
{
    public class ChargeWrapper : BaseEntity
    {
        public DateTime DueDate { get; set; }
        public decimal Value { get; set; }
        public string CPF { get; set; }
    }
}
