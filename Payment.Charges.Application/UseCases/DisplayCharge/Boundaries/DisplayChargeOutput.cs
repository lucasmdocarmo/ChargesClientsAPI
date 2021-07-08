using Payments.Core.Shared.Contracts.Application.Interactors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Charges.Application.UseCases.DisplayCharge.Boundaries
{
    public class DisplayChargeOutput : IUseCaseOutput
    {
        public DateTime DueDate { get; set; }
        public DateTime RecordDate { get; set; }
        public decimal Value { get; set; }
        public string CPF { get;  set; }
    }
}
