using School.Api.Entities;

namespace School.Api.Abstractions;

public interface IClassroomRepository
{
    public Task CreateAsync(Classroom student);
    public Task UpdateAsync(Classroom student);
    public Task<Classroom?> AnyAsync(string classroom);
}
