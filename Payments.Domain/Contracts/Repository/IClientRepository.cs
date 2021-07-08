using Payments.Clientes.Domain.Entities;
using Payments.Core.Shared.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Clientes.Domain.Contracts.Repository
{
    public interface IClientRepository : IRepository<Client>
    {
    }
}
