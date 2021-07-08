using Payments.Core.Shared.Repository;
using Payments.Events.Consumer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Events.Consumer.Contracts.Repository
{
    public interface IChargesClientesRepository : IRepository<ChargesClient>
    {
    }
}