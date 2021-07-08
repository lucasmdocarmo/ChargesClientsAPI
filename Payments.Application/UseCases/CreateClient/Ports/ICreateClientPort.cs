using Payments.Clientes.Application.UseCases.CreateClient.Boundaries;
using Payments.Core.Shared.Contracts.Application.Ports;
using Payments.Core.Shared.Contracts.Application.Ports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Clientes.Application.UseCases.CreateClient.Ports
{
    public interface ICreateClientPort : ICreatedPort<CreateClientOutput>, IPreconditionPort, IUnprocessableEntityPort, IBasePresenter
    {
    }
}
