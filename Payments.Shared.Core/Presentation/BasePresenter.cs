using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;
using Payments.Core.Shared.Contracts.Application.Ports;
using Payments.Core.Shared.Contracts.Application.Ports.Models;
using Payments.Core.Shared.Presentation.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Core.Shared.Presentation
{
    public class BasePresenter : IBasePresenter, IUnprocessableEntityPort, INoContentPort, IPreconditionPort
    {
        public IActionResult ViewModelResult { get; set; }

        public void NoContent()
        {
            ViewModelResult = new NoContentResult();
        }

        public void UnprocessableEntity(string errorMessage)
        {
            ViewModelResult = new UnprocessableEntityObjectResult(errorMessage);
        }
        public void ValidationError(string notification, string key)
        {
            ViewModelResult = new PreconditionFailedModelError(new Notification(key, notification));
        }

        public void ValidationErrors(IEnumerable<Notification> notifications)
        {
            ViewModelResult = new PreconditionFailedModelError(notifications);
        }

        public IActionResult ViewModel()
        {
            return this.ViewModelResult;
        }
    }
}
