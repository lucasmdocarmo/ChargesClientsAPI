using Payments.Charges.Application.UseCases.RegisterCharge.Boundaries;
using Payments.Core.Shared.Contracts.Application.Ports;
using Payments.Core.Shared.Contracts.Application.Ports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Charges.Application.UseCases.RegisterCharge.Ports
{
    public interface IRegisterChargePort : ICreatedPort<RegisterChargeOutput>, IPreconditionPort, IUnprocessableEntityPort, IBasePresenter
    {
    }
}
