using Flunt.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payment.Charges.Domain.Entity;
using Payments.Charges.Application.UseCases.DisplayCharge.Boundaries;
using Payments.Charges.Application.UseCases.DisplayCharge.Ports;
using Payments.Charges.Application.UseCases.RegisterCharge.Boundaries;
using Payments.Charges.Application.UseCases.RegisterCharge.Ports;
using Payments.Core.Shared.Contracts.Application;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Charges.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("V{api-version:apiVersion}/[controller]")]
    public class ChargesController : ControllerBase
    {

        private readonly IUseCase<DisplayChargeInput> _useCase;
        private readonly IDisplayChargePort _port;

        private readonly IRegisterChargePort _portRegister;
        private readonly IUseCase<RegisterChargeInput> _useCaseRegister;

        public ChargesController(IUseCase<DisplayChargeInput> useCase, IDisplayChargePort port, IRegisterChargePort portDisplay, IUseCase<RegisterChargeInput> useCaseDisplay)
        {
            _useCase = useCase;
            _port = port;
            _portRegister = portDisplay;
            _useCaseRegister = useCaseDisplay;
        }

        /// <summary>
        /// Create a New Charge
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Notification), StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> PostAsync([FromBody][Required] RegisterChargeInput input)
        {
            if (!ModelState.IsValid)
            {
                var notifications = new Collection<Notification>();
                foreach (var erro in ModelState.Where(a => a.Value.Errors.Count > 0).SelectMany(x => x.Value.Errors).ToList())
                {
                    notifications.Add(new Notification("invalidModel", erro.ErrorMessage));
                }
                _portRegister.ValidationErrors(notifications);

                return _portRegister.ViewModel();
            }
            await _useCaseRegister.ExecuteTaskAsync(input).ConfigureAwait(true);

            return _portRegister.ViewModel();
        }

        /// <summary>
        /// Get a charge
        /// </summary>
        ///   public string CPF { get; set; }

       // [DisplayName("Month")]
       // public string Month { get; set; }
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(DisplayChargeOutput), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Notification), StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> GetAsync(string CPF, int Month)
        {
            var _notifications = new Collection<Notification>();
            string validationMessage = string.Empty;

            if (string.IsNullOrEmpty(CPF) && Month >= 1 && Month <= 12)
            {
                validationMessage = "Please provide CPF or a valid Month.";
                _notifications.Add(new Notification("invalidModel", validationMessage));
                _port.ValidationErrors(_notifications);
                return _port.ViewModel();
            }


            await _useCase.ExecuteTaskAsync(new DisplayChargeInput(Month, CPF)).ConfigureAwait(true);

            return _port.ViewModel();
        }


    }
}
