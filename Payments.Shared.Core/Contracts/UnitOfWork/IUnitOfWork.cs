using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Core.Shared.Contracts.UnitOfWork
{
    public interface IUnitOfWork
    {
        ValueTask<bool> Commit();
        void Rollback();
        void Begin();
        bool CheckIfDatabaseExists();
    }
}
