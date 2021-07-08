using Payments.Application.UseCases.DisplayClient.Boundaries;
using Payments.Application.UseCases.DisplayClient.Ports;
using Payments.Clientes.Domain.Contracts.Repository;
using Payments.Core.Shared.Contracts.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Application.UseCases.DisplayClient
{
    public class DisplayClientUseCase : IUseCase<DisplayClientInput>
    {
        private readonly IDisplayClientPort _port;
        private readonly IClientRepository _repository;

        public DisplayClientUseCase(IDisplayClientPort port, IClientRepository repository)
        {
            _port = port;
            _repository = repository;
        }

        public async ValueTask ExecuteTaskAsync(DisplayClientInput input)
        {
            if (!input.IsValid)
            {
                _port.ValidationErrors(input.Notifications);
                return;
            }
            try
            {
                var resultClientList = await _repository.Search(x=>x.CPF == input.CPF).ConfigureAwait(true);
                if (resultClientList != null)
                {
                    var objectClient = resultClientList.FirstOrDefault();
                    var output = new DisplayClientOutput()
                    {
                        CPF = objectClient.CPF,
                        Name = objectClient.Name
                    };

                    _port.Success(output);
                }
                else
                {
                    _port.NoContent();
                }
            }
            catch (Exception ex)
            {
                _port.UnprocessableEntity(ex.Message);
            }
        }
    }
}
