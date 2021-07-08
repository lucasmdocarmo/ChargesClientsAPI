using Microsoft.AspNetCore.Mvc;
using Payments.Charges.Application.UseCases.RegisterCharge.Boundaries;
using Payments.Charges.Application.UseCases.RegisterCharge.Ports;
using Payments.Core.Shared.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Charges.Application.UseCases.RegisterCharge.Presenter
{
    public class RegisterChargePresenter : BasePresenter, IRegisterChargePort
    {
        public void Created(RegisterChargeOutput output)
        {
            base.ViewModelResult = new CreatedResult(string.Empty, output);
        }

        public void Created()
        {
            base.ViewModelResult = new CreatedResult(string.Empty, null);
        }
    }
}
