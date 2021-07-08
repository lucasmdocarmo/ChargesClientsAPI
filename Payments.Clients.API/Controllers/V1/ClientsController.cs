using Flunt.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payments.Application.UseCases.DisplayClient.Boundaries;
using Payments.Application.UseCases.DisplayClient.Ports;
using Payments.Clientes.Application.UseCases.CreateClient.Boundaries;
using Payments.Clientes.Application.UseCases.CreateClient.Ports;
using Payments.Core.Shared.Contracts.Application;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Clients.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("V{api-version:apiVersion}/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IUseCase<CreateClientInput> _useCase;
        private readonly ICreateClientPort _port;

        private readonly IDisplayClientPort _portDisplay;
        private readonly IUseCase<DisplayClientInput> _useCaseDisplay;
        public ClientsController(IUseCase<CreateClientInput> useCase, ICreateClientPort port, IDisplayClientPort portDisplay, 
            IUseCase<DisplayClientInput> useCaseDisplay)
        {
            _useCase = useCase;
            _port = port;
            _portDisplay = portDisplay;
            _useCaseDisplay = useCaseDisplay;
        }

        /// <summary>
        /// Create a New Client
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(CreateClientOutput),StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Notification), StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> PostAsync([FromBody] CreateClientInput input)
        {
            if (!ModelState.IsValid)
            {
                var notifications = new Collection<Notification>();
                foreach (var erro in ModelState.Where(a => a.Value.Errors.Count > 0).SelectMany(x => x.Value.Errors).ToList())
                {
                    notifications.Add(new Notification("invalidModel", erro.ErrorMessage));
                }
                _port.ValidationErrors(notifications);

                return _port.ViewModel();
            }

            await _useCase.ExecuteTaskAsync(input).ConfigureAwait(true);

            return _port.ViewModel();
        }
        /// <summary>
        /// Display a New Client
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("{cpf}")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(DisplayClientOutput), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Notification), StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> GetAsync([Required][Bind] string cpf)
        {
            if (!ModelState.IsValid)
            {
                var notifications = new Collection<Notification>();
                foreach (var erro in ModelState.Where(a => a.Value.Errors.Count > 0).SelectMany(x => x.Value.Errors).ToList())
                {
                    notifications.Add(new Notification("invalidModel", erro.ErrorMessage));
                }
                _portDisplay.ValidationErrors(notifications);

                return _portDisplay.ViewModel();
            }

            await _useCaseDisplay.ExecuteTaskAsync(new DisplayClientInput() { CPF = cpf}).ConfigureAwait(true);

            return _portDisplay.ViewModel();
        }
    }
}
