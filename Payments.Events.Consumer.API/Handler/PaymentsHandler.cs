using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Payments.Domain.Contracts.Services;
using Payments.Events.Consumer.Contracts.Repository;
using Payments.Events.Consumer.Entity;
using Payments.Events.Consumer.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Payments.Events.Consumer.API.Service
{
    public class PaymentsHandler : IHostedService
    {
        private readonly IHttpClientFactory _client;
        private readonly ICalculatorService _calculator;
        public PaymentsHandler(IHttpClientFactory client, ICalculatorService calculator)
        {
            _client = client;
            _calculator = calculator;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var config = new ConsumerConfig
            {
                GroupId = "payments-topic-consumer",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest,
            };

            while (!cancellationToken.IsCancellationRequested)
            {
                using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
                consumer.Subscribe("payments-topic");
                var cts = new CancellationTokenSource();

                try
                {
                    while (true)
                    {
                        var message = consumer.Consume(cts.Token);
                        await RecordChargeClientReport(message.Value).ConfigureAwait(true);
                    }
                }
                catch (OperationCanceledException)
                {
                    consumer.Close();
                }
            }
        }
        private async Task<bool> RecordChargeClientReport(string payload)
        {
            try
            {
                var data = new StringContent(payload, Encoding.UTF8, "application/json");
                var httpClient = _client.CreateClient();

                await httpClient.PostAsync("https://localhost:61653/api/Billing", data).ConfigureAwait(true);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
