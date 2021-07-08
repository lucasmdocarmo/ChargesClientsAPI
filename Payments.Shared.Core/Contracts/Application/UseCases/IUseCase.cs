using Payments.Core.Shared.Contracts.Application.Interactors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Core.Shared.Contracts.Application
{
    public interface IUseCase<TUseCaseInput> where TUseCaseInput : IUseCaseInput
    {
        ValueTask ExecuteTaskAsync(TUseCaseInput input);
    }

}
