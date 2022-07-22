using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Pedido.Infra.Data.Mappings
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido.Domain.Pedidos.Pedido>
    {
        public void Configure(EntityTypeBuilder<Domain.Pedidos.Pedido> builder)
        {
            builder.HasKey(c => c.Id);

            builder.OwnsOne(p => p.Endereco, e => 
            {
                e.Property(c => c.Logradouro)
                    .HasColumnType("varchar(200)");

                e.Property(c => c.Numero)
                    .HasColumnType("varchar(50)");

                e.Property(c => c.Cep)
                    .HasColumnType("varchar(20)");

                e.Property(c => c.Complemento)
                    .HasColumnType("varchar(250)");

                e.Property(c => c.Bairro)
                    .HasColumnType("varchar(100)");

                e.Property(c => c.Cidade)
                    .HasColumnType("varchar(100)");

                e.Property(c => c.Estado)
                    .HasColumnType("varchar(50)");
            });

            builder.Property(c => c.Codigo)
                .HasDefaultValueSql("NEXT VALUE FOR MinhaSequencia");


            builder.HasMany(c => c.PedidoItems)
                .WithOne(c => c.Pedido)
                .HasForeignKey(c => c.PedidoId);

            builder.ToTable("Pedidos");
        }
    }
}
