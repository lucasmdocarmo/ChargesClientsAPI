using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payments.Clientes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Clientes.Infrastructure.Context
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(x => x.CEP).HasMaxLength(250).HasColumnType("varchar(250)").IsRequired();
            builder.Property(x => x.City).HasMaxLength(250).HasColumnType("varchar(250)").IsRequired();
            builder.Property(x => x.Number).HasMaxLength(250).HasColumnType("varchar(250)").IsRequired();
            builder.Property(x => x.State).HasMaxLength(250).HasColumnType("varchar(250)").IsRequired();
            builder.Property(x => x.StreetName).HasMaxLength(250).HasColumnType("varchar(250)").IsRequired();

            builder.ToTable("Address");
        }
    }
    public class ClientMapping : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(x => x.CPF).HasMaxLength(250).HasColumnType("varchar(250)").IsRequired();
            builder.Property(x => x.Name).HasMaxLength(250).HasColumnType("varchar(250)").IsRequired();
            builder.Property(x => x.Address).HasMaxLength(250).HasColumnType("varchar(250)").IsRequired();

            builder.ToTable("Client");
        }
    }
}
