using Payments.Core.Shared.Contracts.Application.Interactors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Core.Shared.Contracts.Application.Ports.Models
{
    public interface ICreatedPort<in TUseCaseOutput> where TUseCaseOutput : IUseCaseOutput?, new ()
    {
        void Created(TUseCaseOutput output);
        void Created();
    }
}
