using Payments.Core.Shared.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Clientes.Domain.Entities
{
    public sealed class Address : BaseEntity
    {
        public Address() { }
        public Address(string cEP, string streetName, string number, string city, string state)
        {
            CEP = cEP;
            StreetName = streetName;
            Number = number;
            City = city;
            State = state;
        }

        public string CEP { get; private set; }
        public string StreetName { get; private set; }
        public string Number { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }

        public Client Client { get; private set; }
        public Guid ClientId { get; private set; }
    }
}
