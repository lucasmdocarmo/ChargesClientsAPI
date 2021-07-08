using Flunt.Extensions.Br.Validations;
using Flunt.Notifications;
using Flunt.Validations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Payments.Core.Shared.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Charges.Domain.Entity
{
    public sealed class Charge : Notifiable<Notification>//:BaseEntity
    {
        public Charge()
        {

        }
        public Charge(DateTime dueDate, decimal value, string cPF)
        {
            DueDate = dueDate;
            RecordDate = DateTime.Now;
            Value = value;
            CPF = FormatCpfToDesignedPattern(cPF);
            this.Id = Guid.NewGuid();
            AddNotifications(new ChargeValidation(this));
        }
        public Guid Id { get; private set; }
        [BsonElement("DueDate")]
        public DateTime DueDate { get; private set; }
        [BsonElement("RecordDate")]
        public DateTime RecordDate { get; private set; }
        [BsonElement("Value")]
        public decimal Value { get; private set; }
        [BsonElement("CPF")]
        public string CPF { get; private set; }

        internal static string FormatCpfToDesignedPattern(string cpf)
        {
            return Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
        }
    }
   
    internal class ChargeValidation : Contract<Charge>
    {
        public ChargeValidation(Charge client)
        {
            Requires()
                .IsNotNull(client.DueDate, "DueDate", "DueDate is Required")
                .IsNotNull(client.RecordDate, "RecordDate", "Record Date is Required")
                .IsNotNull(client.Value, "Value", "Value is Required")
                .IsNotNullOrWhiteSpace(client.CPF, nameof(client.CPF), "CPF is Required")
                .IsCpf(client.CPF, "CPF", "CPF Invalid");
        }
    }
}
