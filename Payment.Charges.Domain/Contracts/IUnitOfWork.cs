using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Charges.Domain.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}
