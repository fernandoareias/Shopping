using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping.Cliente.API.Models.VOs;

namespace Shopping.Cliente.API.Data.Mapping
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Logradouro)
                   .IsRequired();

            builder.Property(c => c.Numero)
                .IsRequired();

            builder.Property(c => c.Cep)
                .IsRequired();

            builder.Property(c => c.Complemento);

            builder.Property(c => c.Bairro)
                .IsRequired();

            builder.Property(c => c.Cidade)
                .IsRequired();

            builder.Property(c => c.Estado)
                .IsRequired();

            
        }
    }
}
