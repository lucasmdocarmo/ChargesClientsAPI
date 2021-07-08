using Payments.Core.Shared.Entity;
using Payments.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Clientes.Domain.Entities
{
    public sealed class Client : BaseEntity
    {
		public Client() { }
        public Client(string name, string cPF, string address)
        {
            Name = name;
            Address = address;
            CPF = FormatCpfToDesignedPattern(cPF);
            AddNotifications(new ClientValidation(this));

        }
        public string Address { get; private set; }
		public string Name { get; private set; }
        public string CPF { get; private set; }
        internal static string FormatCpfToDesignedPattern(string cpf)
        {
            return Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
        }
    }
  

}
