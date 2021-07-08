using Flunt.Extensions.Br.Validations;
using Flunt.Notifications;
using Flunt.Validations;
using Payments.Clientes.Domain.Entities;
using Payments.Core.Shared.Contracts.Application.Interactors;
using Payments.Domain.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Clientes.Application.UseCases.CreateClient.Boundaries
{
    public class CreateClientInput : Notifiable<Notification>,IUseCaseInput
    {
        public CreateClientInput(string name, string cPF, string address)
        {
            Name = name;
            CPF = cPF;
            Address = address;
            AddNotifications(new ClientValidation(this));

        }

        [Required(AllowEmptyStrings =false, ErrorMessage = "Name is required.")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "CPF is required.")]
        [DisplayName("CPF")]
        public string CPF { get; set; }

        public string Address { get; set; }

    }
    internal class ClientValidation : Contract<CreateClientInput>
    {
        public ClientValidation(CreateClientInput client)
        {
            Requires()
                .IsNotNullOrWhiteSpace(client.Name, "Name", "Name is Required")
                .IsNotNullOrWhiteSpace(client.CPF, nameof(client.CPF), "CPF is Required")
                .IsCpf(client.CPF, "CPF", "CPF Invalid");

        }
    }

}
