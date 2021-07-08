using Payments.Clientes.Domain.Contracts.Repository;
using Payments.Clientes.Domain.Entities;
using Payments.Clientes.Infrastructure.Context;
using Payments.Core.Shared.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Clientes.Infrastructure.Repository
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(ClientsContext db) : base(db) { }
    }
}
