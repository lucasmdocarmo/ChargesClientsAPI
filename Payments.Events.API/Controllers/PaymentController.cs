using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payments.Events.Consumer.Contracts;
using Payments.Events.Consumer.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Events.API.Controllers
{

    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("V{api-version:apiVersion}/[controller]")]
    public class PaymentController : ControllerBase
    {
        public readonly IServicesProducer _producer;

        public PaymentController(IServicesProducer producer)
        {
            _producer = producer;
        }

        [HttpPost("Charge")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(422)]
        public async Task<IActionResult> PostCharge([FromBody] ChargeWrapper payload)
        {
            var result = await _producer.SendChargeByKafka(payload).ConfigureAwait(true);
            if (!result) { return UnprocessableEntity("Error when replicating."); }

            return Created("Charge Created", payload);
        }
        [HttpPost("Client")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(422)]
        public async Task<IActionResult> PostClient([FromBody] ClientWrapper payload)
        {
            var result = await _producer.SendClientByKafka(payload).ConfigureAwait(true);
            if (!result) { return UnprocessableEntity("Error when replicating."); }

            return Created("Client Created", payload);
        }
    }
}
