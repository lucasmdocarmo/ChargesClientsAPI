using Payments.Core.Shared.Contracts.Application.Interactors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Clientes.Application.UseCases.CreateClient.Boundaries
{
    public class CreateClientOutput : IUseCaseOutput
    {
        public string Name { get;  set; }
    }
}
