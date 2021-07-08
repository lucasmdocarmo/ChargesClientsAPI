using Payment.Charges.Domain.Contracts.Mongo;
using Payments.Charges.Domain.Contracts;
using Payments.Charges.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Charges.Infrastructure.Repository
{
    public class BillingRepository : Repository<Billing>, IBillingRepository
    {
        public BillingRepository(IMongoContext context) : base(context)
        {
        }

        public async ValueTask<bool> RecordReportBilling(Billing billing)
        {
            base.Add(billing);
            await base.Context.SaveChanges();
            return true;
        }
    }
}
