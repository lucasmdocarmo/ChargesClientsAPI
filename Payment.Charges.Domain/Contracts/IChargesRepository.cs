using Payment.Charges.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Charges.Domain.Contracts
{
    public interface IChargesRepository : IRepository<Charge>
    {
        ValueTask<Charge> SearchbyMonthAndCPF(int month, string cpf);
        ValueTask<Charge> SearchbyMonth(int month);
        ValueTask<Charge> SearchCPF(string cpf);
    }
}
