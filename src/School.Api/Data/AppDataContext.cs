using School.Api.Data.Mappings;
using School.Api.Entities;
using Microsoft.EntityFrameworkCore;
using School.Api.Endpoints.StudentClassroom;

namespace School.Api.Data;

public class AppDataContext(DbContextOptions<AppDataContext> options) : DbContext
    (options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClassroomMap());
        modelBuilder.ApplyConfiguration(new StudentMap());
    }

    public DbSet<Classroom> Classes => Set<Classroom>();
    public DbSet<Student> Students => Set<Student>();

}
