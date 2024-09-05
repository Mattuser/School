using School.Api.Entities;

namespace School.Api.Abstractions;

public interface IStudentRepository
{
    Task CreateAsync(Student student);
    Task UpdateAsync(Student student);
    Task<Student?> AnyAsync(int id);
}
