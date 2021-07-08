using Payments.Events.Consumer.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Events.Consumer.Contracts
{
    public interface IServicesProducer
    {
        Task<bool> SendClientByKafka(ClientWrapper payload);
        Task<bool> SendChargeByKafka(ChargeWrapper payload);
    }
}
