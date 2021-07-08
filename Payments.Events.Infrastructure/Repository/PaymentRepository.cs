using Microsoft.EntityFrameworkCore;
using Payments.Core.Shared.Repository.Base;
using Payments.Events.Consumer.Contracts.Repository;
using Payments.Events.Consumer.Entity;
using Payments.Events.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Events.Infrastructure.Repository
{
    public class PaymentRepository : BaseRepository<ChargesClient>, IChargesClientesRepository
    {
        public PaymentRepository(PaymentsContext db) : base(db) { }
    }
}
