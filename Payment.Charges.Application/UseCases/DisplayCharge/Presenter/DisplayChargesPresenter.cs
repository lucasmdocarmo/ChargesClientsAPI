using Microsoft.AspNetCore.Mvc;
using Payments.Charges.Application.UseCases.DisplayCharge.Boundaries;
using Payments.Charges.Application.UseCases.DisplayCharge.Ports;
using Payments.Core.Shared.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Charges.Application.UseCases.DisplayCharge.Presenter
{
    public class DisplayChargesPresenter : BasePresenter, IDisplayChargePort
    {
        public void Success(DisplayChargeOutput output)
        {
            base.ViewModelResult = new OkObjectResult(output);
        }
    }
}
