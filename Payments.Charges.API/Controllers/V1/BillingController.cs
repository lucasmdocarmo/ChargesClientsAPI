using Flunt.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payments.Charges.Application.UseCases.RecordReport.Boundaries;
using Payments.Charges.Application.UseCases.RecordReport.Ports;
using Payments.Core.Shared.Contracts.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Charges.API.Controllers.V1
{

    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("V{api-version:apiVersion}/[controller]")]
    public class BillingController : ControllerBase
    {
        private readonly IUseCase<BillingInput> _useCase;
        private readonly IRecordReport _port;

        public BillingController(IUseCase<BillingInput> useCase, IRecordReport port)
        {
            _useCase = useCase;
            _port = port;
        }

        /// <summary>
        /// Record Report
        /// </summary>
        /// <returns></returns>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Notification), StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> PostAsync(BillingInput input)
        {

            await _useCase.ExecuteTaskAsync(input).ConfigureAwait(true);

            return _port.ViewModel();
        }
    }
}
