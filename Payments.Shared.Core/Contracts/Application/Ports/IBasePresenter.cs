using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Core.Shared.Contracts.Application.Ports
{
    public interface IBasePresenter
    {
        IActionResult ViewModelResult { get; set; }
        IActionResult ViewModel();
    }
}
