using Microsoft.AspNetCore.Mvc;
using Payments.Application.UseCases.DisplayClient.Boundaries;
using Payments.Application.UseCases.DisplayClient.Ports;
using Payments.Core.Shared.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Application.UseCases.DisplayClient.Presenter
{
    public class DisplayClientPresenter : BasePresenter, IDisplayClientPort
    {
        public void Success(DisplayClientOutput output)
        {
            base.ViewModelResult = new OkObjectResult(output);
        }
    }
}
