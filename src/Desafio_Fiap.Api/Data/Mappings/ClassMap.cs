using Desafio_Fiap.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio_Fiap.Api.Data.Mappings;

public class ClassMap : IEntityTypeConfiguration<Class>
{
    public void Configure(EntityTypeBuilder<Class> builder)
    {
        builder.ToTable("turma");
        builder.HasKey(x => x.Id);

        builder.Property(c => c.Name)
            .HasColumnName("turma")
            .HasColumnType("VARCHAR")
            .HasMaxLength(45)
            .IsRequired(true);

        builder.Property(c => c.Year)
            .HasColumnName("ano")
            .HasColumnType("INT")
            .HasMaxLength(4)
            .IsRequired(true);
    }
}
