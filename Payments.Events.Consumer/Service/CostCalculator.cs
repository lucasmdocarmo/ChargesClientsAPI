using Payments.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Domain.Services
{
    public class CostCalculator : ICalculatorService
    {
        public string CalculateCostBasedOnCPFValue(string cpf)
        {
            string _firstTwoElementsCPF = cpf.Substring(0, 2);
            string _lastTwoElementsCPF = cpf[^2..];

            var decimalValue = Convert.ToDecimal(_firstTwoElementsCPF + _lastTwoElementsCPF);

            return decimalValue.ToString("C", CultureInfo.CurrentCulture);
        }
    }
}
