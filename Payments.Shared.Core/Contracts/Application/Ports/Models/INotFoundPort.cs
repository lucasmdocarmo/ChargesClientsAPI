using Payments.Core.Shared.Contracts.Application.Interactors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Core.Shared.Contracts.Application.Ports.Models
{
    public interface INotFoundPort<in TUseCaseOutput> where TUseCaseOutput : IUseCaseOutput
    {
        void NotFound();
        void NotFound(IUseCaseOutput output, object message);
    }
}
