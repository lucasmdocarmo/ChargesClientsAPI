using Payment.Charges.Domain.Contracts;
using Payment.Charges.Domain.Entity;
using Payments.Charges.Application.UseCases.DisplayCharge.Boundaries;
using Payments.Charges.Application.UseCases.DisplayCharge.Ports;
using Payments.Core.Shared.Contracts.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Charges.Application.UseCases.DisplayCharge
{
    public class DisplayChargeUseCase : IUseCase<DisplayChargeInput>
    {
        private readonly IChargesRepository _repository;
        private readonly IDisplayChargePort _port;
        public DisplayChargeUseCase(IChargesRepository repository, IDisplayChargePort port)
        {
            _repository = repository;
            _port = port;
        }

        public async ValueTask ExecuteTaskAsync(DisplayChargeInput input)
        {
            if (!input.IsValid)
            {
                _port.ValidationErrors(input.Notifications);
                return;
            }
            try
            {
                var output = new DisplayChargeOutput();
                var queryResult = new Charge();
                if (!string.IsNullOrEmpty(input.CPF) && input.Month == 0)
                {
                    queryResult = await _repository.SearchCPF(input.CPF).ConfigureAwait(true);
                }
                else if (input.Month != 0 && string.IsNullOrEmpty(input.CPF))
                {
                    queryResult = await _repository.SearchbyMonth(input.Month).ConfigureAwait(true);
                }
                else
                {
                    queryResult = await _repository.SearchbyMonthAndCPF(input.Month, input.CPF).ConfigureAwait(true);
                }

                if(queryResult is null)
                {
                    _port.NoContent();
                }
                _port.Success(BuildOutputDisplayCharge(queryResult));
            }
            catch (Exception ex)
            {
                _port.UnprocessableEntity(ex.Message);
            }
        }
        public DisplayChargeOutput BuildOutputDisplayCharge(Charge chargeObject)
        {
            return  new DisplayChargeOutput()
            {
                CPF = chargeObject.CPF,
                DueDate = chargeObject.DueDate,
                RecordDate = chargeObject.RecordDate,
                Value = chargeObject.Value
            };
        }
    }
}
