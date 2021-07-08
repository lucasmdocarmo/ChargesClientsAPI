using Flunt.Extensions.Br.Validations;
using Flunt.Notifications;
using Flunt.Validations;
using Payments.Clientes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Domain.Validators
{
    public class ClientValidation : Contract<Client>
    {
        public ClientValidation(Client client)
        {
            Requires()
                .IsNotNullOrWhiteSpace(client.Name, "Name", "Name is Required")
                .IsNotNullOrWhiteSpace(client.CPF, nameof(client.CPF), "CPF is Required")
                .IsCpf(client.CPF, "CPF", "CPF Invalid");

        }
    }
  
 }
