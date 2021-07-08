using Confluent.Kafka;
using Newtonsoft.Json;
using Payments.Domain.Contracts.Services;
using Payments.Events.Consumer.Contracts;
using Payments.Events.Consumer.Contracts.Repository;
using Payments.Events.Consumer.Entity;
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
        private static PaymentsClientWrapper _wrapper;
        public ServiceProducers(IChargesClientesRepository repo, ICalculatorService calculator)
        {
            _repo = repo;
            _calculator = calculator;
            _wrapper = new PaymentsClientWrapper();
        }

        public async Task<bool> SendChargeByKafka(ChargeWrapper payload)
        {
            var chargesClient = new Entity.ChargesClient(payload.CPF, null, payload.Value);

            var totalCharge = _calculator.CalculateCostBasedOnCPFValue(chargesClient.CPF);
            chargesClient.AddTotalCharge(totalCharge);

            await _repo.Add(chargesClient);
            await  _repo.SaveChanges();
            await KafkaReplicationClient(chargesClient);

            return true;
        }

        public async Task<bool> SendClientByKafka(ClientWrapper payload)
        {
            var chargesClient = new Entity.ChargesClient(payload.CPF, payload.Name, null, null);

            var totalCharge = _calculator.CalculateCostBasedOnCPFValue(chargesClient.CPF);
            chargesClient.AddTotalCharge(totalCharge);

            await _repo.Add(chargesClient);
            await  _repo.SaveChanges();
            await KafkaReplicationClient(chargesClient);

            return true;

        }
        private async Task<bool> KafkaReplicationClient(ChargesClient payload)
        {
            var config = new ProducerConfig { BootstrapServers = "localhost:9092" };
            var message = JsonConvert.SerializeObject(payload);
            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                try
                {
                    producer.ProduceAsync("payments-topic", new Message<Null, string> { Value = message }).GetAwaiter().GetResult();
                    producer.Flush(TimeSpan.FromSeconds(5));

                    return await Task.FromResult(true);
                }
                catch (ProduceException<Null, string> e)
                {
                    Console.WriteLine($"Delivery failed: {e.Error.Reason}");
                }
            }

            return await Task.FromResult(false);
        }
    }
}
