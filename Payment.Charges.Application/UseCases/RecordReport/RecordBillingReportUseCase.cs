using Payments.Charges.Application.UseCases.RecordReport.Boundaries;
using Payments.Charges.Application.UseCases.RecordReport.Ports;
using Payments.Charges.Domain.Contracts;
using Payments.Core.Shared.Contracts.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Charges.Application.UseCases.RecordReport
{
    public class RecordBillingReportUseCase : IUseCase<BillingInput>
    {
        private readonly IBillingRepository _repo;
        private readonly IRecordReport _port;
        public RecordBillingReportUseCase(IBillingRepository repo, IRecordReport port)
        {
            _repo = repo;
            _port = port;
        }

        public async ValueTask ExecuteTaskAsync(BillingInput input)
        {
           
            if (!input.IsValid)
            {
                _port.ValidationErrors(input.Notifications);
                return;
            }
            try
            {
                await _repo.RecordReportBilling(new Domain.Entity.Billing(input.CPF, input.TotalValue, input.ChargeValue, input.Name)).ConfigureAwait(true);
                _port.NoContent();
            }
            catch (Exception ex)
            {
                _port.UnprocessableEntity(ex.Message);
            }
        }
    }
}
