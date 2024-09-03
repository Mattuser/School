using School.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace School.Api.Data.Mappings;

public class StudentMap : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("aluno");
        builder.HasKey(t => t.Id);

        builder.Property(s => s.Name)
            .HasColumnName("nome")
            .HasColumnType("VARCHAR")
            .HasMaxLength(255)
            .IsRequired(true);

        builder.Property(s => s.User)
            .HasColumnName("usuario")
            .HasColumnType("VARCHAR")
            .HasMaxLength(255)
            .IsRequired(true);

        builder.Property(s => s.Password)
            .HasColumnName("senha")
            .HasColumnType("CHAR")
            .HasMaxLength(60)
            .IsRequired(true);

        builder
            .HasMany(s => s.Classes)
            .WithMany(c => c.Students)
            .UsingEntity<Dictionary<string, object>>(
                "aluno_turma",
                classe => classe
                    .HasOne<Classroom>()
                    .WithMany()
                    .HasForeignKey("class_id")
                    .OnDelete(DeleteBehavior.Cascade),
                student => student
                    .HasOne<Student>()
                    .WithMany()
                    .HasForeignKey("aluno_id")
                    .OnDelete(DeleteBehavior.Cascade)
            );

    }
}
