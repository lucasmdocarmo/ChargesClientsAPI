using Payments.Application.UseCases.DisplayClient.Boundaries;
using Payments.Core.Shared.Contracts.Application.Ports;
using Payments.Core.Shared.Contracts.Application.Ports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Application.UseCases.DisplayClient.Ports
{
    public interface IDisplayClientPort : ISucessPort<DisplayClientOutput>, IPreconditionPort, IUnprocessableEntityPort, INoContentPort, IBasePresenter
    {
    }
}
