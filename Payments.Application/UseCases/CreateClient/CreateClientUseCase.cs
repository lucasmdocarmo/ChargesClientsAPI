using Payments.Clientes.Application.UseCases.CreateClient.Boundaries;
using Payments.Clientes.Application.UseCases.CreateClient.Ports;
using Payments.Clientes.Domain.Contracts.Repository;
using Payments.Clientes.Domain.Entities;
using Payments.Core.Shared.Contracts.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;

namespace Payments.Clientes.Application.UseCases.CreateClient
{
    public class CreateClientUseCase : IUseCase<CreateClientInput>
    {
        private readonly ICreateClientPort _port;
        private readonly IClientRepository _repository;
        private readonly IHttpClientFactory _client;
        public CreateClientUseCase(ICreateClientPort port, IClientRepository repository, IHttpClientFactory client)
        {
            _port = port;
            _repository = repository;
            _client = client;
        }

        public async ValueTask ExecuteTaskAsync(CreateClientInput input)
        {
            if (!input.IsValid)
            {
                _port.ValidationErrors(input.Notifications);
                return;
            }
            try
            {
                var _objClient = new Client(input.Name, input.CPF,input.Address);

                if (!await CheckExistingCPF(_objClient).ConfigureAwait(true))
                {
                    _port.UnprocessableEntity("Error when creating Client. CPF Already Exists!");
                    return;
                }

                await _repository.Add(_objClient);
                await _repository.SaveChanges();
                _port.Created();
            }
            catch (Exception ex)
            {
                _port.UnprocessableEntity(ex.Message);
            }
        }
        private async Task<bool> CheckExistingCPF(Client client)
        {
            var searchResultExistingCPF = await _repository.Search(x => x.CPF == client.CPF).ConfigureAwait(true);
            if (searchResultExistingCPF.Distinct().Any())
            {
                return false;
            }
            return true;
        }
        private async Task ReplicateClient(CreateClientInput input)
        {
            var json = JsonConvert.SerializeObject(input);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var httpClient = _client.CreateClient();

            await httpClient.PostAsync(" ", data).ConfigureAwait(true);
        }
    }
}
