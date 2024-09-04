using Microsoft.EntityFrameworkCore;
using School.Api.Abstractions;
using School.Api.Data;
using School.Api.Entities;

namespace School.Api.Repositories;

public class StudentRepository(AppDataContext context) : IStudentRepository
{
    public async Task<Student?> AnyAsync(int studentId)
        => await context.Students.FirstOrDefaultAsync(x => x.Id ==  studentId);

    public async Task CreateAsync(Student student)
    {
        await context.Students.AddAsync(student);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Student student)
    {
        context.Students.Update(student);
        await context.SaveChangesAsync();
    }
}
