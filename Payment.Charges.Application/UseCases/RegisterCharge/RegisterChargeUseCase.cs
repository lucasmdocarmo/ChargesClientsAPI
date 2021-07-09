using Newtonsoft.Json;
using Payment.Charges.Domain.Contracts;
using Payment.Charges.Domain.Entity;
using Payments.Charges.Application.UseCases.RegisterCharge.Boundaries;
using Payments.Charges.Application.UseCases.RegisterCharge.Ports;
using Payments.Charges.Domain.Contracts;
using Payments.Core.Shared.Contracts.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Charges.Application.UseCases.RegisterCharge
{
    public class RegisterChargeUseCase : IUseCase<RegisterChargeInput>
    {
        private readonly IChargesRepository _repository;
        private readonly IRegisterChargePort _port;
        private readonly IUnitOfWork _uow;
        private readonly IHttpClientFactory _client;
        public RegisterChargeUseCase(IChargesRepository repository, IRegisterChargePort port, IUnitOfWork uow, IHttpClientFactory client)
        {
            _repository = repository;
            _port = port;
            _uow = uow;
            _client = client;
        }

        public async ValueTask ExecuteTaskAsync(RegisterChargeInput input)
        {
            if (!input.IsValid)
            {
                _port.ValidationErrors(input.Notifications);
                return;
            }
            try
            {
                var chargeObject = new Charge(input.DueDate, input.Value, input.CPF);
                {
                    _repository.Add(chargeObject);
                    await _uow.Commit();
                    await ReplicateCharge(input).ConfigureAwait(true);
                }
                _port.Created();
            }
            catch (Exception ex)
            {
                _port.UnprocessableEntity(ex.Message);
            }
        }
        private async Task ReplicateCharge(RegisterChargeInput input)
        {
            var json = JsonConvert.SerializeObject(input);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var httpClient = _client.CreateClient();

            await httpClient.PostAsync("https://eventsapi:8090/api/Payment/Charge", data).ConfigureAwait(true);
        }
    }
}
