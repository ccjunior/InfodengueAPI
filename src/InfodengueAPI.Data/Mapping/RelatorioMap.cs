using InfodengueAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfodengueAPI.Data.Mapping
{
    public class RelatorioMap : IEntityTypeConfiguration<Relatorio>
    {
        public void Configure(EntityTypeBuilder<Relatorio> builder)
        {

            builder.HasKey(e => e.Id);
            builder.Property(e => e.DataSolicitacao).IsRequired();
            builder.Property(e => e.Arbovirose).IsRequired().HasMaxLength(50);
            builder.Property(e => e.SemanaInicio).IsRequired();
            builder.Property(e => e.SemanaFim).IsRequired();
            builder.Property(e => e.CodigoIBGE).IsRequired().HasMaxLength(7);
            builder.Property(e => e.Municipio).IsRequired().HasMaxLength(100);
            builder.Property(e => e.DadosConsulta).IsRequired();

            builder.HasOne(e => e.Solicitante)
                    .WithMany(s => s.Relatorios)
                    .HasForeignKey(e => e.SolicitanteId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
