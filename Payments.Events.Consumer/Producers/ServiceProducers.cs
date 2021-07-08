using Payments.Domain.Contracts.Services;
using Payments.Events.Consumer.Contracts;
using Payments.Events.Consumer.Contracts.Repository;
using Payments.Events.Consumer.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Events.Consumer.Producers
{
    public class ServiceProducers : IServicesProducer
    {
        private readonly IChargesClientesRepository _repo;
        private readonly ICalculatorService _calculator;

        public ServiceProducers(IChargesClientesRepository repo, ICalculatorService calculator)
        {
            _repo = repo;
            _calculator = calculator;
        }

        public Task<bool> SendChargeByKafka(ChargeWrapper payload)
        {
            var chargesClient = new Entity.ChargesClient(payload.CPF, null, payload.Value);

            var totalCharge = _calculator.CalculateCostBasedOnCPFValue(chargesClient.CPF);
            chargesClient.AddTotalCharge(totalCharge);

            _repo.Add(chargesClient);
            return _repo.SaveChanges();
        }

        public Task<bool> SendClientByKafka(ClientWrapper payload)
        {
            var chargesClient = new Entity.ChargesClient(payload.CPF, payload.Name, null, null);

            var totalCharge = _calculator.CalculateCostBasedOnCPFValue(chargesClient.CPF);
            chargesClient.AddTotalCharge(totalCharge);

            _repo.Add(chargesClient);
            return _repo.SaveChanges();

        }
    }
}
