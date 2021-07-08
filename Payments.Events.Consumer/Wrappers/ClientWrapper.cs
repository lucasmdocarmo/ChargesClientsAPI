using Payments.Core.Shared.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Events.Consumer.Wrappers
{
    public class ClientWrapper:BaseEntity
    {
        public string Address { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
    }
}
