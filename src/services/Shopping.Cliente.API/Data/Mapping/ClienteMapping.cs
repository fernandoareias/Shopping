using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping.Cliente.API.Models;

namespace Shopping.Cliente.API.Data.Mapping
{
    public class ClienteMapping : IEntityTypeConfiguration<Clientes>
    {
        public void Configure(EntityTypeBuilder<Clientes> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Excluido)
                .IsRequired();

            builder.Property(c => c.Nome)
                .IsRequired();

            builder.OwnsOne(c => c.Cpf)
                .Property(p => p.Numero)
                .IsRequired()
                .HasMaxLength(12);

            builder.OwnsOne(c => c.Email)
               .Property(p => p.Endereco)
               .IsRequired()
               .HasMaxLength(120);


            // 1 : 1 => Aluno : Endereco
            builder.HasOne(c => c.Endereco)
                .WithOne(c => c.Cliente);

        }
    }
}
