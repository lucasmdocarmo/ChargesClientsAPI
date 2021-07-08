using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Domain.Contracts.Services
{
    public interface ICalculatorService
    {
        string CalculateCostBasedOnCPFValue(string cpf);
    }
}
