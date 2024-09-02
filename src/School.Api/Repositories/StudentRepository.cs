using Microsoft.EntityFrameworkCore;
using School.Api.Abstractions;
using School.Api.Data;
using School.Api.Entities;

namespace School.Api.Repositories;

public class StudentRepository(AppDataContext context) : IStudentRepository
{
    public async Task<Student?> AnyAsync(string user)
        => await context.Students.FirstOrDefaultAsync(x => x.User ==  user);

    public async Task CreateAsync(Student student)
    {
        await context.Students.AddAsync(student);
        await context.SaveChangesAsync();
    }

    public async Task UpdatAsync(Student student)
    {
        context.Students.Update(student);
        await context.SaveChangesAsync();
    }
}
