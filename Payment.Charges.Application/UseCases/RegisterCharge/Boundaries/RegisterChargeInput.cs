using Flunt.Extensions.Br.Validations;
using Flunt.Notifications;
using Flunt.Validations;
using Payments.Core.Shared.Contracts.Application.Interactors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Charges.Application.UseCases.RegisterCharge.Boundaries
{
    public class RegisterChargeInput : Notifiable<Notification>, IUseCaseInput
    {
        public RegisterChargeInput(DateTime dueDate,  decimal value, string cPF)
        {
            DueDate = dueDate;
            Value = value;
            CPF = cPF;
            AddNotifications(new RegisterChargeInputValidation(this));
        }

        public DateTime DueDate { get;  set; }
        public decimal Value { get;  set; }
        public string CPF { get;  set; }
    }
    internal class RegisterChargeInputValidation : Contract<RegisterChargeInput>
    {
        public RegisterChargeInputValidation(RegisterChargeInput client)
        {
            Requires()
                .IsNotNull(client.DueDate, "DueDate", "Due Date is Required")
                .IsNotNull(client.Value, "Value", "Value is Required")
                .IsNotNullOrWhiteSpace(client.CPF, nameof(client.CPF), "CPF is Required")
                .IsCpf(client.CPF, "CPF", "CPF Invalid");

        }
    }
}
