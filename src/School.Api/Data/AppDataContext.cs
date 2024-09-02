using School.Api.Data.Mappings;
using School.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace School.Api.Data;

public class AppDataContext(DbContextOptions<AppDataContext> options) : DbContext
    (options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClassMap());
        modelBuilder.ApplyConfiguration(new StudentMap());
    }

    public DbSet<Class> Classes => Set<Class>();
    public DbSet<Student> Students => Set<Student>();
}
