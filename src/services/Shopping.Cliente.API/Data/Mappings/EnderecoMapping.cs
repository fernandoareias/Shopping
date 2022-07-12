using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping.Cliente.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Cliente.API.Data.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(keyExpression: c => c.Id);
            builder.Ignore(c => c.Notificacoes);
            builder.Property(c => c.Logradouro)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Numero)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Cep)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(c => c.Complemento)
                .HasColumnType("varchar(250)");

            builder.Property(c => c.Bairro)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Cidade)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Estado)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.ToTable("Enderecos");
        }
    }
}
