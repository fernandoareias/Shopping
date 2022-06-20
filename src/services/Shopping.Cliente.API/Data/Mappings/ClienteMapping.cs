using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping.Core.DomainObjects.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Cliente.API.Data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Shopping.Cliente.API.Models.Cliente>
    {
        public void Configure(EntityTypeBuilder<Models.Cliente> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.OwnsOne(navigationExpression: c => c.Cpf, buildAction: tf => 
            {
                tf.Property(c => c.Numero)
                    .IsRequired()
                    .HasMaxLength(11)
                    .HasColumnName("CPF")
                    .HasColumnType($"varchar({Cpf.CpfMaxLength})");
            });

            builder.OwnsOne(navigationExpression: c => c.Email, buildAction: tf => 
            {
                tf.Property(c => c.Endereco)
                    .IsRequired()
                    .HasColumnName("Email")
                    .HasColumnType($"varchar({Email.EnderecoMaxLength})");
            });

            builder.HasOne(navigationExpression: c => c.Endereco)
                .WithOne(navigationExpression: c => c.Cliente);

            builder.ToTable("Clientes");
        }
    }
}
