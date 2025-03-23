using InfodengueAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfodengueAPI.Data.Mapping
{
    public class SolicitanteMap : IEntityTypeConfiguration<Solicitante>
    {
        public void Configure(EntityTypeBuilder<Solicitante> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Nome).IsRequired().HasMaxLength(100);
            builder.Property(e => e.CPF).IsRequired().HasMaxLength(11);

            // Garantir que o CPF seja único
            builder.HasIndex(e => e.CPF).IsUnique();
        }
    }
}
