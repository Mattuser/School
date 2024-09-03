using Microsoft.EntityFrameworkCore;
using School.Api.Abstractions;
using School.Api.Data;
using School.Api.Entities;

namespace School.Api.Repositories;

public class ClassroomRepository(AppDataContext context) : IClassroomRepository
{
    public async Task<Classroom?> AnyAsync(string classroom)
        => await context.Classes.FirstOrDefaultAsync(x => x.Name == classroom);

    public async Task CreateAsync(Classroom student)
    {
        await context.Classes.AddAsync(student);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Classroom student)
    {
        context.Classes.Update(student);
        await context.SaveChangesAsync();
    }
}
