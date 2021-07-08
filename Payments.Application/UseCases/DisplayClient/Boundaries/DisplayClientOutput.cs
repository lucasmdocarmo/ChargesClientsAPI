using Payments.Core.Shared.Contracts.Application.Interactors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Application.UseCases.DisplayClient.Boundaries
{
    public class DisplayClientOutput : IUseCaseOutput
    {
        public string Name { get; set; }
        public string CPF { get; set; }
    }
}
