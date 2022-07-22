using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping.Pedido.Domain.Pedidos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Pedido.Infra.Data.Mappings
{
    public class PedidoItemMapping : IEntityTypeConfiguration<Pedido.Domain.Pedidos.PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.ProdutoNome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.HasOne(c => c.Pedido)
                .WithMany(c => c.PedidoItems);

            builder.ToTable("PedidoItems");
        }
    }
}
