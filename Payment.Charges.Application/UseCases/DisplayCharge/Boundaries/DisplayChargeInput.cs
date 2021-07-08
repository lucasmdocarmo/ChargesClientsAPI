using Flunt.Extensions.Br.Validations;
using Flunt.Notifications;
using Flunt.Validations;
using Payments.Core.Shared.Contracts.Application.Interactors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Charges.Application.UseCases.DisplayCharge.Boundaries
{
    public class DisplayChargeInput : Notifiable<Notification>, IUseCaseInput
    {
        public DisplayChargeInput(int month, string cPF)
        {
            Month = month;
            CPF = cPF;
            AddNotifications(new DisplayChargeInputValidation(this));
        }
       
        [DisplayName("CPF")]
        public string CPF { get; set; }

        [DisplayName("Month")]
        public int Month { get; set; }
    }
    internal class DisplayChargeInputValidation : Contract<DisplayChargeInput>
    {
        public DisplayChargeInputValidation(DisplayChargeInput client)
        {
            Requires()
                .IsNotNull(client.Month, "Month", "Month is Required")
                .IsNotNullOrWhiteSpace(client.CPF, nameof(client.CPF), "CPF is Required")
                .IsNotEmpty(client.CPF, "CPF", "CPF is Null")
                .IsCpf(client.CPF, "CPF", "CPF Invalid");
        }
    }
}
