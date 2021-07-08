using Payment.Charges.Domain.Contracts;
using Payments.Charges.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Charges.Domain.Contracts
{
    public interface IBillingRepository : IRepository<Billing>
    {
        ValueTask<bool> RecordReportBilling(Billing billing);
    }
}
